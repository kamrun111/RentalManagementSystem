using Building.DataAccess.Data;
using Building.DataAccess.Repository.IRepository;
using Building.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BuildingBalance.Areas.Admin.Controllers
{
    [Area("Admin")] // Move the Area attribute to the class level
    public class ExpenditureController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ExpenditureController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: Expenditure  
        public async Task<IActionResult> Index()
        {
            var expenditures = await _unitOfWork.Expenditure
                .GetAllAsync(includeProperties: "ExpenditureDetails,Location");

            // expenditures is likely IEnumerable<Expenditure> or List<Expenditure>

            return View(expenditures);
        }

        public async Task<IActionResult> Create()
        {

            var expenses = await _unitOfWork.Expense.GetAllAsync();
            var location = await _unitOfWork.Location.GetAllAsync();
            ViewBag.ExpenseList = new SelectList(expenses, "ExpenseId", "ExpenseName");
            ViewBag.LocationList = new SelectList(location, "LocationId", "LocationName");
            return View();
        }

        // POST: Expenditure/Create


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Expenditure expenditure)
        {
            if (ModelState.IsValid)
            {
                // Initialize details list if null
                if (expenditure.ExpenditureDetails == null)
                {
                    expenditure.ExpenditureDetails = new List<ExpenditureDetail>();
                }

                // Set creation date (or any other metadata)
                expenditure.CreatedDate = DateTime.Now;

                // Generate invoice number (example with yyyy-MM format and sequential number)
                var now = DateTime.Now;
                var yearMonth = now.ToString("yyyy-MM");

                var lastInvoiceNumbers = await _unitOfWork.Expenditure
                    .GetAllAsync(e => e.ExpenditureInvoice.StartsWith(yearMonth));

                int maxSequence = 0;
                foreach (var item in lastInvoiceNumbers)
                {
                    if (!string.IsNullOrEmpty(item.ExpenditureInvoice) && item.ExpenditureInvoice.Length >= 7)
                    {
                        var seqStr = item.ExpenditureInvoice.Substring(item.ExpenditureInvoice.Length - 6);
                        if (int.TryParse(seqStr, out int seq) && seq > maxSequence)
                        {
                            maxSequence = seq;
                        }
                    }
                }

                expenditure.ExpenditureInvoice = $"{yearMonth}-{(maxSequence + 1):D6}";

                // Optional: Calculate total amount from details manually entered Amounts
                expenditure.TotalAmount = expenditure.ExpenditureDetails.Sum(d => d.Amount ?? 0);

                // Save expenditure and its details
                await _unitOfWork.Expenditure.AddAsync(expenditure);
                await _unitOfWork.SaveAsync();
                TempData["Success"] = "Data Created Successfully";
                return RedirectToAction(nameof(Index));


            }

            // If validation fails, reload ExpenseList for dropdowns and return view
            var expenses = await _unitOfWork.Expense.GetAllAsync();
            var location = await _unitOfWork.Location.GetAllAsync();
            ViewBag.ExpenseList = new SelectList(expenses, "ExpenseId", "ExpenseName");
            ViewBag.LocationList = new SelectList(location, "LocationId", "LocationName");
            return View(expenditure);
        }


        public async Task<ActionResult> Edit(int id)
        {
            var expenditure = await _unitOfWork.Expenditure.GetFirstOrDefaultAsync(
                x => x.ExpenditureId == id,
                includeProperties: "ExpenditureDetails");

            if (expenditure == null)
                return NotFound();

            var expenses = _unitOfWork.Expense.GetAll().ToList();
            var location = await _unitOfWork.Location.GetAllAsync();
            ViewBag.ExpenseList = new SelectList(expenses, "ExpenseId", "ExpenseName");
            ViewBag.LocationList = new SelectList(location, "LocationId", "LocationName");


            return View(expenditure);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Expenditure expenditure)
        {
            if (!ModelState.IsValid)
            {
                // Reload Expense dropdown list if model validation fails
                var expenses = _unitOfWork.Expense.GetAll().ToList();
                ViewBag.ExpenseList = new SelectList(expenses, "ExpenseId", "ExpenseName");
                return View(expenditure);
            }

            // Fetch existing expenditure from DB with details
            var existingExpenditure = await _unitOfWork.Expenditure.GetFirstOrDefaultAsync(
                x => x.ExpenditureId == expenditure.ExpenditureId,
                includeProperties: "ExpenditureDetails");

            if (existingExpenditure == null)
            {
                return NotFound();
            }

            // Update scalar properties
            existingExpenditure.ExpenditureDate = expenditure.ExpenditureDate;
            existingExpenditure.Description = expenditure.Description;
            existingExpenditure.TotalAmount = expenditure.TotalAmount;


            foreach (var detail in expenditure.ExpenditureDetails)
            {
                var existingDetail = existingExpenditure.ExpenditureDetails
                    .FirstOrDefault(d => d.ExpenditureDetailId == detail.ExpenditureDetailId);

                if (existingDetail != null)
                {
                    // Update existing detail
                    existingDetail.ExpenseId = detail.ExpenseId;
                    existingDetail.Amount = detail.Amount;
                    existingDetail.Remarks = detail.Remarks;
                }

            }

            // Save changes
            await _unitOfWork.SaveAsync();
            TempData["Success"] = "Data Updated Successfully";

            return RedirectToAction(nameof(Index));
        }








    }
}

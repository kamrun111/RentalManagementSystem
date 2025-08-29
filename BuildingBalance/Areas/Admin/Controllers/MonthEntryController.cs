using Building.DataAccess.Repository.IRepository;
using Building.Models.ViewModel;
using Building.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace BuildingBalance.Areas.Admin.Controllers
{
    [Area("Admin")]
 
    public class MonthEntryController : Controller
    {
        public readonly IUnitOfWork _unitOfWork;
        [BindProperty]
        public MonthEntryVM MonthEntryVM { get; set; }
        public MonthEntryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork= unitOfWork;
        }
        public IActionResult Index()
        {

            MonthEntryVM = new()
            {
                MonthEntryList = _unitOfWork.MonthEntry.GetAll(includeProperties: "TypeIdentifier")
                    .Where(m => m.Status == 0 || m.Status == null)
                    .OrderByDescending(m => m.MonthEntryId)
                    .ToList()
            };
            var TypeIdentifierList = Helper.CreateSelectList(_unitOfWork.TypeIdentifier.GetAll(), "TypeIdentifierName", "TypeIdentifierId");
            ViewBag.TypeIdentifierList = TypeIdentifierList;
            return View(MonthEntryVM);



        }

        [HttpPost]
        public  IActionResult CreateUpdate(MonthEntryVM monthVM)
        {
            try
            {
                monthVM.MonthEntry.Status = 0; // Active status

                                            
                if (!ModelState.IsValid)
                {
                    monthVM.MonthEntryList = _unitOfWork.MonthEntry.GetAll().Where(m => m.Status == 0)
                        .OrderByDescending(m => m.MonthEntryId)
                        .ToList();
                    monthVM.MonthEntry.MonthName = monthVM.MonthEntry.StartDate.ToString("MMMM/yyyy");

                    return View("Index", monthVM);
                }
                else
                {
                    monthVM.MonthEntry.MonthName = monthVM.MonthEntry.StartDate.ToString("MMMM/yyyy");

                    if (monthVM.MonthEntry.MonthEntryId == 0)
                    {
                        monthVM.MonthEntry.Record_creted_date = DateTime.Now;
                        _unitOfWork.MonthEntry.Add(monthVM.MonthEntry);
                    }
                    else
                    {
                        _unitOfWork.MonthEntry.Update(monthVM.MonthEntry);
                    }

                    _unitOfWork.Save();
                    TempData["Success"] = "Month Created Successfully";
                    return RedirectToAction(nameof(Index));
                }
            }
            catch
            {
                return View(monthVM);
            }
        }

        [HttpPost]
        //[ActionName("Complete")]
        public IActionResult Complete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var monthEntryFromDb = _unitOfWork.MonthEntry.Get(m => m.MonthEntryId == id);
            if (monthEntryFromDb == null)
            {
                return NotFound();
            }
            monthEntryFromDb.Status = 1; // Completed status
            _unitOfWork.MonthEntry.Update(monthEntryFromDb);
            _unitOfWork.Save();
            TempData["Success"] = "Month Completed Successfully";
            return RedirectToAction(nameof(Index));
        }


    }

}

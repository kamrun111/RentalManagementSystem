using Building.DataAccess.Data;
using Building.DataAccess.Repository.IRepository;
using Building.Models;
using Building.Models.ViewModel;
using Building.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;


namespace BuildingBalance.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TenantController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public TenantController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        private IEnumerable<SelectListItem> GetFlatSelectList()
        {
            return _unitOfWork.Flat.GetAll().Where(f => f.FlatStatus == 0)  // filter for FlatStatus == 1
                .Select(u => new SelectListItem
                {
                    Text = u.FlatName,
                    Value = u.FlatId.ToString()
                })
                .Prepend(new SelectListItem { Text = "-- Select Flat --", Value = "" });
        }


        public IActionResult Index()
        {
            List<Tenant> TenantList = _unitOfWork.Tenant.GetAll(includeProperties: "Flat")
                .OrderBy(u => u.StatusId)
                .ThenBy(u => u.TenantName)
                .ToList();
            ViewBag.FlatList = GetFlatSelectList();
            return View(TenantList);
        }
        [HttpGet]
        public IActionResult Create()
        {

            IEnumerable<SelectListItem> Statuslist = _unitOfWork.Status.GetAll()
                .Select(u => new SelectListItem
                {
                    Text = u.StatusName,
                    Value = u.StatusId.ToString()
                });
            ViewBag.StatuslistItem = Statuslist;


            ViewBag.FlatList = GetFlatSelectList();  // Pass to view
            var tenant = new Tenant
            {
                RegisterDate = DateTime.Today
            };

            return View(tenant);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Tenant obj)
        {

            if (ModelState.IsValid)
            {
                _unitOfWork.Tenant.Add(obj);

                var flat = _unitOfWork.Flat.Get(f => f.FlatId == obj.FlatId);
                flat.FlatStatus = 1;
                _unitOfWork.Flat.Update(flat);

                _unitOfWork.Save(); // commit both changes at once
                TempData["Success"] = "Flat Created Successfully";
                return RedirectToAction("Index");
            }
            else
            {
                // If model state is invalid dropdown lists
                IEnumerable<SelectListItem> Statuslist = _unitOfWork.Status.GetAll()
                    .Select(u => new SelectListItem
                    {
                        Text = u.StatusName,
                        Value = u.StatusId.ToString()
                    });
                ViewBag.StatuslistItem = Statuslist;
                ViewBag.FlatList = GetFlatSelectList();
                return View(obj);

            }



        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Get tenant by ID including related Flat and Status if needed
            var tenant = _unitOfWork.Tenant.Get(t => t.TenantId == id.Value);

            if (tenant == null)
            {
                return NotFound();
            }

            // Populate dropdown lists for Flats and Statuses
            ViewBag.FlatList = new SelectList(_unitOfWork.Flat.GetAll(), "FlatId", "FlatName", tenant.FlatId);
            ViewBag.StatuslistItem = new SelectList(_unitOfWork.Status.GetAll(), "StatusId", "StatusName", tenant.StatusId);

            return View(tenant);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Edit(int id, Tenant obj)
        {
            if (id != obj.TenantId)
                return NotFound();

            if (ModelState.IsValid)
            {
                // Step 1: Fetch the existing tenant (tracked by EF Core)
                var existingTenant = _unitOfWork.Tenant.Get(t => t.TenantId == id);
                //if (existingTenant == null)
                //    return NotFound();

                // Step 2: Update tenant properties
                existingTenant.TenantName = obj.TenantName;
                existingTenant.TenantPhone = obj.TenantPhone;
                existingTenant.Address = obj.Address;
                existingTenant.Email = obj.Email;
                existingTenant.NationalId = obj.NationalId;
                existingTenant.RegisterDate = obj.RegisterDate;
                existingTenant.StatusId = obj.StatusId;

                // Step 3: Check if Flat has changed and update FlatStatus accordingly
                if (existingTenant.FlatId != obj.FlatId)
                {
                    // Update old flat to vacant
                    var oldFlat = _unitOfWork.Flat.Get(f => f.FlatId == existingTenant.FlatId);
                    if (oldFlat != null)
                    {
                        oldFlat.FlatStatus = 0;  // Vacant
                        _unitOfWork.Flat.Update(oldFlat);
                    }

                    // Update new flat to occupied
                    var newFlat = _unitOfWork.Flat.Get(f => f.FlatId == obj.FlatId);
                    if (newFlat != null)
                    {
                        newFlat.FlatStatus = 1;  // Occupied
                        _unitOfWork.Flat.Update(newFlat);
                    }

                    existingTenant.FlatId = obj.FlatId; // Update Tenant's flat reference
                }

                // Step 4: Update tenant in repository
                _unitOfWork.Tenant.Update(existingTenant);

                // Step 5: Save all changes once
                _unitOfWork.Save();

                TempData["Success"] = "Tenant updated successfully";
                return RedirectToAction("Index");
            }

            // If validation fails, repopulate dropdown lists and return view
            ViewBag.FlatList = GetFlatSelectList();
            ViewBag.StatuslistItem = _unitOfWork.Status.GetAll()
                .Select(u => new SelectListItem { Text = u.StatusName, Value = u.StatusId.ToString() });

            return View(obj);
        }







    }
}

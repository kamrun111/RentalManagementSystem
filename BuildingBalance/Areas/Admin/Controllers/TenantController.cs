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

        public IActionResult Index()
        {
            try
            {


                List<Tenant> TenantList = _unitOfWork.Tenant.GetAll(includeProperties: "Flat,Flat.Location")  // Include Flat and its Location
                                   .Where(t => t.StatusId == 1)  // Filter for TenantStats = 1
                                   .OrderBy(t => t.Flat.Location.LocationName)  // Order by LocationId from related Flat's Location
                                   .ThenBy(t => t.TenantName)       // Then order by TenantName
                                   .ToList();

                //ViewBag.FlatList = GetFlatSelectList();
                return View(TenantList);
            }
            catch
            {

            }
            return View();
        }

        // Action to fetch flats based on location
        public JsonResult GetFlatsByLocation(int locationId)
        {
            var flats = _unitOfWork.Flat.GetAll()
                        .Where(f => f.LocationId == locationId && f.FlatStatus==0)
                        .Select(f => new
                        {
                            FlatId = f.FlatId,
                            FlatName = f.FlatName
                        })
                        .ToList();
            return Json(flats);
        }


        [HttpGet]
        public IActionResult Create()
        {
            var Statuslist = Helper.CreateSelectList(_unitOfWork.Status.GetAll(), "StatusName", "StatusId");
            ViewBag.StatuslistItem = Statuslist;
            var Locationlist = Helper.CreateSelectList(_unitOfWork.Location.GetAll(), "LocationName", "LocationId");
            ViewBag.LocationlistItem = Locationlist;
            //var FlatList = Helper.CreateSelectList(_unitOfWork.Flat.GetAll(), "FlatName", "FlatId");
            //ViewBag.FlatList = FlatList; // Pass to view
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
                obj.StatusId = 1;// tenant stats active=1
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
                ViewBag.StatuslistItem = new SelectList(_unitOfWork.Status.GetAll(), "StatusId", "StatusName", obj.StatusId);
                var Locationlist = Helper.CreateSelectList(_unitOfWork.Location.GetAll(), "LocationName", "LocationId");
                ViewBag.LocationlistItem = Locationlist;
                var FlatList = Helper.CreateSelectList(_unitOfWork.Flat.GetAll(), "FlatName", "FlatId");
               
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
            var Locationlist = Helper.CreateSelectList(_unitOfWork.Location.GetAll(), "LocationName", "LocationId");
            ViewBag.LocationlistItem = Locationlist;

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

                var existingTenant = _unitOfWork.Tenant.Get(t => t.TenantId == id);

                existingTenant.TenantName = obj.TenantName;
                existingTenant.TenantPhone = obj.TenantPhone;
                existingTenant.Address = obj.Address;
                existingTenant.Email = obj.Email;
                existingTenant.NationalId = obj.NationalId;
                existingTenant.RegisterDate = obj.RegisterDate;
                existingTenant.StatusId = obj.StatusId;

                    // Step 3: Check if Flat has changed and update FlatStatus accordingly
               if (existingTenant.FlatId != obj.FlatId || obj.StatusId == 0)
                {
                    // Update old flat to vacant
                    var oldFlat = _unitOfWork.Flat.Get(f => f.FlatId == existingTenant.FlatId);
                    if (oldFlat != null)
                    {
                        oldFlat.FlatStatus = 0;  // Vacant
                        _unitOfWork.Flat.Update(oldFlat);
                    }


                }

                // Step 4: Update tenant in repository
                _unitOfWork.Tenant.Update(existingTenant);

                // Step 5: Save all changes once
                _unitOfWork.Save();

                TempData["Success"] = "Tenant updated successfully";
                return RedirectToAction("Index");
            }

            // If validation fails, repopulate dropdown lists and return view
             ViewBag.FlatList = new SelectList(_unitOfWork.Flat.GetAll(), "FlatId", "FlatName", obj.FlatId);
;
            ViewBag.StatuslistItem = _unitOfWork.Status.GetAll()
                .Select(u => new SelectListItem { Text = u.StatusName, Value = u.StatusId.ToString() });

            return View(obj);
        }







    }
}

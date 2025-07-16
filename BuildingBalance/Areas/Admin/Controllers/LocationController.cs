using Building.DataAccess.Data;
using Building.DataAccess.Repository.IRepository;
using Building.Models;
using Building.Models.ViewModel;
using Building.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BuildingBalance.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Authorize(Roles =SD.Role_Admin)]
    public class LocationController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public LocationController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Location> LocationList = _unitOfWork.Location.GetAll().ToList();

            return View(LocationList);
        }
        public IActionResult Upsert( int? id)
        {

            if (id == null || id == 0)
            {
                //Create
                return View(new Location());

            }
            else
            
            {
                //update
                Location company=_unitOfWork.Location.Get(u=>u.LocationId==id);
                return View(company);

            }


            
        }
        [HttpPost]
        public IActionResult Upsert(Location obj)
        {

            if (ModelState.IsValid)
            {
                if(obj.LocationId==0)
                {
                    _unitOfWork.Location.Add(obj);
                }
                else
                {
                    _unitOfWork.Location.Update(obj);
                }


                 _unitOfWork.Save();
                TempData["Success"] = "Location Created Successfully";
                return RedirectToAction("Index");
            }
            else
            {
  
                return View(obj);

            }
                

            
        }



        //public IActionResult Delete(int? id)
        //{
        //    if (id == null || id == 0)
        //    {
        //        return NotFound();
        //    }
        //    Location? locationDb = _unitOfWork.Location.Get(e => e.LocationId == id);
        //    if (locationDb == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(locationDb);
        //}
        //[HttpPost,ActionName("Delete")]
        //public IActionResult DeletePost(int? id)
        //{

        //    Location? obj = _unitOfWork.Location.Get(e => e.LocationId == id);
        //    if (obj==null)
        //    { return NotFound(); }
        //    _unitOfWork.Location.Remove(obj);
        //    _unitOfWork.Save();//Savechanges
        //    TempData["success"] = "Location Data Deleted Successfully";
        //    return RedirectToAction("Index");
        


        //}


        #region API CALLS


        [HttpGet]
        public IActionResult GetAll()
        {
            List<Location> LocationList = _unitOfWork.Location.GetAll().ToList();
            return Json(new { data = LocationList });
        }


        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var locationDb = _unitOfWork.Location.Get(e => e.LocationId == id);
            if (locationDb == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }
            else
            {
                _unitOfWork.Location.Remove(locationDb);
                _unitOfWork.Save();
                return Json(new { success = true, message = "Delete Successful" });
            }

        }

        #endregion


    }
}

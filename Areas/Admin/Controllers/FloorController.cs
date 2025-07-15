using Building.DataAccess.Data;
using Building.DataAccess.Repository.IRepository;
using Building.Models;
using Microsoft.AspNetCore.Mvc;

namespace BuildingBalance.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class FloorController : Controller
    {
        public readonly IUnitOfWork _unitOfWork;
        public FloorController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Floor> FloorList = _unitOfWork.Floor.GetAll().ToList();
            return View(FloorList);
        }
        public IActionResult Create()
        {
            
            return View();
        }
        [HttpPost]
        public IActionResult Create(Floor obj)
        {
            if(obj.FloorName.ToLower()=="test")
            {
                ModelState.AddModelError("", "The test is invalid value");
            }
            if (ModelState.IsValid)
            {
                _unitOfWork.Floor.Add(obj);
                _unitOfWork.Save();
                TempData["Success"] = "Floor Created Successfully";
                return RedirectToAction("Index");
            }
            return View(obj);

            
        }

        public IActionResult Edit(int? id)
        {
            if(id==null || id==0)
            {
                return NotFound();
            }
            Floor? FloorDb = _unitOfWork.Floor.Get(e=>e.FloorId==id);
            if(FloorDb==null)
            {
                return NotFound();
            }

            return View(FloorDb);
        }
        [HttpPost]
        public IActionResult Edit(Floor obj)
        {

            if (ModelState.IsValid)
            {
                _unitOfWork.Floor.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Floor Data Updated Successfully";
                return RedirectToAction("Index");
            }
            return View(obj);


        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Floor? FloorDb = _unitOfWork.Floor.Get(e => e.FloorId == id);
            if (FloorDb == null)
            {
                return NotFound();
            }

            return View(FloorDb);
        }
        [HttpPost,ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {

            Floor? obj = _unitOfWork.Floor.Get(e => e.FloorId == id);
            if (obj==null)
            { return NotFound(); }
            _unitOfWork.Floor.Remove(obj);
            _unitOfWork.Save();//Savechanges
            TempData["success"] = "Floor Data Deleted Successfully";
            return RedirectToAction("Index");
        


        }
    }
}

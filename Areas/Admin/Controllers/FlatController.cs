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
    public class FlatController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public FlatController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Flat> FlatList = _unitOfWork.Flat.GetAll(includeProperties: "Floor,FlatType").ToList();
            //List<Flat> FlatList = _unitOfWork.Flat.GetAll(includeProperties: "Floor,Property1,Property2").ToList(); for more include properties

            return View(FlatList);
        }
        public IActionResult Upsert( int? id)
        {
            var floorItems = _unitOfWork.Floor.GetAll();
            var flatTypeItems = _unitOfWork.FlatType.GetAll();
            FlatVM FlatVM = new()
            {
                FloorList = Helper.CreateSelectList(floorItems, "FloorName", "FloorId"),
                TypeList = Helper.CreateSelectList(flatTypeItems, "Type", "FlatTypeId"),
                Flat = new Flat()
            };

            if (id == null || id == 0)
            {
                //Create
                return View(FlatVM);

            }
            else
            
            {
                //update
                FlatVM.Flat=_unitOfWork.Flat.Get(u=>u.FlatId==id);
                return View(FlatVM);

            }


            
        }
        [HttpPost]
        public IActionResult Upsert(FlatVM obj)
        {

            if (ModelState.IsValid)
            {
                if(obj.Flat.FlatId==0)
                {
                    _unitOfWork.Flat.Add(obj.Flat);
                }
                else
                {
                    _unitOfWork.Flat.Update(obj.Flat);
                }


                 _unitOfWork.Save();
                TempData["Success"] = "Flat Created Successfully";
                return RedirectToAction("Index");
            }
            else
            {
                // If model state is invalid dropdown lists
                var floorItems = _unitOfWork.Floor.GetAll();
                var flatTypeItems = _unitOfWork.FlatType.GetAll();

                obj.FloorList = Helper.CreateSelectList(floorItems, "FloorName", "FloorId");
                obj.TypeList = Helper.CreateSelectList(flatTypeItems, "Type", "FlatTypeId");
                return View(obj);

            }
                

            
        }



        //public IActionResult Delete(int? id)
        //{
        //    if (id == null || id == 0)
        //    {
        //        return NotFound();
        //    }
        //    Flat? flatDb = _unitOfWork.Flat.Get(e => e.FlatId == id);
        //    if (flatDb == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(flatDb);
        //}
        //[HttpPost,ActionName("Delete")]
        //public IActionResult DeletePost(int? id)
        //{

        //    Flat? obj = _unitOfWork.Flat.Get(e => e.FlatId == id);
        //    if (obj==null)
        //    { return NotFound(); }
        //    _unitOfWork.Flat.Remove(obj);
        //    _unitOfWork.Save();//Savechanges
        //    TempData["success"] = "Flat Data Deleted Successfully";
        //    return RedirectToAction("Index");
        


        //}


        #region API CALLS


        [HttpGet]
        public IActionResult GetAll()
        {
            List<Flat> FlatList = _unitOfWork.Flat.GetAll(includeProperties: "Floor,FlatType").ToList();
            return Json(new { data = FlatList });
        }


        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var flatDb = _unitOfWork.Flat.Get(e => e.FlatId == id);
            if (flatDb == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }
            else
            {
                _unitOfWork.Flat.Remove(flatDb);
                _unitOfWork.Save();
                return Json(new { success = true, message = "Delete Successful" });
            }

        }

        #endregion


    }
}

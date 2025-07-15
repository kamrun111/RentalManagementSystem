using System.Diagnostics;
using Building.DataAccess.Repository.IRepository;
using Building.Models;
using Microsoft.AspNetCore.Mvc;

namespace BuildingBalance.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<Flat> FlatList = _unitOfWork.Flat.GetAll(includeProperties: "Floor,FlatType").ToList();
            return View(FlatList);
        }

        public IActionResult Details(int id)
        {
            Flat flat = _unitOfWork.Flat.Get(u => u.FlatId == id, includeProperties: "Floor,FlatType");
            return View(flat);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

using B21leowa_DOTNet.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace B21leowa_DOTNet.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IConfiguration _configuration;
        private BarnModel _barnModel;
        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _configuration = configuration;
            _logger = logger;
            _barnModel = new BarnModel(_configuration);
        }

        public IActionResult Index()
        {
            ViewBag.barnTable = _barnModel.GetAllChildren();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult CreateChildView()
        {
            return View();
        }

        public IActionResult InsertChild(string PNR, string firstname, string surname, string birthday, int kindnessScale, string pwd)
        {
            _barnModel.InsertChild(PNR, firstname, surname, birthday, kindnessScale, pwd);
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
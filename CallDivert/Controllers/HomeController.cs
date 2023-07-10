using CallDivert.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CallDivert.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly CallDivertDbContext  _dbContext;
        public HomeController(ILogger<HomeController> logger, CallDivertDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            ViewBag.Title = "Home";

            // Fetch the list of entities from the database
            var entities = _dbContext.Users.ToList();

            // Pass the list of entities to the view
            return View(entities);
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
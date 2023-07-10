using CallDivert.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CallDivert.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Dashboard
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Dashboardv1()
        {
            return View();
        }

        public ActionResult Dashboardv2()
        {
            return View();
        }
    }
}
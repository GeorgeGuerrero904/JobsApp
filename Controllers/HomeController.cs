using JobsApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using JobsApp.ProjectScripts;

namespace JobsApp.Controllers
{
    public class HomeController : Controller
    {
        public readonly AppConfig _appConfig;
        public HomeController(AppConfig config)
        {
            _appConfig = config;
        }
        public IActionResult Index()
        {
            DatabaseDocumentator doc = new DatabaseDocumentator(_appConfig);
            doc.DocumentDatabase();
            return View();
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

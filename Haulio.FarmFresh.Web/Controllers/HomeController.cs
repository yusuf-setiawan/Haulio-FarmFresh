using Haulio.FarmFresh.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Haulio.FarmFresh.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("Products")]
        public IActionResult Products()
        {
            return View();
        }

        [HttpGet("ProductDetail/{id}")]

        public IActionResult ProductDetail(int id)
        { 
            return View();
        }

        [HttpPost("SignOut")]
        public JsonResult SignOut()
        {
            HttpContext.Session.SetString("Token", "");
            HttpContext.Session.SetString("Cart", "");
            HttpContext.Session.SetString("CartCount", "");
            return Json(new { success = true });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

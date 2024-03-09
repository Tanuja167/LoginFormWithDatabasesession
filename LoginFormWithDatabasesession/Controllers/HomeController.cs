using LoginFormWithDatabasesession.Data;
using LoginFormWithDatabasesession.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LoginFormWithDatabasesession.Controllers
{
    public class HomeController : Controller
    {
        
        private readonly ApplicationDbContext db;

        public HomeController(ApplicationDbContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        
        public IActionResult Login(User1 user)
        {
            var result = db.user1.Where(x => x.Email == user.Email && x.Password == user.Password).FirstOrDefault();
            if(result != null)
            {
                HttpContext.Session.SetString("mysession", result.Email);
                return RedirectToAction("DashBoard");
            }
            else
            {
                ViewBag.msg = "Login failed...";
            }
            return View();
        }

        public IActionResult DashBoard()
        {
            if(HttpContext.Session.GetString("mysession") != null)
            {
                ViewBag.Msg = HttpContext.Session.GetString("mysession").ToString();
            }
            else
            {
                return RedirectToAction("Login");
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
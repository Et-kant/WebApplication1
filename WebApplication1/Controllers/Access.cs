using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class Access : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

    }
}

using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.Api.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

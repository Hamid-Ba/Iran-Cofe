using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.Api.Areas.Admin.Controllers
{
    public class DashboardController : AdminBaseController
    {
        public IActionResult Index() => View();
    }
}
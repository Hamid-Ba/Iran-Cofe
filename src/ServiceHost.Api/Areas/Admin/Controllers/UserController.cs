using IranCafe.Application.Contract.UserAgg.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.Api.Areas.Admin.Controllers
{
    public class UserController : AdminBaseController
    {
        private readonly IUserApplication _userApplication;

        public UserController(IUserApplication userApplication) => _userApplication = userApplication;

        public async Task<IActionResult> Index(bool isDelete = false)
        {
            var users = await _userApplication.GetAll(isDelete);
            ViewBag.IsDelete = isDelete;
            ViewBag.Count = users.Count();
            return View(users);
        }
        
    }
}
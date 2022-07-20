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

        [HttpGet]
        public async Task<IActionResult> ChangeStatus(Guid id)
        {
            var result = await _userApplication.ActiveOrDeactive(id);

            if (result.IsSucceeded) TempData[SuccessMessage] = result.Message;

            return new JsonResult(result);
        }


    }
}
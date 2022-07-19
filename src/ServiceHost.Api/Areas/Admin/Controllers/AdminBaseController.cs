using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.Api.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Authorize(Roles = "Operator")]
    public class AdminBaseController : Controller
    {
        protected string ErrorMessage = "ErrorMessage";
        protected string SuccessMessage = "SuccessMessage";
        protected string InfoMessage = "InfoMessage";
        protected string WarningMessage = "WarningMessage";
    }
}
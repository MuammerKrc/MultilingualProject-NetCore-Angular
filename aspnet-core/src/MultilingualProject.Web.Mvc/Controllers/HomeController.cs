using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using MultilingualProject.Controllers;

namespace MultilingualProject.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : MultilingualProjectControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}

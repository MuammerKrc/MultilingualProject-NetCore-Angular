using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using MultilingualProject.Controllers;

namespace MultilingualProject.Web.Controllers
{
    [AbpMvcAuthorize]
    public class AboutController : MultilingualProjectControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}

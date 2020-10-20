using System.Web.Mvc;
using Dnn.Modules.Blog.Common;

namespace Dnn.Modules.Blog.Controllers
{
    public class HomeController : BlogMvcController
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View(BlogModuleContext.Settings.View);
        }
    }
}

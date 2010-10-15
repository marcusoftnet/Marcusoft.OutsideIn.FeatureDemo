using System;
using System.Web.Mvc;
using FeatureDBWrapper;

namespace Marcusoft.OutsideIn.FeatureDemo.Web.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        private readonly IFeatureDBWrapper _featureDBWrapper;

        public HomeController(IFeatureDBWrapper featureDBWrapper)
        {
            _featureDBWrapper = featureDBWrapper;
        }

        public ActionResult Index()
        {
            return View(_featureDBWrapper.AllNotDone());
        }
    }
}

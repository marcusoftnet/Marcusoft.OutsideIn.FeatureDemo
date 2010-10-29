using System.Linq;
using System.Web.Mvc;
using FeatureDBWrapper;

namespace Marcusoft.OutsideIn.FeatureDemo.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IFeatureDBWrapper _featureDBWrapper;

        public HomeController(IFeatureDBWrapper featureDBWrapper)
        {
            _featureDBWrapper = featureDBWrapper;
        }

        public ActionResult Index()
        {
            var features = _featureDBWrapper.AllNotDone().ToList(); 
            return View(features);
        }
    }
}

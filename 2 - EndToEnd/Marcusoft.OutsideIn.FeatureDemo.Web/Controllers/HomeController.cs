using System;
using System.Collections.Generic;
using System.Linq;
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

        public ActionResult Index(bool? showDoneItems = false, string filter = "")
        {
            IEnumerable<Feature> features;

            if (!string.IsNullOrWhiteSpace(filter))
            {
                features = from f in _featureDBWrapper.All()
                           where f.Name.StartsWith(filter)
                           select f;
            }
            else
            {
                if (showDoneItems.GetValueOrDefault(false))
                {
                    features = _featureDBWrapper.AllDone();
                }
                else
                {
                    features = _featureDBWrapper.AllNotDone(); ;
                }
            }

            return View(features);
        }
    }
}

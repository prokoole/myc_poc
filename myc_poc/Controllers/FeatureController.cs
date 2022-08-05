using Microsoft.AspNetCore.Mvc;
using Microsoft.FeatureManagement;
using Microsoft.FeatureManagement.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myc_poc.Controllers
{
    public class FeatureController : Controller
    {
        private readonly IFeatureManager featureManager;

        public FeatureController(IFeatureManager featureManager)
        {
            this.featureManager = featureManager;
        }

        [FeatureGate(FeatureFlag.oleg_myc_poc_feature_1)]
        public IActionResult Index()
        {
            var feature2Enabled = this.featureManager.IsEnabledAsync(FeatureFlag.oleg_myc_poc_feature_2.ToString()).GetAwaiter().GetResult();

            if (feature2Enabled)
            {
                return View("Feature");
            }
            else
            {
                return View();
            }

            
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sitecore.Commerce.Core;

namespace Sitecore.Commerce.Plugin.UpsAddressValidation.Policies
{
    public class UpsAddressValidationPolicy : Policy
    {

        public UpsAddressValidationPolicy()
        {
            UserName = "xxxxxxx";
            Password = "xxxxxxx";
            LicenseKey = "xxxxxxx";
            ProdUrl = "https://onlinetools.ups.com/rest/XAV";
            TestUrl = "https://wwwcie.ups.com/rest/XAV";
            IsLive=true;
        }

        public string UserName { get; set; }
        public string Password { get; set; }
        public string LicenseKey { get; set; }
        public string ProdUrl { get; set; }
        public string TestUrl { get; set; }
        public bool IsLive { get; set; }
    }
}

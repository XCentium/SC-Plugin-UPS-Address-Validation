using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sitecore.Commerce.Plugin.UpsAddressValidation
{
    public class Constants
    {
        public struct Address
        {
            public const string ConsigneeName = "ConsigneeName";
            public const string BuildingName = "BuildingName";
            public const string DefaultConsigneeName = "Consignee Name";
            public const string DefaultBuildingName = "Building Name";
            public const string DefaultCountryCode = "US";
            public const string AddressLine1 = "AddressLine1";
            public const string AddressLine2 = "AddressLine2";
            public const string City = "City";
            public const string State = "State";
            public const string ZipCode = "ZipCode";
            public const string CountryCode = "CountryCode";
        }


        public struct Headers
        {
            public const string ContentType = "application/json";
            public const string AllowHeaders = "Origin, X-Requested-With, Content-Type, Accept";
            public const string Methods = "POST";
            public const string Origin = "*";

            public const string AcessControlHeaders = "Access-Control-Allow-Headers";
            public const string AcessControlMethods = "Access-Control-Allow-Methods";
            public const string AcessControlOrigin = "Access-Control-Allow-Origin";
        }


    }
}

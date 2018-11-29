using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Serilog;
using Sitecore.Commerce.Core;
using Sitecore.Commerce.Core.Commands;
using Sitecore.Commerce.Plugin.UpsAddressValidation.Models;
using Sitecore.Commerce.Plugin.UpsAddressValidation.Policies;

namespace Sitecore.Commerce.Plugin.UpsAddressValidation.Commands
{
    public class UpsValidateAddressCommand : CommerceCommand
    {
        public UpsValidateAddressCommand(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        public virtual string Process(CommerceContext commerceContext, InputAddress inputAddress)
        {

            var upsClientPolicy = commerceContext.GetPolicy<UpsAddressValidationPolicy>();

            var url = upsClientPolicy.IsLive ? upsClientPolicy.ProdUrl : upsClientPolicy.TestUrl;

            var requestString = $@"{{
	            ""UPSSecurity"": {{
		            ""UsernameToken"": {{
			            ""Username"": ""{upsClientPolicy.UserName}"",
			            ""Password"": ""{upsClientPolicy.Password}""
		            }},
		            ""ServiceAccessToken"": {{
			            ""AccessLicenseNumber"": ""{upsClientPolicy.LicenseKey}""
		            }}
	            }},
	            ""XAVRequest"": {{
		            ""Request"": {{
			            ""RequestOption"": ""1"",
			            ""TransactionReference"": {{
				            ""CustomerContext"": ""Your Customer Context""
			            }}
		            }},
		            ""MaximumListSize"": ""10"",
		            ""AddressKeyFormat"": {{
			            ""ConsigneeName"": ""{inputAddress.ConsigneeName}"",
			            ""BuildingName"": ""{inputAddress.BuildingName}"",
			            ""AddressLine"": ""{inputAddress.AddressLine1}"",
			            ""PoliticalDivision2"": ""{inputAddress.City}"",
			            ""PoliticalDivision1"": ""{inputAddress.State}"",
			            ""PostcodePrimaryLow"": ""{inputAddress.ZipCode}"",
			            ""CountryCode"": ""{inputAddress.CountryCode}""
		            }}
	            }}
            }}";




            var client = new HttpClient();
            var content = new StringContent(requestString, Encoding.UTF8, Constants.Headers.ContentType);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(Constants.Headers.ContentType));
            content.Headers.ContentType = new MediaTypeHeaderValue(Constants.Headers.ContentType);
            client.DefaultRequestHeaders.Add(Constants.Headers.AcessControlHeaders, Constants.Headers.AllowHeaders);
            client.DefaultRequestHeaders.Add(Constants.Headers.AcessControlMethods, Constants.Headers.Methods);
            client.DefaultRequestHeaders.Add(Constants.Headers.AcessControlOrigin, Constants.Headers.Origin);

            try
            {
                var output = client.PostAsync(url, content).Result;
                output.EnsureSuccessStatusCode();

                var outputData = output.Content.ReadAsStringAsync().Result;

                return outputData;

            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);

            }

            return string.Empty;



        }
    }
}

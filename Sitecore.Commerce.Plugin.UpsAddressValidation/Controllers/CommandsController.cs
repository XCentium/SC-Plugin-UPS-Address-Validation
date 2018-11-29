// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CommandsController.cs" company="Sitecore Corporation">
//   Copyright (c) Sitecore Corporation 1999-2017
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Web.Http.OData;
using Microsoft.AspNetCore.Mvc;
using Sitecore.Commerce.Core;
using Sitecore.Commerce.Plugin.UpsAddressValidation.Commands;
using Sitecore.Commerce.Plugin.UpsAddressValidation.Models;

namespace Sitecore.Commerce.Plugin.UpsAddressValidation.Controllers
{
    /// <inheritdoc />
    /// <summary>
    /// Defines a controller
    /// </summary>
    /// <seealso cref="T:Sitecore.Commerce.Core.CommerceController" />
    public class CommandsController : CommerceController
    {
        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Sitecore.Commerce.Plugin.UpsAddressValidation.Controllers.CommandsController" /> class.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <param name="globalEnvironment">The global environment.</param>
        public CommandsController(IServiceProvider serviceProvider, CommerceEnvironment globalEnvironment)
            : base(serviceProvider, globalEnvironment)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("UpsValidateAddress()")]
        public IActionResult UpsValidateAddress([FromBody] ODataActionParameters value)
        {

            if (!value.ContainsKey(Constants.Address.AddressLine1)) return (IActionResult)new BadRequestObjectResult((object)value);
            if (!value.ContainsKey(Constants.Address.City)) return (IActionResult)new BadRequestObjectResult((object)value);
            if (!value.ContainsKey(Constants.Address.State)) return (IActionResult)new BadRequestObjectResult((object)value);
            if (!value.ContainsKey(Constants.Address.ZipCode)) return (IActionResult)new BadRequestObjectResult((object)value);

            var inputAddress = new InputAddress
            {
                AddressLine1 = value[Constants.Address.AddressLine1].ToString(),
                City = value[Constants.Address.City].ToString(),
                State = value[Constants.Address.State].ToString(),
                ZipCode = value[Constants.Address.ZipCode].ToString(),
                CountryCode = "US", //value[Constants.Address.CountryCode].ToString(),
                AddressLine2 = value.ContainsKey(Constants.Address.AddressLine2) ? value[Constants.Address.AddressLine2].ToString() : string.Empty,
                ConsigneeName =
                    value.ContainsKey(Constants.Address.ConsigneeName) ? value[Constants.Address.ConsigneeName].ToString() : Constants.Address.DefaultConsigneeName,
                BuildingName = value.ContainsKey(Constants.Address.BuildingName) ? value[Constants.Address.BuildingName].ToString() : Constants.Address.DefaultBuildingName
            };

            var command = this.Command<UpsValidateAddressCommand>();
            var result = command.Process(CurrentContext, inputAddress);

            return new ObjectResult(result);
        }

    }
}


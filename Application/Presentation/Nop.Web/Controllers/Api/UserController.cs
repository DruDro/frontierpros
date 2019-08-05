using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FrontierPros.Core.Domain.Customers;
using FrontierPros.Services.Providers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Core.Domain.Customers;
using Nop.Services.Common;
using Nop.Services.Customers;
using Nop.Web.Models.Profile;

namespace Nop.Web.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly ICustomerService _customerService;
        private readonly IWorkContext _workContext;
        private readonly IGenericAttributeService _genericAttributeService;
        private readonly IProviderService _providerService;

        public UserController(ICustomerService customerService,
            IGenericAttributeService genericAttributeService,
            IWorkContext workContext, IProviderService providerService)
        {
            _customerService = customerService;
            _workContext = workContext;
            _genericAttributeService = genericAttributeService;
            _providerService = providerService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            if (!User.Identity.IsAuthenticated)
            {
                Response.StatusCode = StatusCodes.Status401Unauthorized;
                return new JsonResult(null);
            }

            var customerId = _workContext.CurrentCustomer.Id;
            var customer = _customerService.GetCustomerById(customerId);
            if (customer == null) return new JsonResult(null);

			return new JsonResult(new {
				customer.Id,
				roles = customer.CustomerRoles.Select(r => r.SystemName).ToArray()
			});
        }
    }
}
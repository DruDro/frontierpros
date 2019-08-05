using FrontierPros.Core.Domain.Customers;
using FrontierPros.Core.Domain.Licenses;
using FrontierPros.Core.Domain.Providers;
using FrontierPros.Core.Domain.Services;
using FrontierPros.Services.ADB2CGraph;
using FrontierPros.Services.Catalog;
using FrontierPros.Services.Customers;
using FrontierPros.Services.Licenses;
using FrontierPros.Services.Providers;
using FrontierPros.Services.Services;
using FrontierPros.Services.Storage;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Services.Common;
using Nop.Services.Customers;
using Nop.Web.Models.Profile;
using Nop.Web.Models.Providers;
using Nop.Web.Models.Services;
using Nop.Web.Validators.Files;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nop.Web.Controllers.Api
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProviderController : Controller
	{
		private readonly IWorkContext _workContext;

		private readonly ICustomerService _customerService;
		private readonly IGenericAttributeService _genericAttributeService;
		private readonly IProviderService _providerService;
		private readonly IServiceItemService _serviceItemService;
		private readonly ICoverageAreaService _coverageAreaService;
		private readonly IServiceItemMediaFileService _serviceItemMediaFileService;
		private readonly IServiceInfoService _serviceInfoService;
		private readonly IB2CGraphService _b2CGraphService;
		private readonly ILicenseService _licenseService;
		private readonly IProviderReviewService _providerReviewService;
		private readonly ICustomerMediaFileService _customerMediaFileService;

		public ProviderController(IWorkContext workContext,
			ICustomerService customerService,
			IGenericAttributeService genericAttributeService,
			IProviderService providerService,
			IServiceItemService serviceItemService,
			ICoverageAreaService coverageAreaService,
			IServiceItemMediaFileService serviceItemMediaFileService,
			IServiceInfoService serviceInfoService,
			IB2CGraphService b2CGraphService,
			ILicenseService licenseService,
			IProviderReviewService providerReviewService,
			ICustomerMediaFileService customerMediaFileService)
		{
			_workContext = workContext;
			_customerService = customerService;
			_genericAttributeService = genericAttributeService;
			_providerService = providerService;
			_serviceItemService = serviceItemService;
			_coverageAreaService = coverageAreaService;
			_serviceItemMediaFileService = serviceItemMediaFileService;
			_serviceInfoService = serviceInfoService;
			_b2CGraphService = b2CGraphService;
			_licenseService = licenseService;
			_providerReviewService = providerReviewService;
			_customerMediaFileService = customerMediaFileService;
		}

		#region Profile
		[HttpGet("profile")]
		public IActionResult GetProfile()
		{
			if (!User.Identity.IsAuthenticated)
			{
				Response.StatusCode = StatusCodes.Status401Unauthorized;
				return new StatusCodeResult(StatusCodes.Status401Unauthorized);
			}

			if (_workContext.CurrentCustomer.CustomerRoles.Any(cr => cr.SystemName == ExtendedCustomerDefaults.ProvidersRoleName))
			{
				var customerId = _workContext.CurrentCustomer.Id;
				var provider = _providerService.GetProviderByCustomerId(customerId);
				var mediaFiles = _customerMediaFileService.GetMediaFilesByCustomerId(customerId);

				var providerDto = new
				{
					provider.Id,
					provider.Email,
					provider.Name,
					provider.Surname,
					provider.Gender,
					BirthdayDay = provider.DateOfBirthday.Day,
					BirthdayMonth = provider.DateOfBirthday.Month,
					BirthdayYear = provider.DateOfBirthday.Year,
					provider.Country,
					provider.State,
					provider.City,
					provider.PersonalAddress,
					provider.PersonalPhoneNumber,
					provider.CompanyName,
					provider.Address,
					provider.Website,
					provider.WhyShouldCustomerHireYou,
					provider.YourIntroduction,
					provider.Progress,
					provider.PhoneNumber,
					provider.NumberOfEmployees,
					provider.FoundedYear,
					provider.IsIndividualCompany,
					provider.Active,
					provider.BackgroundCheck,
					provider.GalleryDescription,
					Reviews = provider.Reviews.Select(r=>new
					{
						r.Id,
						r.Rating,
						r.Text,
						r.CreatedOnUtc
					}),
					Licenses = provider.Licenses.Select(l => new
					{
						l.Id,
						l.LicenseNumber,
						l.LicenseType,
						l.State
					}).ToList(),
					MediaFiles = mediaFiles.Select(m => new {
						m.Id,
						m.Url,
						m.Name,
						m.Title,
						m.Description
					}).ToArray()
				};
				return new JsonResult(providerDto);
			}

			Response.StatusCode = StatusCodes.Status404NotFound;
			return new JsonResult(null);
		}

		[HttpPost("account/personal-info")]
		public async Task<IActionResult> SetPersonalInfo(ProviderPersonalInfoModel model)
		{
			var success = false;
			var message = string.Empty;

			if (!User.Identity.IsAuthenticated)
			{
				return new JsonResult(new { success, message });
			}

			if (ModelState.IsValid)
			{
				var customerId = _workContext.CurrentCustomer.Id;
				var provider = _providerService.GetProviderByCustomerId(customerId);
				if (provider == null || provider.Id != model.Id)
				{
					return new JsonResult(new { success, message });
				}

				try
				{
					provider.IsIndividualCompany = model.IsIndividualCompany;
					provider.Name = model.Name;
					provider.Surname = model.Surname;
					provider.Gender = model.Gender;
					provider.DateOfBirthday = new DateTime(model.BirthdayYear, model.BirthdayMonth, model.BirthdayDay);
					provider.Country = model.Country;
					provider.City = model.City;
					provider.State = model.State;
					provider.PersonalAddress = model.PersonalAdress;

					provider.CompanyName = string.Empty;

					provider.Progress = provider.Progress | ProviderAccountProgress.PERSONAL_INFO;

					await _providerService.UpdateProviderAsync(provider, synchronize:true);
					success = true;
				}
				catch
				{
					message = "error";
				}
			}

			return new JsonResult(new { success, message });
		}

		[HttpPost("account/individual-info")]
		public async Task<IActionResult> SetIndividualInfo(ProviderIndividualInfoModel model)
		{
			var success = false;
			var message = string.Empty;

			if (!User.Identity.IsAuthenticated)
			{
				return new JsonResult(new { success, message });
			}

			if (ModelState.IsValid)
			{
				var customerId = _workContext.CurrentCustomer.Id;
				var provider = _providerService.GetProviderByCustomerId(customerId);
				if (provider == null || provider.Id != model.Id)
				{
					return new JsonResult(new { success, message });
				}

				try
				{
					provider.PhoneNumber = model.PhoneNumber;
					provider.Website = model.Website;
					provider.FoundedYear = model.FoundedYear;
					provider.Address = model.Address;
					provider.WhyShouldCustomerHireYou = model.WhyShouldCustomerHireYou;
					provider.YourIntroduction = model.YourIntroduction;
					provider.Progress = provider.Progress | ProviderAccountProgress.INDIVIDUAL_INFO;
					provider.GalleryDescription = model.GalleryDescription;

					await _providerService.UpdateProviderAsync(provider);
					success = true;
				}
				catch
				{
					message = "error";
				}
			}

			return new JsonResult(new { success, message });
		}

		[HttpPost("account/business-info")]
		public async Task<IActionResult> SetBusinessInfo(ProviderBusinessInfoModel model)
		{
			var success = false;
			var message = string.Empty;

			if (!User.Identity.IsAuthenticated)
			{
				return new JsonResult(new { success, message });
			}

			if (ModelState.IsValid)
			{
				var customerId = _workContext.CurrentCustomer.Id;
				var provider = _providerService.GetProviderByCustomerId(customerId);
				if (provider == null || provider.Id != model.Id)
				{
					return new JsonResult(new { success, message });
				}

				try
				{
					provider.NumberOfEmployees = model.NumberOfEmployees;
					provider.PhoneNumber = model.PhoneNumber;
					provider.CompanyName = model.CompanyName;
					provider.Website = model.Website;
					provider.FoundedYear = model.FoundedYear;
					provider.Address = model.Address;
					provider.WhyShouldCustomerHireYou = model.WhyShouldCustomerHireYou;
					provider.YourIntroduction = model.YourIntroduction;
					provider.Progress = provider.Progress | ProviderAccountProgress.BUSINESS_INFO;
					await _providerService.UpdateProviderAsync(provider);
					success = true;
				}
				catch
				{
					message = "error";
				}
			}

			return new JsonResult(new { success, message });
		}
		#endregion

		#region Service Items
		[HttpGet("service-items")]
		public IActionResult GetProviderServiceItems()
		{
			var provider = _providerService.GetProviderByCustomerId(_workContext.CurrentCustomer.Id);
			if (provider == null)
			{
				return new StatusCodeResult(StatusCodes.Status403Forbidden);
			}

			var serviceItems = _serviceItemService.GetServiceItemsByProviderId(provider.Id);
			var serviceDtos = serviceItems.Select(s => new {
				s.Id,
				s.Description
			}).ToList();

			return new JsonResult(serviceDtos);
		}

		[HttpGet("service-items/{id?}")]
		public IActionResult GetProviderServiceItemById(int id)
		{
			var provider = _providerService.GetProviderByCustomerId(_workContext.CurrentCustomer.Id);
			var service = _serviceItemService.GetServiceItemById(id);

			var mediaFiles = _serviceItemMediaFileService.GetMediaFilesByServiceItemId(id);

			if (provider == null || service == null || service.ProviderId != provider.Id)
			{
				return new StatusCodeResult(StatusCodes.Status403Forbidden);
			}

			var serviceDto = new
			{
				service.Id,
				service.ServiceInfoId,
				service.ProviderId,
				service.TimeZoneDataId,
				service.Description,
				service.WorkLocationType,
				service.IsRecurringJob,
				service.IsFlexibleAvailability,
				service.FirstTimeDiscountEnabled,
				service.FirstTimeDiscountValue,
				service.WorkingDaysSchedule,
				service.FinishHours,
				service.BeginHours,
				service.MinJobDuration,
				service.JobBookingTime,
				service.BasePriceEnabled,
				service.BasePrice,
				CoverageAreas = service.CoverageAreas.Select(ca => new {
					ca.Id,
					ca.Country,
					ca.Region,
					ca.City,
					ca.Address,
					ca.Latitude,
					ca.Longitude,
					ca.DistanceTravel,
					ca.ZipCode,
					ca.IsServiceLocation
				}).ToList(),
				DiscountRates = service.DiscountRates.Select(dr => new {
					dr.Id,
					dr.RecurringSchedule,
					dr.DiscountRateType,
					dr.OneMonthDiscountEnabled,
					dr.OneMonthDiscountValue,
					dr.TreeMonthDiscountEnabled,
					dr.TreeMonthDiscountValue,
					dr.SixMonthDiscountEnabled,
					dr.SixMonthDiscountValue,
					dr.TwelveMonthDiscountEnabled,
					dr.TwelveMonthDiscountValue,
					dr.ServiceItemId
				}).ToList(),
				Settings = service.Settings.Select(p => new {
					p.Id,
					p.OptionId,
					p.Price,
					p.IsActive,
					p.ServiceItemId
				}).ToList(),
				MediaFiles = mediaFiles.Select(m => new {
					m.Id,
					m.Url,
					m.Name,
					m.Title,
					m.Description
				}).ToList()
			};

			return new JsonResult(serviceDto);
		}

		[HttpPost("service-items/add")]
		public IActionResult AddServiceItem()
		{
			var success = false;
			var message = string.Empty;
			var id = -1;

			var provider = _providerService.GetProviderByCustomerId(_workContext.CurrentCustomer.Id);
			if (provider == null)
			{
				return new JsonResult(new { success, message });
			}

			try
			{
				var serviceItemToAdd = new ServiceItem()
				{
					IsDraft = true,
					ProviderId = provider.Id
				};

				_serviceItemService.InsertServiceItem(serviceItemToAdd);
				id = serviceItemToAdd.Id;
				success = true;
			}
			catch
			{
				success = false;
			}

			return new JsonResult(new { id, success, message });
		}

		[HttpPost("service-items/edit")]
		public IActionResult UpdateServiceItem(ServiceItemEditModel model)
		{
			var success = false;
			var message = string.Empty;

			var provider = _providerService.GetProviderByCustomerId(_workContext.CurrentCustomer.Id);
			if (provider == null)
			{
				return new JsonResult(new { success, message });
			}
			
			var serviceItemToUpdate = _serviceItemService.GetServiceItemById(model.Id);
			if (serviceItemToUpdate == null || serviceItemToUpdate.ProviderId != provider.Id)
			{
				return new JsonResult(new { success, message });
			}

			if(!model.ServiceInfoId.HasValue || !_serviceInfoService.IsExistServiceInfo(model.ServiceInfoId.Value))
			{
				return new JsonResult(new { success, message = "service info not found" });
			}

			if(model.Settings != null)
			{
				var optionIds = model.Settings.Select(s => s.OptionId).ToArray();
				if(optionIds.Distinct().Count() != optionIds.Count())
				{
					return new JsonResult(new { success, message = "invalid service item settings" });
				}
			}

			try
			{
				if (serviceItemToUpdate.IsDraft)
				{
					serviceItemToUpdate.ServiceInfoId = model.ServiceInfoId;
					serviceItemToUpdate.CreatedOnUtc = DateTime.UtcNow;
					serviceItemToUpdate.IsDraft = false;
				}
				serviceItemToUpdate.Description = model.Description;
				serviceItemToUpdate.WorkLocationType = model.WorkLocationType;

				serviceItemToUpdate.BasePriceEnabled = model.BasePriceEnabled;
				serviceItemToUpdate.BasePrice = model.BasePrice;
				serviceItemToUpdate.WorkingDaysSchedule = model.WorkingDaysSchedule;
				serviceItemToUpdate.BeginHours = model.BeginHours;
				serviceItemToUpdate.FinishHours = model.FinishHours;
				serviceItemToUpdate.TimeZoneDataId = model.TimeZoneDataId;
				serviceItemToUpdate.MinJobDuration = model.MinJobDuration;
				serviceItemToUpdate.JobBookingTime = model.JobBookingTime;
				serviceItemToUpdate.IsFlexibleAvailability = model.IsFlexibleAvailability;
				serviceItemToUpdate.IsRecurringJob = model.IsRecurringJob;
				serviceItemToUpdate.FirstTimeDiscountEnabled = model.FirstTimeDiscountEnabled;
				serviceItemToUpdate.FirstTimeDiscountValue = model.FirstTimeDiscountValue;

				if (model.IsRecurringJob)
				{
					if(serviceItemToUpdate.DiscountRates.Count() == 0)
					{
						serviceItemToUpdate.DiscountRates.Add(
							new DiscountRate()
							{
								DiscountRateType = JobDiscountRateType.PERCENTAGE,
								RecurringSchedule = JobScheduleType.EVERY_DAY
							}
						);
						serviceItemToUpdate.DiscountRates.Add(
							new DiscountRate()
							{
								DiscountRateType = JobDiscountRateType.PERCENTAGE,
								RecurringSchedule = JobScheduleType.WEEKLY
							}
						);
						serviceItemToUpdate.DiscountRates.Add(
							new DiscountRate()
							{
								DiscountRateType = JobDiscountRateType.PERCENTAGE,
								RecurringSchedule = JobScheduleType.BIWEEKLY
							}
						);
						serviceItemToUpdate.DiscountRates.Add(
							new DiscountRate()
							{
								DiscountRateType = JobDiscountRateType.PERCENTAGE,
								RecurringSchedule = JobScheduleType.MONTHLY
							}
						);
					}

					// update discount rates
					foreach (var discountRate in model.DiscountRates)
					{
						var discountRateToUpdate = serviceItemToUpdate.DiscountRates.First(d => d.RecurringSchedule == discountRate.RecurringSchedule);

						discountRateToUpdate.DiscountRateType = discountRate.DiscountRateType;
						discountRateToUpdate.ServiceItemId = serviceItemToUpdate.Id;

						discountRateToUpdate.OneMonthDiscountEnabled = discountRate.OneMonthDiscountEnabled;
						discountRateToUpdate.OneMonthDiscountValue = discountRate.OneMonthDiscountValue;

						discountRateToUpdate.TreeMonthDiscountEnabled = discountRate.TreeMonthDiscountEnabled;
						discountRateToUpdate.TreeMonthDiscountValue = discountRate.TreeMonthDiscountValue;

						discountRateToUpdate.SixMonthDiscountEnabled = discountRate.SixMonthDiscountEnabled;
						discountRateToUpdate.SixMonthDiscountValue = discountRate.SixMonthDiscountValue;

						discountRateToUpdate.TwelveMonthDiscountEnabled = discountRate.TwelveMonthDiscountEnabled;
						discountRateToUpdate.TwelveMonthDiscountValue = discountRate.TwelveMonthDiscountValue;
					}
				}

				if(model.Settings != null)
				{
					foreach (var settings in model.Settings)
					{
						var optionSettings = serviceItemToUpdate.Settings.FirstOrDefault(s => s.OptionId == settings.OptionId);
						if (optionSettings == null)
						{
							serviceItemToUpdate.Settings.Add(new ServiceItemSettings()
							{
								ServiceItemId = serviceItemToUpdate.Id,
								OptionId = settings.OptionId,
								IsActive = settings.IsActive,
								Price = settings.Price
							});
						}
						else
						{
							optionSettings.IsActive = settings.IsActive;
							optionSettings.Price = settings.Price;
						}
					}
				}

				serviceItemToUpdate.UpdatedOnUtc = DateTime.UtcNow;
				_serviceItemService.UpdateServiceItem(serviceItemToUpdate);
				success = true;
			}
			catch
			{
				success = false;
			}

			return new JsonResult(new { success, message });
		}

		[HttpPost("service-items/delete/{id?}")]
		public IActionResult DeleteServiceItem(int id)
		{
			var provider = _providerService.GetProviderByCustomerId(_workContext.CurrentCustomer.Id);
			if (provider == null)
			{
				return new StatusCodeResult(StatusCodes.Status403Forbidden);
			}

			var success = false;
			var message = string.Empty;
			var serviceItemToDelete = _serviceItemService.GetServiceItemById(id);
			if (serviceItemToDelete == null || serviceItemToDelete.ProviderId != provider.Id)
			{
				return new StatusCodeResult(StatusCodes.Status403Forbidden);
			}

			try
			{
				_serviceItemService.DeleteServiceItem(serviceItemToDelete);
				success = true;
			}
			catch
			{
				success = false;
			}

			return new JsonResult(new { success, message });
		}
		#endregion

		#region Coverage Areas
		[HttpGet("coverage-areas/{coverageAreaId}")]
		public IActionResult GetCoverageAreaById(int coverageAreaId)
		{
			var provider = _providerService.GetProviderByCustomerId(_workContext.CurrentCustomer.Id);
			var coverageArea = _coverageAreaService.GetCoverageAreaById(coverageAreaId);

			if (provider == null)
			{
				return new StatusCodeResult(StatusCodes.Status403Forbidden);
			}

			if(coverageArea == null)
			{
				return new StatusCodeResult(StatusCodes.Status404NotFound);
			}

			var serviceItem = _serviceItemService.GetServiceItemById(coverageArea.ServiceItemId);
			if (serviceItem == null || serviceItem.ProviderId != provider.Id)
			{
				return new StatusCodeResult(StatusCodes.Status403Forbidden);
			}

			var coverageAreaDto = new
			{
				coverageArea.Id,
				coverageArea.Country,
				coverageArea.Region,
				coverageArea.City,
				coverageArea.Address,
				coverageArea.Latitude,
				coverageArea.Longitude,
				coverageArea.DistanceTravel,
				coverageArea.ZipCode,
				coverageArea.IsServiceLocation
			};
			return new JsonResult(coverageAreaDto);
		}

		[HttpGet("service-items/{serviceItemId}/coverage-areas")]
		public IActionResult GetCoverageAreas(int serviceItemId)
		{
			var provider = _providerService.GetProviderByCustomerId(_workContext.CurrentCustomer.Id);
			var serviceItem = _serviceItemService.GetServiceItemById(serviceItemId);
			if (provider == null || serviceItem == null || serviceItem.ProviderId != provider.Id)
			{
				return new StatusCodeResult(StatusCodes.Status403Forbidden);
			}

			var coverageAreas = _coverageAreaService.GetCoverageAreasByServiceItemId(serviceItemId);
			var coverageAreaDtos = coverageAreas.Select(ca => new {
				ca.Id,
				ca.Country,
				ca.Region,
				ca.City,
				ca.Address,
				ca.Latitude,
				ca.Longitude,
				ca.DistanceTravel,
				ca.ZipCode,
				ca.IsServiceLocation
			}).ToList();

			return new JsonResult(coverageAreaDtos);
		}
		[HttpPost("coverage-areas/add")]
		public IActionResult AddCoverageArea(CoverageAreaAddModel model)
		{
			var provider = _providerService.GetProviderByCustomerId(_workContext.CurrentCustomer.Id);
			var serviceItem = _serviceItemService.GetServiceItemById(model.ServiceItemId);

			if (provider == null || serviceItem == null || serviceItem.ProviderId != provider.Id)
			{
				return new StatusCodeResult(StatusCodes.Status403Forbidden);
			}
			var id = -1;
			var success = false;
			var message = string.Empty;

			var coverageAreaToAdd = new CoverageArea()
			{
				Country = model.Country,
				Region = model.Region,
				City = model.City,
				Address = model.Address,
				ZipCode = model.ZipCode,
				DistanceTravel = model.DistanceTravel,
				Latitude = model.Latitude,
				Longitude = model.Longitude,
				IsServiceLocation = model.IsServiceLocation,
				ServiceItemId = model.ServiceItemId
			};

			try
			{
				_coverageAreaService.InsertCoverageArea(coverageAreaToAdd);
				id = coverageAreaToAdd.Id;
				success = true;
			}
			catch
			{
				success = false;
			}

			return new JsonResult(new { id, success, message });
		}

		[HttpPost("coverage-areas/edit")]
		public IActionResult UpdateCoverageArea(CoverageAreaEditModel model)
		{
			var provider = _providerService.GetProviderByCustomerId(_workContext.CurrentCustomer.Id);
			if (provider == null)
			{
				return new StatusCodeResult(StatusCodes.Status403Forbidden);
			}

			var success = false;
			var message = string.Empty;
			var coverageAreaToUpdate = _coverageAreaService.GetCoverageAreaById(model.Id);
			if (coverageAreaToUpdate != null)
			{
				var serviceItem = _serviceItemService.GetServiceItemById(coverageAreaToUpdate.ServiceItemId);
				if (serviceItem == null || serviceItem.ProviderId == provider.Id)
				{
					return new StatusCodeResult(StatusCodes.Status403Forbidden);
				}

				try
				{
					coverageAreaToUpdate.Country = model.Country;
					coverageAreaToUpdate.Region = model.Region;
					coverageAreaToUpdate.City = model.City;
					coverageAreaToUpdate.Address = model.Address;
					coverageAreaToUpdate.ZipCode = model.ZipCode;
					coverageAreaToUpdate.DistanceTravel = model.DistanceTravel;
					coverageAreaToUpdate.Latitude = model.Latitude;
					coverageAreaToUpdate.Longitude = model.Longitude;
					coverageAreaToUpdate.IsServiceLocation = model.IsServiceLocation;

					_coverageAreaService.UpdateCoverageArea(coverageAreaToUpdate);
					success = true;
				}
				catch
				{
					success = false;
				}
				
			}

			return new JsonResult(new { success, message });
		}

		[HttpPost("coverage-areas/delete/{id?}")]
		public IActionResult DeleteCoverageArea(int id)
		{
			var provider = _providerService.GetProviderByCustomerId(_workContext.CurrentCustomer.Id);
			if (provider == null)
			{
				return new StatusCodeResult(StatusCodes.Status403Forbidden);
			}

			var success = false;
			var message = string.Empty;
			var coverageAreaToDelete = _coverageAreaService.GetCoverageAreaById(id);
			if (coverageAreaToDelete != null)
			{
				var serviceItem = _serviceItemService.GetServiceItemById(coverageAreaToDelete.ServiceItemId);
				if (serviceItem == null || serviceItem.ProviderId == provider.Id)
				{
					return new StatusCodeResult(StatusCodes.Status403Forbidden);

				}
				_coverageAreaService.DeleteCoverageArea(coverageAreaToDelete);
				success = true;
			}

			return new JsonResult(new { success, message });
		}
		#endregion

		#region Licenses
		[HttpGet("licenses/{licenseId}")]
		public IActionResult GetLicenseById(int licenseId)
		{
			var provider = _providerService.GetProviderByCustomerId(_workContext.CurrentCustomer.Id);
			var license = _licenseService.GetLicenseById(licenseId);

			if (provider == null && license == null && provider.Id == license.ProviderId)
			{
				return new StatusCodeResult(StatusCodes.Status403Forbidden);
			}

			var licenseDto = new
			{
				license.Id,
				license.LicenseNumber,
				license.LicenseType,
				license.State
			};
			return new JsonResult(licenseDto);
		}

		[HttpGet("/{providerId}/licenses")]
		public IActionResult GetLicenses(int providerId)
		{
			var provider = _providerService.GetProviderByCustomerId(_workContext.CurrentCustomer.Id);
			if (provider == null)
			{
				return new StatusCodeResult(StatusCodes.Status403Forbidden);
			}

			var licenses = _licenseService.GetLicensesByProviderId(provider.Id);
			var licenseDtos = licenses.Select(l => new {
				l.Id,
				l.LicenseNumber,
				l.LicenseType,
				l.State
			}).ToList();

			return new JsonResult(licenseDtos);
		}
		[HttpPost("licenses/add")]
		public IActionResult AddLicense(LicenseAddModel model)
		{
			var provider = _providerService.GetProviderByCustomerId(_workContext.CurrentCustomer.Id);
			if (provider == null)
			{
				return new StatusCodeResult(StatusCodes.Status403Forbidden);
			}

			var success = false;
			var message = string.Empty;

			var licenseToAdd = new License()
			{
				State = model.State,
				LicenseNumber = model.LicenseNumber,
				LicenseType = model.LicenseType,
				ProviderId = provider.Id
			};

			try
			{
				_licenseService.InsertLicense(licenseToAdd);
				success = true;
			}
			catch
			{
				success = false;
			}

			return new JsonResult(new { success, message });
		}

		[HttpPost("licenses/edit")]
		public IActionResult UpdateLicense(LicenseEditModel model)
		{
			var provider = _providerService.GetProviderByCustomerId(_workContext.CurrentCustomer.Id);
			if (provider == null)
			{
				return new StatusCodeResult(StatusCodes.Status403Forbidden);
			}

			var success = false;
			var message = string.Empty;
			var licenseToUpdate = _licenseService.GetLicenseById(model.Id);
			if (licenseToUpdate != null)
			{
				if (licenseToUpdate == null || licenseToUpdate.ProviderId != provider.Id)
				{
					return new StatusCodeResult(StatusCodes.Status403Forbidden);
				}

				try
				{
					licenseToUpdate.State = model.State;
					licenseToUpdate.LicenseNumber = model.LicenseNumber;
					licenseToUpdate.LicenseType = model.LicenseType;

					_licenseService.UpdateLicense(licenseToUpdate);
					success = true;
				}
				catch
				{
					success = false;
				}

			}

			return new JsonResult(new { success, message });
		}

		[HttpPost("licenses/delete/{id?}")]
		public IActionResult DeleteLicense(int id)
		{
			var provider = _providerService.GetProviderByCustomerId(_workContext.CurrentCustomer.Id);
			if (provider == null)
			{
				return new StatusCodeResult(StatusCodes.Status403Forbidden);
			}

			var success = false;
			var message = string.Empty;
			var licenseToDelete = _licenseService.GetLicenseById(id);
			if (licenseToDelete != null && licenseToDelete.ProviderId == provider.Id)
			{
				_licenseService.DeleteLicense(licenseToDelete);
				success = true;
			}

			return new JsonResult(new { success, message });
		}
		#endregion

		#region Provider Reviews
		[HttpGet("reviews/{reviewId}")]
		public IActionResult GetProviderReviewById(int reviewId)
		{
			var review = _providerReviewService.GetProviderReviewById(reviewId);
			if (review == null)
			{
				return new StatusCodeResult(StatusCodes.Status403Forbidden);
			}

			var reviewDto = new
			{
				review.Id,
				review.Text,
				review.Rating,
				review.UpdatedOnUtc
			};
			return new JsonResult(reviewDto);
		}

		[HttpGet("/{providerId}/reviews")]
		public IActionResult GetProviderReviews(int providerId)
		{
			var reviews = _providerReviewService.GetProviderReviewsByProviderId(providerId);
			var providerReviewDtos = reviews.Select(p => new {
				p.Id,
				p.Text,
				p.Rating,
				p.UpdatedOnUtc
			}).ToList();

			return new JsonResult(providerReviewDtos);
		}
		[HttpPost("reviews/add")]
		public IActionResult AddProviderReview(ProviderReviewAddModel model)
		{
			var success = false;
			var message = string.Empty;
			var id = -1;

			var providerReviewToAdd = new ProviderReview()
			{
				ProviderId = model.ProviderId,
				CustomerId = _workContext.CurrentCustomer.Id,
				Text = model.Text,
				Rating = model.Rating,
				CreatedOnUtc = DateTime.UtcNow,
				UpdatedOnUtc = DateTime.UtcNow,
			};

			try
			{
				_providerReviewService.InsertProviderReview(providerReviewToAdd);
				id = providerReviewToAdd.Id;
				success = true;
			}
			catch
			{
				success = false;
			}

			return new JsonResult(new { id, success, message });
		}

		[HttpPost("reviews/edit")]
		public IActionResult UpdateProviderReview(ProviderReviewEditModel model)
		{
			var success = false;
			var message = string.Empty;
			var reviewToUpdate = _providerReviewService.GetProviderReviewById(model.Id);
			if (reviewToUpdate != null)
			{
				if (reviewToUpdate == null || reviewToUpdate.CustomerId != _workContext.CurrentCustomer.Id)
				{
					return new StatusCodeResult(StatusCodes.Status403Forbidden);
				}

				try
				{
					reviewToUpdate.Text = model.Text;
					reviewToUpdate.Rating = model.Rating;
					reviewToUpdate.UpdatedOnUtc = DateTime.UtcNow;
					_providerReviewService.UpdateProviderReview(reviewToUpdate);
					success = true;
				}
				catch
				{
					success = false;
				}

			}

			return new JsonResult(new { success, message });
		}

		[HttpPost("reviews/delete/{id?}")]
		public IActionResult DeleteProviderReview(int id)
		{
			var success = false;
			var message = string.Empty;
			var providerReviewToDelete = _providerReviewService.GetProviderReviewById(id);
			if (providerReviewToDelete != null && providerReviewToDelete.CustomerId == _workContext.CurrentCustomer.Id)
			{
				_providerReviewService.DeleteProviderReview(providerReviewToDelete);
				success = true;
			}

			return new JsonResult(new { success, message });
		}
		#endregion

		#region Uploaders

		[HttpPost("service-items/{serviceItemId}/icon")]
		public async Task<IActionResult> SaveServiceItemIcon(int serviceItemId, IFormFile file)
		{
			var success = false;
			var errorMessage = string.Empty;

			try
			{
				var provider = _providerService.GetProviderByCustomerId(_workContext.CurrentCustomer.Id);
				if (provider == null)
				{
					return new JsonResult(new { success, errorMessage });
				}

				var serviceItemToUpdate = _serviceItemService.GetServiceItemById(serviceItemId);
				if (serviceItemToUpdate == null || serviceItemToUpdate.ProviderId != provider.Id)
				{
					return new JsonResult(new { success, errorMessage });
				}

				if (!FileValidator.ValidateIcon(file, ref errorMessage))
				{
					return new JsonResult(new { success, errorMessage });
				}

				if (serviceItemToUpdate.Icon != null)
				{
					await _serviceItemMediaFileService.DeleteServiceItemIconAsync(serviceItemToUpdate.Icon);
				}

				await _serviceItemMediaFileService.InsertServiceItemIconAsync(serviceItemId, file);
				success = true;
			}
			catch
			{
				errorMessage = "error";
			}


			return new JsonResult(new { success, errorMessage });
		}

		[HttpDelete("service-items/{serviceItemId}/icon")]
		public async Task<IActionResult> DeleteServiceItemIcon(int serviceItemId)
		{
			var success = false;
			var errorMessage = string.Empty;

			try
			{
				var provider = _providerService.GetProviderByCustomerId(_workContext.CurrentCustomer.Id);
				if (provider == null)
				{
					return new JsonResult(new { success, errorMessage });
				}

				var serviceItemToUpdate = _serviceItemService.GetServiceItemById(serviceItemId);
				if (serviceItemToUpdate == null || serviceItemToUpdate.ProviderId != provider.Id)
				{
					return new JsonResult(new { success, errorMessage });
				}

				if (serviceItemToUpdate.Icon != null)
				{
					await _serviceItemMediaFileService.DeleteServiceItemIconAsync(serviceItemToUpdate.Icon);
				}
				success = true;
			}
			catch
			{
				errorMessage = "error";
			}

			return new JsonResult(new { success, errorMessage });
		}

		[HttpPost("service-items/{serviceItemId}/media")]
		public async Task<IActionResult> SaveServiceItemMediaFile(int serviceItemId, IFormFile file)
		{
			var success = false;
			var errorMessage = string.Empty;

			try
			{
				var provider = _providerService.GetProviderByCustomerId(_workContext.CurrentCustomer.Id);
				if (provider == null)
				{
					return new JsonResult(new { success, errorMessage });
				}

				var serviceItemToUpdate = _serviceItemService.GetServiceItemById(serviceItemId);
				if (serviceItemToUpdate == null || serviceItemToUpdate.ProviderId != provider.Id)
				{
					return new JsonResult(new { success, errorMessage });
				}

				if (!FileValidator.ValidateMediaFile(file, ref errorMessage))
				{
					return new JsonResult(new { success, errorMessage });
				}

				await _serviceItemMediaFileService.InsertServiceItemMediaFileAsync(serviceItemId, file);
				success = true;

			}
			catch
			{
				errorMessage = "error";
			}

			return new JsonResult(new { success, errorMessage });
		}

		[HttpDelete("service-items/{serviceItemId}/media/{Id}")]
		public async Task<IActionResult> DeleteServiceItemMediaFile(int serviceItemId, int id)
		{
			var success = false;
			var errorMessage = string.Empty;

			try
			{
				var provider = _providerService.GetProviderByCustomerId(_workContext.CurrentCustomer.Id);
				if (provider == null)
				{
					return new JsonResult(new { success, errorMessage });
				}

				var serviceItemToUpdate = _serviceItemService.GetServiceItemById(serviceItemId);
				if (serviceItemToUpdate == null || serviceItemToUpdate.ProviderId != provider.Id)
				{
					return new JsonResult(new { success, errorMessage });
				}

				var mediaFile = _serviceItemMediaFileService.GetServiceItemMediaFileById(id);
				if (mediaFile != null)
				{
					await _serviceItemMediaFileService.DeleteServiceItemMediaFileAsync(mediaFile);
				}
				success = true;
			}
			catch
			{
				errorMessage = "error";
			}

			return new JsonResult(new { success, errorMessage });
		}
		#endregion
	}
}
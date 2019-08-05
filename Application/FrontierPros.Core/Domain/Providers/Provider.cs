using FrontierPros.Core.Domain.Licenses;
using FrontierPros.Core.Domain.Services;
using Nop.Core;
using Nop.Core.Domain.Customers;
using Nop.Core.Domain.Stores;
using System;
using System.Collections.Generic;
using System.Text;

namespace FrontierPros.Core.Domain.Providers
{
	[Flags]
	public enum ProviderAccountProgress
	{
		NONE = 0,
		PHONE_CONFIRMATION = 1,
		PERSONAL_INFO = 2,
		INDIVIDUAL_INFO = 4,
		BUSINESS_INFO = 8,
	}
	public class Provider : BaseEntity
	{
		private ICollection<ProviderReview> _reviews;
		private ICollection<ServiceItem> _services;
		private ICollection<License> _licenses;
		private ICollection<ProviderAndServiceProvider> _serviceProviders;


		#region Personal Info
		public string Name { get; set; }
		public string Surname { get; set; }
		public string Gender { get; set; }
		public DateTime DateOfBirthday { get; set; }
		public string Country { get; set; }
		public string City { get; set; }
		public string State { get; set; }
		public string PersonalAddress { get; set; }
		public string PersonalPhoneNumber { get; set; }
		public string Email { get; set; }
		#endregion

		public string WhyShouldCustomerHireYou { get; set; }
		public string YourIntroduction { get; set; }

		public bool IsIndividualCompany { get; set; }
		public string CompanyName { get; set; }
		public string Address { get; set; }
		public string PhoneNumber { get; set; }
		public string Website { get; set; }
		public int? FoundedYear { get; set; }
		public int? NumberOfEmployees { get; set; }

		public ProviderAccountProgress Progress {get;set;}
		public bool Active { get; set; }
		public bool BackgroundCheck { get; set; }

		public string GalleryDescription { get; set; }

        public int CustomerId { get; set; }
        public int StoreId { get; set; }
		public virtual Store Store { get; set; }
        public virtual Customer Customer { get; set; }
		public virtual ICollection<ServiceItem> Services
		{
			get => _services ?? (_services = new List<ServiceItem>());
			protected set => _services = value;
		}

		public virtual ICollection<ProviderAndServiceProvider> ServiceProviders
		{
			get => _serviceProviders ?? (_serviceProviders = new List<ProviderAndServiceProvider>());
			protected set => _serviceProviders = value;
		}

		public virtual ICollection<License> Licenses
		{
			get => _licenses ?? (_licenses = new List<License>());
			protected set => _licenses = value;
		}

		public virtual ICollection<ProviderReview> Reviews
		{
			get => _reviews ?? (_reviews = new List<ProviderReview>());
			protected set => _reviews = value;
		}

	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrontierPros.Core.Domain.Providers;
using Nop.Core;
using Nop.Core.Data;
using Nop.Core.Domain.Catalog;
using Nop.Services.Catalog;

namespace FrontierPros.Services.Providers
{
	public class ProviderReviewService : IProviderReviewService
	{
		#region Fields
		private readonly IRepository<ProviderReview> _providerReviewRepository;
		#endregion

		#region Ctor

		public ProviderReviewService(IRepository<ProviderReview> providerReviewRepository)
		{
			this._providerReviewRepository = providerReviewRepository;
		}

		#endregion

		#region Methods
		public ProviderReview GetProviderReviewById(int licenseId)
		{
			return _providerReviewRepository.GetById(licenseId);
		}

		public IList<ProviderReview> GetProviderReviewsByProviderId(int providerId)
		{
			var query = _providerReviewRepository.Table;

			query = query.Where(ca => ca.ProviderId == providerId);

			return query.ToList();
		}

		public void InsertProviderReview(ProviderReview providerReview)
		{
			if (providerReview == null)
				throw new ArgumentNullException(nameof(providerReview));

			_providerReviewRepository.Insert(providerReview);
		}

		public void UpdateProviderReview(ProviderReview providerReview)
		{
			if (providerReview == null)
				throw new ArgumentNullException(nameof(providerReview));

			_providerReviewRepository.Update(providerReview);
		}

		public void DeleteProviderReview(ProviderReview providerReview)
		{
			if (providerReview == null)
				throw new ArgumentNullException(nameof(providerReview));

			_providerReviewRepository.Delete(providerReview);
		}
		#endregion

	}
}

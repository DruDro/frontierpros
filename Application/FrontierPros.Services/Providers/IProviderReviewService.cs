using FrontierPros.Core.Domain.Licenses;
using FrontierPros.Core.Domain.Providers;
using FrontierPros.Core.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace FrontierPros.Services.Providers
{
	public interface IProviderReviewService
	{
		ProviderReview GetProviderReviewById(int providerReviewId);
		IList<ProviderReview> GetProviderReviewsByProviderId(int providerId);

		void InsertProviderReview(ProviderReview providerReview);
		void UpdateProviderReview(ProviderReview providerReview);
		void DeleteProviderReview(ProviderReview ProviderReview);
	}
}

using FrontierPros.Core.Domain.Services;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FrontierPros.Services.Services
{
	public interface IServiceItemMediaFileService
	{
		ServiceItemMediaFile GetServiceItemMediaFileById(int fileId);

		List<ServiceItemMediaFile> GetMediaFilesByServiceItemId(int serviceItemId);

		Task InsertServiceItemIconAsync(int serviceItemId, IFormFile file);
		Task DeleteServiceItemIconAsync(ServiceItemMediaFile mediaFile);

		Task InsertServiceItemMediaFileAsync(int serviceItemId, IFormFile file);
		Task DeleteServiceItemMediaFileAsync(ServiceItemMediaFile mediaFile);
	}
}

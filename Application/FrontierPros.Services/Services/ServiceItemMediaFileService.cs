using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FrontierPros.Core.Domain.Customers;
using FrontierPros.Core.Domain.Services;
using FrontierPros.Data;
using FrontierPros.Services.Storage;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Nop.Core;
using Nop.Core.Data;
using Nop.Core.Domain.Catalog;
using Nop.Services.Catalog;

namespace FrontierPros.Services.Services
{
	public class ServiceItemMediaFileService : IServiceItemMediaFileService
	{
		#region Fields
		private readonly IRepository<ServiceItem> _serviceItemRepository;
		private readonly IRepository<ServiceItemMediaFile> _serviceItemMediaFileRepository;
		private readonly IStorageService _storageService;
		#endregion

		#region Ctor

		public ServiceItemMediaFileService(IRepository<ServiceItem> serviceItemRepository,
										IRepository<ServiceItemMediaFile> serviceItemMediaFileRepository, 
										IStorageService storageService)
		{
			this._serviceItemRepository = serviceItemRepository;
			this._serviceItemMediaFileRepository = serviceItemMediaFileRepository;
			this._storageService = storageService;
		}

		#endregion

		#region Methods
		public virtual ServiceItemMediaFile GetServiceItemMediaFileById(int id)
		{
			return _serviceItemMediaFileRepository.GetById(id);
		}

		public virtual List<ServiceItemMediaFile> GetMediaFilesByServiceItemId(int serviceItemId)
		{
			return _serviceItemMediaFileRepository.Table.Where(m => m.ServiceItemId == serviceItemId && m.Type == MediaType.MEDIA).ToList();
		}

		public virtual async Task InsertServiceItemIconAsync(int serviceItemId, IFormFile file)
		{
			var ext = GetFileExtention(file);
			var blobName = $"icon_{serviceItemId.ToString()}_{Guid.NewGuid().ToString()}{ext}";

			var blobBlock = await _storageService.SaveServiceItemIconAsync(blobName, file);
			var mediaFile = new ServiceItemMediaFile()
			{
				BlobName = blobBlock.Name,
				Name = file.FileName,
				Type = MediaType.ICON,
				Url = blobBlock.Uri.AbsoluteUri,
				ServiceItemId = serviceItemId
			};

			_serviceItemMediaFileRepository.Insert(mediaFile);

			var serviceItem = _serviceItemRepository.GetById(serviceItemId);
			serviceItem.IconId = mediaFile.Id;
			_serviceItemRepository.Update(serviceItem);
		}
		public virtual async Task DeleteServiceItemIconAsync(ServiceItemMediaFile mediaFile)
		{
			if (mediaFile == null)
				throw new ArgumentNullException(nameof(mediaFile));

			await _storageService.DeleteServiceItemIconAsync(mediaFile.BlobName);
			_serviceItemMediaFileRepository.Delete(mediaFile);
		}

		public virtual async Task InsertServiceItemMediaFileAsync(int serviceItemId, IFormFile file)
		{
			var ext = GetFileExtention(file);
			var blobName = $"media_{serviceItemId.ToString()}_{Guid.NewGuid().ToString()}{ext}";

			var blobBlock = await _storageService.SaveMediaAsync(blobName, file);
			var mediaFile = new ServiceItemMediaFile()
			{
				BlobName = blobBlock.Name,
				Name = file.FileName,
				Type = MediaType.MEDIA,
				Url = blobBlock.Uri.AbsoluteUri,
				ServiceItemId = serviceItemId
			};

			_serviceItemMediaFileRepository.Insert(mediaFile);
		}

		public virtual async Task DeleteServiceItemMediaFileAsync(ServiceItemMediaFile mediaFile)
		{
			if (mediaFile == null)
				throw new ArgumentNullException(nameof(mediaFile));

			await _storageService.DeleteMediaAsync(mediaFile.BlobName);
			_serviceItemMediaFileRepository.Delete(mediaFile);
		}

		private string GetFileExtention(IFormFile file)
		{
			var ext = string.Empty;
			var lastIndexOfDot = file.FileName.LastIndexOf(".");
			if (lastIndexOfDot > 0)
			{
				ext = file.FileName.Substring(lastIndexOfDot, file.FileName.Length - lastIndexOfDot);
			}
			return ext;
		}
		#endregion

	}
}

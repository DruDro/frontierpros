using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FrontierPros.Core.Domain.Customers;
using FrontierPros.Services.Storage;
using Microsoft.AspNetCore.Http;
using Nop.Core.Data;

namespace FrontierPros.Services.Customers
{
	public class CustomerMediaFileService : ICustomerMediaFileService
	{
		#region Fields
		private readonly IRepository<CustomerMediaFile> _customerMediaFileRepository;
		private readonly IStorageService _storageService;
		#endregion

		#region Ctor

		public CustomerMediaFileService(IRepository<CustomerMediaFile> customerMediaFileRepository, 
										IStorageService storageService)
		{
			this._customerMediaFileRepository = customerMediaFileRepository;
			this._storageService = storageService;
		}

		#endregion

		#region Methods
		public virtual CustomerMediaFile GetCustomerMediaFileById(int id)
		{
			return _customerMediaFileRepository.GetById(id);
		}

		public virtual List<CustomerMediaFile> GetMediaFilesByCustomerId(int customerId)
		{
			return _customerMediaFileRepository.Table.Where(media => media.Type == MediaType.MEDIA && media.CustomerId == customerId).ToList();
		}

		public virtual async Task InsertCustomerIconAsync(int customerId, IFormFile file)
		{
			var ext = GetFileExtention(file);
			var blobName = $"icon_{customerId.ToString()}_{Guid.NewGuid().ToString()}{ext}";

			var blobBlock = await _storageService.SaveCustomerIconAsync(blobName, file);
			var mediaFile = new CustomerMediaFile()
			{
				BlobName = blobBlock.Name,
				Name = file.FileName,
				Type = MediaType.ICON,
				Url = blobBlock.Uri.AbsoluteUri,
				CustomerId = customerId
			};

			_customerMediaFileRepository.Insert(mediaFile);
		}

		public virtual async Task DeleteCustomerIconAsync(int customerId)
		{
			var customerIcons = _customerMediaFileRepository.Table.Where(ci => ci.CustomerId == customerId).ToList();
			foreach(var icon in customerIcons)
			{
				await _storageService.DeleteCustomerIconAsync(icon.BlobName);
			}
			_customerMediaFileRepository.Delete(customerIcons);
		}

		public virtual async Task<CustomerMediaFile> InsertCustomerMediaFileAsync(int customerId, CustomerFileModel model)
		{
			var mediaFile = new CustomerMediaFile()
			{
				Type = MediaType.MEDIA,
				CustomerId = customerId,
				Title = model.Title,
				Description = model.Description
			};


			if (model.File != null)
			{
				var ext = GetFileExtention(model.File);
				var blobName = $"media_{customerId.ToString()}_{Guid.NewGuid().ToString()}{ext}";

				var blobBlock = await _storageService.SaveCustomerMediaAsync(blobName, model.File);

				mediaFile.Name = model.File.FileName;
				mediaFile.BlobName = blobBlock.Name;
				mediaFile.Url = blobBlock.Uri.AbsoluteUri;
			}
			else
			{
				mediaFile.Name = model.ExternalUrl;
				mediaFile.Url = model.ExternalUrl;
			}

			_customerMediaFileRepository.Insert(mediaFile);

			return mediaFile;
		}

		public CustomerMediaFile UpdateCustomerMediaFile(CustomerEditMediaFileModel model)
		{
			var mediaFile = _customerMediaFileRepository.GetById(model.Id);

			if (mediaFile == null)
				throw new ArgumentException("Media file with such Id doesn't exist");

			mediaFile.Title = model.Title;
			mediaFile.Description = model.Description;

			_customerMediaFileRepository.Update(mediaFile);

			return mediaFile;
		}

		public virtual async Task DeleteCustomerMediaFileAsync(CustomerMediaFile mediaFile)
		{
			if (mediaFile == null)
				throw new ArgumentNullException(nameof(mediaFile));

			await _storageService.DeleteCustomerMediaAsync(mediaFile.BlobName);
			_customerMediaFileRepository.Delete(mediaFile);
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

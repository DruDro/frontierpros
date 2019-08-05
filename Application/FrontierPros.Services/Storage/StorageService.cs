using Microsoft.AspNetCore.Http;
using Microsoft.WindowsAzure.Storage.Blob;
using System.Threading.Tasks;

namespace FrontierPros.Services.Storage
{
	public static partial class ContainerNames
	{
		public static string ProfileIcons => "profile-icons";
		public static string ProfileMedia => "profile-media-files";
		public static string ServiceItemIcons => "service-item-icons";
		public static string ServiceItemMedia => "service-item-media-files";
	}

	public class StorageService : IStorageService
	{
		#region Fields
		private readonly IBlobStorageService _blobStorageService;
		#endregion

		#region Ctor
		public StorageService(IBlobStorageService blobStorageService)
		{
			_blobStorageService = blobStorageService;
		}

		#endregion

		#region Methods
		#region Service Items
		public async Task<CloudBlockBlob> SaveServiceItemIconAsync(string blobName, IFormFile file)
		{
			CloudBlockBlob result = null;

			using (var stream = file.OpenReadStream())
			{
				result = await _blobStorageService.AddOrUpdateAsync(blobName, ContainerNames.ServiceItemIcons, stream, replaceIfExists: true);
			}
			return result;
		}

		public async Task<bool> DeleteServiceItemIconAsync(string blobName)
		{
			return await _blobStorageService.RemoveAsync(blobName, ContainerNames.ServiceItemIcons);
		}


		public async Task<CloudBlockBlob> SaveMediaAsync(string blobName, IFormFile file)
		{
			CloudBlockBlob result = null;

			using (var stream = file.OpenReadStream())
			{
				result = await _blobStorageService.AddOrUpdateAsync(blobName, ContainerNames.ServiceItemMedia, stream, replaceIfExists: false);
			}
			return result;
		}

		public async Task<bool> DeleteMediaAsync(string blobName)
		{
			return await _blobStorageService.RemoveAsync(blobName, ContainerNames.ServiceItemMedia);
		}
		#endregion

		#region Profile
		public async Task<CloudBlockBlob> SaveCustomerIconAsync(string blobName, IFormFile inputFile)
		{
			CloudBlockBlob result = null;

			using (var stream = inputFile.OpenReadStream())
			{
				result = await _blobStorageService.AddOrUpdateAsync(blobName, ContainerNames.ProfileIcons, stream, replaceIfExists: true);
			}

			return result;
		}

		public async Task<bool> DeleteCustomerIconAsync(string blobName)
		{
			return await _blobStorageService.RemoveAsync(blobName, ContainerNames.ProfileIcons);
		}

		public async Task<CloudBlockBlob> SaveCustomerMediaAsync(string blobName, IFormFile file)
		{
			CloudBlockBlob result = null;

			using (var stream = file.OpenReadStream())
			{
				result = await _blobStorageService.AddOrUpdateAsync(blobName, ContainerNames.ProfileMedia, stream, replaceIfExists: false);
			}
			return result;
		}

		public async Task<bool> DeleteCustomerMediaAsync(string blobName)
		{
			return await _blobStorageService.RemoveAsync(blobName, ContainerNames.ProfileMedia);
		}
		#endregion
		#endregion
	}
}

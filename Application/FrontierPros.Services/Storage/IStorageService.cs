using Microsoft.AspNetCore.Http;
using Microsoft.WindowsAzure.Storage.Blob;
using System.Threading.Tasks;

namespace FrontierPros.Services.Storage
{
	public interface IStorageService
	{
		Task<CloudBlockBlob> SaveServiceItemIconAsync(string blobName, IFormFile file);
		Task<bool> DeleteServiceItemIconAsync(string blobName);

		Task<CloudBlockBlob> SaveMediaAsync(string blobName, IFormFile file);
		Task<bool> DeleteMediaAsync(string blobName);

		Task<CloudBlockBlob> SaveCustomerIconAsync(string blobName, IFormFile file);
		Task<bool> DeleteCustomerIconAsync(string blobName);
		Task<CloudBlockBlob> SaveCustomerMediaAsync(string blobName, IFormFile file);
		Task<bool> DeleteCustomerMediaAsync(string blobName);
	}
}

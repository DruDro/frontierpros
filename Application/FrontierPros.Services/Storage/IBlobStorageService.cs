using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.IO;
using System.Threading.Tasks;

namespace FrontierPros.Services.Storage
{
	public interface IBlobStorageService
	{
		Task<CloudBlockBlob> AddOrUpdateAsync(string blobName, string containerName, Stream stream, bool replaceIfExists);
		Task<bool> RemoveAsync(string blobName, string containerName);
		Task<Uri> GetAbsoluteUriAsync(string blobName, string containerName);
		Task<byte[]> GetFileBytesAsync(string blobName, string containerName);
	}
}

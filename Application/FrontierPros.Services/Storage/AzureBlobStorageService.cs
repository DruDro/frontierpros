using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace FrontierPros.Services.Storage
{
	public class AzureBlobStorageService : IBlobStorageService
	{
		protected static string _connectionString;
		public static void Init(string connectionString)
		{
			_connectionString = connectionString;
			if (_connectionString == null) throw new InvalidOperationException("Connection string was not initialized");
		}

		private CloudStorageAccount _storageAccount;
		private CloudBlobClient _client;

		public AzureBlobStorageService()
		{
			_storageAccount = CloudStorageAccount.Parse(_connectionString);
			_client = _storageAccount.CreateCloudBlobClient();
		}

		public async Task<MemoryStream> GetAsync(string blobName, string containerName)
		{
			try
			{
				var container = await GetContainerAsync(containerName);

				var blobBlock = container.GetBlockBlobReference(blobName);

				using (var stream = new MemoryStream())
				{
					await blobBlock.DownloadToStreamAsync(stream);
					stream.Position = 0;

					return new MemoryStream(ReadStream(stream));
				}
			}
			catch (Exception ex)
			{
				return null;
			}
		}
		public async Task<byte[]> GetFileBytesAsync(string blobName, string containerName)
		{
			var container = await GetContainerAsync(containerName);
			CloudBlockBlob blockBlob = container.GetBlockBlobReference(blobName);
			if (!await blockBlob.ExistsAsync()) return null;

			var fileByteLength = blockBlob.Properties.Length;

			byte[] fileContent = new byte[fileByteLength];
			await blockBlob.DownloadToByteArrayAsync(fileContent, 0);
			return fileContent;
		}
		public async Task<Uri> GetAbsoluteUriAsync(string blobName, string containerName)
		{
			var container = await GetContainerAsync(containerName);

			var reference = container.GetBlobReference(blobName);
			if (!await reference.ExistsAsync()) return null;

			return reference.Uri;
		}

		public async Task<CloudBlockBlob> AddOrUpdateAsync(string blobName, string containerName, Stream stream, bool replaceIfExists = false)
		{
			try
			{
				var container = await GetContainerAsync(containerName);

				var blobBlock = container.GetBlockBlobReference(blobName);
				if (await blobBlock.ExistsAsync() && !replaceIfExists)
				{
					int version = 1;
					while (await blobBlock.ExistsAsync())
					{
						if (blobBlock.Name.IndexOf("_v") != -1)
						{
							blobBlock = container.GetBlockBlobReference(string.Format("{0}_v{1}", blobName.Substring(0, blobBlock.Name.IndexOf("_v")), version));
						}
						else
						{
							blobBlock = container.GetBlockBlobReference(string.Format("{0}_v{1}", blobName, version));
						}
						version++;
					}
				}

				await blobBlock.UploadFromStreamAsync(stream);

				return blobBlock;
			}
			catch (Exception ex)
			{
				return null;
			}
		}

		public async Task<bool> RemoveAsync(string blobName, string containerName)
		{
			try
			{
				var container = await GetContainerAsync(containerName);
				var reference = container.GetBlobReference(blobName);
				return await reference.DeleteIfExistsAsync();
			}
			catch (Exception)
			{
				return false;
			}
		}

		private async Task<CloudBlobContainer> GetContainerAsync(string containerName)
		{
			var container = _client.GetContainerReference(containerName);
			if (!await container.ExistsAsync())
			{
				await container.CreateAsync();
			}
			await container.SetPermissionsAsync(new BlobContainerPermissions
			{
				PublicAccess = BlobContainerPublicAccessType.Blob
			});
			return container;
		}

		private byte[] ReadStream(Stream input)
		{
			byte[] buffer = new byte[16 * 1024];
			using (var ms = new MemoryStream())
			{
				int read;
				while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
				{
					ms.Write(buffer, 0, read);
				}
				return ms.ToArray();

			}
		}
	}
}

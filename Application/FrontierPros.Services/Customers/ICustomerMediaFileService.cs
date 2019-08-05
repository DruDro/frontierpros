using FrontierPros.Core.Domain.Customers;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FrontierPros.Services.Customers
{
	public interface ICustomerMediaFileService
	{
		CustomerMediaFile GetCustomerMediaFileById(int id);
		List<CustomerMediaFile> GetMediaFilesByCustomerId(int customerId);

		Task InsertCustomerIconAsync(int customerId, IFormFile file);
		Task DeleteCustomerIconAsync(int customerId);

		Task<CustomerMediaFile> InsertCustomerMediaFileAsync(int customerId, CustomerFileModel model);
		CustomerMediaFile UpdateCustomerMediaFile(CustomerEditMediaFileModel model);
		Task DeleteCustomerMediaFileAsync(CustomerMediaFile mediaFile);
	}
}

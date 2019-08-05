using FrontierPros.Core.Attributes;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace FrontierPros.Core.Domain.Customers
{
	public class CustomerFileModel
	{
		[RequiredIf("ExternalUrl", "")]
		public IFormFile File { get; set; }
		[RequiredIf("File", null)]
		public string ExternalUrl { get; set; }
		[Required]
		public string Title { get; set; }
		public string Description { get; set; }
	}
}

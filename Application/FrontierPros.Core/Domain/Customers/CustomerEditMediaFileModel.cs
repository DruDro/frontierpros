using System.ComponentModel.DataAnnotations;

namespace FrontierPros.Core.Domain.Customers
{
	public class CustomerEditMediaFileModel
	{
		[Required]
		public int Id { get; set; }
		[Required]
		public string Title { get; set; }
		public string Description { get; set; }
	}
}

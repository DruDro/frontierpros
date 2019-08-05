namespace Nop.Web.Models.Services
{
	public class ServiceItemSettingsModel
	{
		public int Id { get; set; }
		public bool IsActive { get; set; }
		public int OptionId { get; set; }
		public decimal? Price { get; set; }
	}
}
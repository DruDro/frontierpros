namespace Nop.Web.Models.Services
{
	public class PageModel
	{
		public int PageIndex { get; set; } = 0;
		public int PageSize { get; set; } = int.MaxValue;
	}
}

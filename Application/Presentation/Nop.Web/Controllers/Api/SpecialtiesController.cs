using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FrontierPros.Core.Domain.Specialties;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nop.Core.Data;
using Nop.Data;

namespace Nop.Web.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecialtiesController : ControllerBase
    {
		private readonly IRepository<Specialty> _specialtyRepository;

		public SpecialtiesController(IRepository<Specialty> specialtyRepository)
		{
			this._specialtyRepository = specialtyRepository;
		}

		public IActionResult Index()
		{
			var specialties = _specialtyRepository.TableNoTracking.Include(s => s.Options).OrderBy(s=>s.ServiceInfoId).ThenBy(s => s.Order).Select(s => new {
				s.Id,
				s.Heading,
				Options = s.Options.Select(o => new {
					o.Id,
					o.Text
				}).ToArray()
			}).ToArray();
			return new JsonResult(specialties);
		}
	}
}
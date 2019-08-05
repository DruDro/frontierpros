using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FrontierPros.Data
{
	public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<FrontierProsObjectContext>
	{
		public FrontierProsObjectContext CreateDbContext(string[] args)
		{
			var builder = new DbContextOptionsBuilder<FrontierProsObjectContext>();
			var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

			builder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), options => options.EnableRetryOnFailure());
			return new FrontierProsObjectContext(builder.Options);
		}
	}
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace FrontierPros.Data.Migrations
{
    public partial class AddedGetDistanceFunction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
			migrationBuilder.Sql(@"IF OBJECT_ID('dbo.[getDistance]') IS NOT NULL
									DROP FUNCTION dbo.[getDistance]
								GO

								CREATE FUNCTION [dbo].[getDistance] (@LAT1 FLOAT, @LONG1 FLOAT, @LAT2 FLOAT, @LONG2 FLOAT)
								RETURNS FLOAT
								AS BEGIN
									DECLARE @GEO1 geography, @GEO2 geography
									SET @GEO1 = geography::Point(ISNULL(@LAT1,0), ISNULL(@LONG1,0), 4326)
									SET @GEO2 = geography::Point(ISNULL(@LAT2,0), ISNULL(@LONG2,0), 4326)
									RETURN @GEO1.STDistance(@GEO2)/1000
								END");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
			migrationBuilder.Sql(@"IF OBJECT_ID('dbo.[getDistance]') IS NOT NULL
									DROP FUNCTION dbo.[getDistance]");

		}
    }
}

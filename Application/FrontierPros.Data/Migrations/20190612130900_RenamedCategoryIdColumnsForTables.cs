using Microsoft.EntityFrameworkCore.Migrations;

namespace FrontierPros.Data.Migrations
{
    public partial class RenamedCategoryIdColumnsForTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AddonSource_ServiceInfoSource_CategoryInfoSourceId",
                table: "AddonSource");

            migrationBuilder.DropForeignKey(
                name: "FK_ProviderQuestion_ServiceInfo_CategoryInfoId",
                table: "ProviderQuestion");

            migrationBuilder.DropForeignKey(
                name: "FK_ProviderQuestionSource_ServiceInfoSource_CategoryInfoSourceId",
                table: "ProviderQuestionSource");

            migrationBuilder.DropForeignKey(
                name: "FK_Question_ServiceInfo_CategoryInfoId",
                table: "Question");

            migrationBuilder.DropForeignKey(
                name: "FK_QuestionSource_ServiceInfoSource_CategoryInfoSourceId",
                table: "QuestionSource");

            migrationBuilder.DropForeignKey(
                name: "FK_Service_ServiceInfo_CategoryInfoId",
                table: "Service");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceCategorySourceAndServiceInfoSource_ServiceInfoSource_CategoryInfoSourceId",
                table: "ServiceCategorySourceAndServiceInfoSource");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceCategorySourceAndServiceInfoSource_ServiceCategorySource_GroupSourceId",
                table: "ServiceCategorySourceAndServiceInfoSource");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceInfoAndNameToken_ServiceInfo_CategoryInfoId",
                table: "ServiceInfoAndNameToken");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceInfoSourceAndNameTokenSource_ServiceInfoSource_CategoryInfoSourceId",
                table: "ServiceInfoSourceAndNameTokenSource");

            migrationBuilder.DropForeignKey(
                name: "FK_Specialty_ServiceInfo_CategoryInfoId",
                table: "Specialty");

            migrationBuilder.DropForeignKey(
                name: "FK_SpecialtySource_ServiceInfoSource_CategoryInfoSourceId",
                table: "SpecialtySource");

            migrationBuilder.RenameColumn(
                name: "CategoryInfoSourceId",
                table: "SpecialtySource",
                newName: "ServiceInfoSourceId");

            migrationBuilder.RenameIndex(
                name: "IX_SpecialtySource_CategoryInfoSourceId",
                table: "SpecialtySource",
                newName: "IX_SpecialtySource_ServiceInfoSourceId");

            migrationBuilder.RenameColumn(
                name: "CategoryInfoId",
                table: "Specialty",
                newName: "ServiceInfoId");

            migrationBuilder.RenameIndex(
                name: "IX_Specialty_CategoryInfoId",
                table: "Specialty",
                newName: "IX_Specialty_ServiceInfoId");

            migrationBuilder.RenameColumn(
                name: "CategoryInfoSourceId",
                table: "ServiceInfoSourceAndNameTokenSource",
                newName: "ServiceInfoSourceId");

            migrationBuilder.RenameIndex(
                name: "IX_ServiceInfoSourceAndNameTokenSource_CategoryInfoSourceId",
                table: "ServiceInfoSourceAndNameTokenSource",
                newName: "IX_ServiceInfoSourceAndNameTokenSource_ServiceInfoSourceId");

            migrationBuilder.RenameColumn(
                name: "CategoryInfoId",
                table: "ServiceInfoAndNameToken",
                newName: "ServiceInfoId");

            migrationBuilder.RenameIndex(
                name: "IX_ServiceInfoAndNameToken_CategoryInfoId",
                table: "ServiceInfoAndNameToken",
                newName: "IX_ServiceInfoAndNameToken_ServiceInfoId");

            migrationBuilder.RenameColumn(
                name: "GroupSourceId",
                table: "ServiceCategorySourceAndServiceInfoSource",
                newName: "ServiceInfoSourceId");

            migrationBuilder.RenameColumn(
                name: "CategoryInfoSourceId",
                table: "ServiceCategorySourceAndServiceInfoSource",
                newName: "ServiceCategorySourceId");

            migrationBuilder.RenameIndex(
                name: "IX_ServiceCategorySourceAndServiceInfoSource_GroupSourceId",
                table: "ServiceCategorySourceAndServiceInfoSource",
                newName: "IX_ServiceCategorySourceAndServiceInfoSource_ServiceInfoSourceId");

            migrationBuilder.RenameIndex(
                name: "IX_ServiceCategorySourceAndServiceInfoSource_CategoryInfoSourceId",
                table: "ServiceCategorySourceAndServiceInfoSource",
                newName: "IX_ServiceCategorySourceAndServiceInfoSource_ServiceCategorySourceId");

            migrationBuilder.RenameColumn(
                name: "CategoryInfoId",
                table: "Service",
                newName: "ServiceInfoId");

            migrationBuilder.RenameIndex(
                name: "IX_Service_CategoryInfoId",
                table: "Service",
                newName: "IX_Service_ServiceInfoId");

            migrationBuilder.RenameColumn(
                name: "CategoryInfoSourceId",
                table: "QuestionSource",
                newName: "ServiceInfoSourceId");

            migrationBuilder.RenameIndex(
                name: "IX_QuestionSource_CategoryInfoSourceId",
                table: "QuestionSource",
                newName: "IX_QuestionSource_ServiceInfoSourceId");

            migrationBuilder.RenameColumn(
                name: "CategoryInfoId",
                table: "Question",
                newName: "ServiceInfoId");

            migrationBuilder.RenameIndex(
                name: "IX_Question_CategoryInfoId",
                table: "Question",
                newName: "IX_Question_ServiceInfoId");

            migrationBuilder.RenameColumn(
                name: "CategoryInfoSourceId",
                table: "ProviderQuestionSource",
                newName: "ServiceInfoSourceId");

            migrationBuilder.RenameIndex(
                name: "IX_ProviderQuestionSource_CategoryInfoSourceId",
                table: "ProviderQuestionSource",
                newName: "IX_ProviderQuestionSource_ServiceInfoSourceId");

            migrationBuilder.RenameColumn(
                name: "CategoryInfoId",
                table: "ProviderQuestion",
                newName: "ServiceInfoId");

            migrationBuilder.RenameIndex(
                name: "IX_ProviderQuestion_CategoryInfoId",
                table: "ProviderQuestion",
                newName: "IX_ProviderQuestion_ServiceInfoId");

            migrationBuilder.RenameColumn(
                name: "CategoryInfoSourceId",
                table: "AddonSource",
                newName: "ServiceInfoSourceId");

            migrationBuilder.RenameIndex(
                name: "IX_AddonSource_CategoryInfoSourceId",
                table: "AddonSource",
                newName: "IX_AddonSource_ServiceInfoSourceId");

            migrationBuilder.AddForeignKey(
                name: "FK_AddonSource_ServiceInfoSource_ServiceInfoSourceId",
                table: "AddonSource",
                column: "ServiceInfoSourceId",
                principalTable: "ServiceInfoSource",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProviderQuestion_ServiceInfo_ServiceInfoId",
                table: "ProviderQuestion",
                column: "ServiceInfoId",
                principalTable: "ServiceInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProviderQuestionSource_ServiceInfoSource_ServiceInfoSourceId",
                table: "ProviderQuestionSource",
                column: "ServiceInfoSourceId",
                principalTable: "ServiceInfoSource",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Question_ServiceInfo_ServiceInfoId",
                table: "Question",
                column: "ServiceInfoId",
                principalTable: "ServiceInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionSource_ServiceInfoSource_ServiceInfoSourceId",
                table: "QuestionSource",
                column: "ServiceInfoSourceId",
                principalTable: "ServiceInfoSource",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Service_ServiceInfo_ServiceInfoId",
                table: "Service",
                column: "ServiceInfoId",
                principalTable: "ServiceInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceCategorySourceAndServiceInfoSource_ServiceCategorySource_ServiceCategorySourceId",
                table: "ServiceCategorySourceAndServiceInfoSource",
                column: "ServiceCategorySourceId",
                principalTable: "ServiceCategorySource",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceCategorySourceAndServiceInfoSource_ServiceInfoSource_ServiceInfoSourceId",
                table: "ServiceCategorySourceAndServiceInfoSource",
                column: "ServiceInfoSourceId",
                principalTable: "ServiceInfoSource",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceInfoAndNameToken_ServiceInfo_ServiceInfoId",
                table: "ServiceInfoAndNameToken",
                column: "ServiceInfoId",
                principalTable: "ServiceInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceInfoSourceAndNameTokenSource_ServiceInfoSource_ServiceInfoSourceId",
                table: "ServiceInfoSourceAndNameTokenSource",
                column: "ServiceInfoSourceId",
                principalTable: "ServiceInfoSource",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Specialty_ServiceInfo_ServiceInfoId",
                table: "Specialty",
                column: "ServiceInfoId",
                principalTable: "ServiceInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SpecialtySource_ServiceInfoSource_ServiceInfoSourceId",
                table: "SpecialtySource",
                column: "ServiceInfoSourceId",
                principalTable: "ServiceInfoSource",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AddonSource_ServiceInfoSource_ServiceInfoSourceId",
                table: "AddonSource");

            migrationBuilder.DropForeignKey(
                name: "FK_ProviderQuestion_ServiceInfo_ServiceInfoId",
                table: "ProviderQuestion");

            migrationBuilder.DropForeignKey(
                name: "FK_ProviderQuestionSource_ServiceInfoSource_ServiceInfoSourceId",
                table: "ProviderQuestionSource");

            migrationBuilder.DropForeignKey(
                name: "FK_Question_ServiceInfo_ServiceInfoId",
                table: "Question");

            migrationBuilder.DropForeignKey(
                name: "FK_QuestionSource_ServiceInfoSource_ServiceInfoSourceId",
                table: "QuestionSource");

            migrationBuilder.DropForeignKey(
                name: "FK_Service_ServiceInfo_ServiceInfoId",
                table: "Service");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceCategorySourceAndServiceInfoSource_ServiceCategorySource_ServiceCategorySourceId",
                table: "ServiceCategorySourceAndServiceInfoSource");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceCategorySourceAndServiceInfoSource_ServiceInfoSource_ServiceInfoSourceId",
                table: "ServiceCategorySourceAndServiceInfoSource");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceInfoAndNameToken_ServiceInfo_ServiceInfoId",
                table: "ServiceInfoAndNameToken");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceInfoSourceAndNameTokenSource_ServiceInfoSource_ServiceInfoSourceId",
                table: "ServiceInfoSourceAndNameTokenSource");

            migrationBuilder.DropForeignKey(
                name: "FK_Specialty_ServiceInfo_ServiceInfoId",
                table: "Specialty");

            migrationBuilder.DropForeignKey(
                name: "FK_SpecialtySource_ServiceInfoSource_ServiceInfoSourceId",
                table: "SpecialtySource");

            migrationBuilder.RenameColumn(
                name: "ServiceInfoSourceId",
                table: "SpecialtySource",
                newName: "CategoryInfoSourceId");

            migrationBuilder.RenameIndex(
                name: "IX_SpecialtySource_ServiceInfoSourceId",
                table: "SpecialtySource",
                newName: "IX_SpecialtySource_CategoryInfoSourceId");

            migrationBuilder.RenameColumn(
                name: "ServiceInfoId",
                table: "Specialty",
                newName: "CategoryInfoId");

            migrationBuilder.RenameIndex(
                name: "IX_Specialty_ServiceInfoId",
                table: "Specialty",
                newName: "IX_Specialty_CategoryInfoId");

            migrationBuilder.RenameColumn(
                name: "ServiceInfoSourceId",
                table: "ServiceInfoSourceAndNameTokenSource",
                newName: "CategoryInfoSourceId");

            migrationBuilder.RenameIndex(
                name: "IX_ServiceInfoSourceAndNameTokenSource_ServiceInfoSourceId",
                table: "ServiceInfoSourceAndNameTokenSource",
                newName: "IX_ServiceInfoSourceAndNameTokenSource_CategoryInfoSourceId");

            migrationBuilder.RenameColumn(
                name: "ServiceInfoId",
                table: "ServiceInfoAndNameToken",
                newName: "CategoryInfoId");

            migrationBuilder.RenameIndex(
                name: "IX_ServiceInfoAndNameToken_ServiceInfoId",
                table: "ServiceInfoAndNameToken",
                newName: "IX_ServiceInfoAndNameToken_CategoryInfoId");

            migrationBuilder.RenameColumn(
                name: "ServiceInfoSourceId",
                table: "ServiceCategorySourceAndServiceInfoSource",
                newName: "GroupSourceId");

            migrationBuilder.RenameColumn(
                name: "ServiceCategorySourceId",
                table: "ServiceCategorySourceAndServiceInfoSource",
                newName: "CategoryInfoSourceId");

            migrationBuilder.RenameIndex(
                name: "IX_ServiceCategorySourceAndServiceInfoSource_ServiceInfoSourceId",
                table: "ServiceCategorySourceAndServiceInfoSource",
                newName: "IX_ServiceCategorySourceAndServiceInfoSource_GroupSourceId");

            migrationBuilder.RenameIndex(
                name: "IX_ServiceCategorySourceAndServiceInfoSource_ServiceCategorySourceId",
                table: "ServiceCategorySourceAndServiceInfoSource",
                newName: "IX_ServiceCategorySourceAndServiceInfoSource_CategoryInfoSourceId");

            migrationBuilder.RenameColumn(
                name: "ServiceInfoId",
                table: "Service",
                newName: "CategoryInfoId");

            migrationBuilder.RenameIndex(
                name: "IX_Service_ServiceInfoId",
                table: "Service",
                newName: "IX_Service_CategoryInfoId");

            migrationBuilder.RenameColumn(
                name: "ServiceInfoSourceId",
                table: "QuestionSource",
                newName: "CategoryInfoSourceId");

            migrationBuilder.RenameIndex(
                name: "IX_QuestionSource_ServiceInfoSourceId",
                table: "QuestionSource",
                newName: "IX_QuestionSource_CategoryInfoSourceId");

            migrationBuilder.RenameColumn(
                name: "ServiceInfoId",
                table: "Question",
                newName: "CategoryInfoId");

            migrationBuilder.RenameIndex(
                name: "IX_Question_ServiceInfoId",
                table: "Question",
                newName: "IX_Question_CategoryInfoId");

            migrationBuilder.RenameColumn(
                name: "ServiceInfoSourceId",
                table: "ProviderQuestionSource",
                newName: "CategoryInfoSourceId");

            migrationBuilder.RenameIndex(
                name: "IX_ProviderQuestionSource_ServiceInfoSourceId",
                table: "ProviderQuestionSource",
                newName: "IX_ProviderQuestionSource_CategoryInfoSourceId");

            migrationBuilder.RenameColumn(
                name: "ServiceInfoId",
                table: "ProviderQuestion",
                newName: "CategoryInfoId");

            migrationBuilder.RenameIndex(
                name: "IX_ProviderQuestion_ServiceInfoId",
                table: "ProviderQuestion",
                newName: "IX_ProviderQuestion_CategoryInfoId");

            migrationBuilder.RenameColumn(
                name: "ServiceInfoSourceId",
                table: "AddonSource",
                newName: "CategoryInfoSourceId");

            migrationBuilder.RenameIndex(
                name: "IX_AddonSource_ServiceInfoSourceId",
                table: "AddonSource",
                newName: "IX_AddonSource_CategoryInfoSourceId");

            migrationBuilder.AddForeignKey(
                name: "FK_AddonSource_ServiceInfoSource_CategoryInfoSourceId",
                table: "AddonSource",
                column: "CategoryInfoSourceId",
                principalTable: "ServiceInfoSource",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProviderQuestion_ServiceInfo_CategoryInfoId",
                table: "ProviderQuestion",
                column: "CategoryInfoId",
                principalTable: "ServiceInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProviderQuestionSource_ServiceInfoSource_CategoryInfoSourceId",
                table: "ProviderQuestionSource",
                column: "CategoryInfoSourceId",
                principalTable: "ServiceInfoSource",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Question_ServiceInfo_CategoryInfoId",
                table: "Question",
                column: "CategoryInfoId",
                principalTable: "ServiceInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionSource_ServiceInfoSource_CategoryInfoSourceId",
                table: "QuestionSource",
                column: "CategoryInfoSourceId",
                principalTable: "ServiceInfoSource",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Service_ServiceInfo_CategoryInfoId",
                table: "Service",
                column: "CategoryInfoId",
                principalTable: "ServiceInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceCategorySourceAndServiceInfoSource_ServiceInfoSource_CategoryInfoSourceId",
                table: "ServiceCategorySourceAndServiceInfoSource",
                column: "CategoryInfoSourceId",
                principalTable: "ServiceInfoSource",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceCategorySourceAndServiceInfoSource_ServiceCategorySource_GroupSourceId",
                table: "ServiceCategorySourceAndServiceInfoSource",
                column: "GroupSourceId",
                principalTable: "ServiceCategorySource",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceInfoAndNameToken_ServiceInfo_CategoryInfoId",
                table: "ServiceInfoAndNameToken",
                column: "CategoryInfoId",
                principalTable: "ServiceInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceInfoSourceAndNameTokenSource_ServiceInfoSource_CategoryInfoSourceId",
                table: "ServiceInfoSourceAndNameTokenSource",
                column: "CategoryInfoSourceId",
                principalTable: "ServiceInfoSource",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Specialty_ServiceInfo_CategoryInfoId",
                table: "Specialty",
                column: "CategoryInfoId",
                principalTable: "ServiceInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SpecialtySource_ServiceInfoSource_CategoryInfoSourceId",
                table: "SpecialtySource",
                column: "CategoryInfoSourceId",
                principalTable: "ServiceInfoSource",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

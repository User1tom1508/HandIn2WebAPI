using Microsoft.EntityFrameworkCore.Migrations;

namespace DNPHandIn2WebApi.Migrations
{
    public partial class addedJobToPersistance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adults_Job_Jobid",
                table: "Adults");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Job",
                table: "Job");

            migrationBuilder.RenameTable(
                name: "Job",
                newName: "Jobs");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Jobs",
                table: "Jobs",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Adults_Jobs_Jobid",
                table: "Adults",
                column: "Jobid",
                principalTable: "Jobs",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adults_Jobs_Jobid",
                table: "Adults");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Jobs",
                table: "Jobs");

            migrationBuilder.RenameTable(
                name: "Jobs",
                newName: "Job");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Job",
                table: "Job",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Adults_Job_Jobid",
                table: "Adults",
                column: "Jobid",
                principalTable: "Job",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

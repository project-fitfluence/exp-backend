using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace fitfluence_experimental_backend.Migrations
{
    public partial class AddedDefaultRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "03a6a923-9623-4619-be3a-2442da526698", "83ec5c46-8182-4fd1-a507-4713247d100f", "Support", "SUPPORT" },
                    { "3eb2e182-b29f-4629-8844-2fd40e540692", "a4548b7a-e3e6-4865-800a-5672d542a8cb", "Customer", "CUSTOMER" },
                    { "74bb6496-9700-42da-86de-5976bbdc3e40", "2c48b059-fb6e-4b44-a3f9-2c73c9755095", "Admin", "ADMIN" },
                    { "b861f37b-191f-4ae7-b1c7-fe38f3495554", "b147d632-3678-4bc6-bdf8-048777d6bdc8", "Partner", "PARTNER" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "03a6a923-9623-4619-be3a-2442da526698");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3eb2e182-b29f-4629-8844-2fd40e540692");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "74bb6496-9700-42da-86de-5976bbdc3e40");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b861f37b-191f-4ae7-b1c7-fe38f3495554");
        }
    }
}

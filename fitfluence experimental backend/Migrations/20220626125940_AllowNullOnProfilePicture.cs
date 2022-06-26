using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace fitfluence_experimental_backend.Migrations
{
    public partial class AllowNullOnProfilePicture : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "ProfilePicture",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "21c8b618-34eb-4e9a-9307-ee295406e15a", "3890fae1-9d69-446f-bf35-62a002db2f58", "Partner", "PARTNER" },
                    { "3be2b01a-e74b-4547-9c1b-cf82dd69d9bf", "22c32b3d-4471-4f7f-96c8-d58401f056a1", "Support", "SUPPORT" },
                    { "8abd454e-28a3-4330-9ff9-c8a127a873d7", "e6ecfdb0-64f5-4931-93d1-66472983a974", "Customer", "CUSTOMER" },
                    { "f7095f2b-db53-4bf5-8095-87538e6358a2", "fd6036e2-afe8-4ee3-b89a-5a80f9afdd8e", "Admin", "ADMIN" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "21c8b618-34eb-4e9a-9307-ee295406e15a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3be2b01a-e74b-4547-9c1b-cf82dd69d9bf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8abd454e-28a3-4330-9ff9-c8a127a873d7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f7095f2b-db53-4bf5-8095-87538e6358a2");

            migrationBuilder.AlterColumn<string>(
                name: "ProfilePicture",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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
    }
}

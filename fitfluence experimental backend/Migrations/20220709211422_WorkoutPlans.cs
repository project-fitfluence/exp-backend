using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace fitfluence_experimental_backend.Migrations
{
    public partial class WorkoutPlans : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "TrainerId",
                table: "Exercises",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApiUserId = table.Column<int>(type: "int", nullable: false),
                    ApiUserId1 = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_AspNetUsers_ApiUserId1",
                        column: x => x.ApiUserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Trainers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApiUserId = table.Column<int>(type: "int", nullable: false),
                    ApiUserId1 = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trainers_AspNetUsers_ApiUserId1",
                        column: x => x.ApiUserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "WorkoutPlans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrainerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkoutPlans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkoutPlans_Trainers_TrainerId",
                        column: x => x.TrainerId,
                        principalTable: "Trainers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkoutDays",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrainerId = table.Column<int>(type: "int", nullable: false),
                    WorkoutPlanId = table.Column<int>(type: "int", nullable: false),
                    DayType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkoutDays", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkoutDays_Trainers_TrainerId",
                        column: x => x.TrainerId,
                        principalTable: "Trainers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkoutDays_WorkoutPlans_WorkoutPlanId",
                        column: x => x.WorkoutPlanId,
                        principalTable: "WorkoutPlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkoutPlansCustomers",
                columns: table => new
                {
                    CustomersId = table.Column<int>(type: "int", nullable: false),
                    WorkoutPlansId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkoutPlansCustomers", x => new { x.CustomersId, x.WorkoutPlansId });
                    table.ForeignKey(
                        name: "FK_WorkoutPlansCustomers_Customers_CustomersId",
                        column: x => x.CustomersId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkoutPlansCustomers_WorkoutPlans_WorkoutPlansId",
                        column: x => x.WorkoutPlansId,
                        principalTable: "WorkoutPlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExerciseWorkoutDay",
                columns: table => new
                {
                    ExercisesId = table.Column<int>(type: "int", nullable: false),
                    WorkoutDaysId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseWorkoutDay", x => new { x.ExercisesId, x.WorkoutDaysId });
                    table.ForeignKey(
                        name: "FK_ExerciseWorkoutDay_Exercises_ExercisesId",
                        column: x => x.ExercisesId,
                        principalTable: "Exercises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExerciseWorkoutDay_WorkoutDays_WorkoutDaysId",
                        column: x => x.WorkoutDaysId,
                        principalTable: "WorkoutDays",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "264a5fe1-4eee-4f71-8820-378da84ceb16", "95d4a7b5-fe46-4fad-8459-6f456a4fefc1", "Partner", "PARTNER" },
                    { "5cdc29ee-400c-416c-b537-0db13dfd622f", "90be2c85-3e8d-4197-aa30-c5d5994a005b", "Customer", "CUSTOMER" },
                    { "c43e2847-abb9-4e89-8bdd-00edeb166a76", "34b67647-1d23-4748-a697-26fa89fefc10", "Support", "SUPPORT" },
                    { "cf6e4031-8b39-4126-9a37-d64f53477399", "b4523dc9-aa07-4805-b496-8c6a0b308983", "Admin", "ADMIN" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_TrainerId",
                table: "Exercises",
                column: "TrainerId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_ApiUserId1",
                table: "Customers",
                column: "ApiUserId1");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseWorkoutDay_WorkoutDaysId",
                table: "ExerciseWorkoutDay",
                column: "WorkoutDaysId");

            migrationBuilder.CreateIndex(
                name: "IX_Trainers_ApiUserId1",
                table: "Trainers",
                column: "ApiUserId1");

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutDays_TrainerId",
                table: "WorkoutDays",
                column: "TrainerId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutDays_WorkoutPlanId",
                table: "WorkoutDays",
                column: "WorkoutPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutPlans_TrainerId",
                table: "WorkoutPlans",
                column: "TrainerId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutPlansCustomers_WorkoutPlansId",
                table: "WorkoutPlansCustomers",
                column: "WorkoutPlansId");

            migrationBuilder.AddForeignKey(
                name: "FK_Exercises_Trainers_TrainerId",
                table: "Exercises",
                column: "TrainerId",
                principalTable: "Trainers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exercises_Trainers_TrainerId",
                table: "Exercises");

            migrationBuilder.DropTable(
                name: "ExerciseWorkoutDay");

            migrationBuilder.DropTable(
                name: "WorkoutPlansCustomers");

            migrationBuilder.DropTable(
                name: "WorkoutDays");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "WorkoutPlans");

            migrationBuilder.DropTable(
                name: "Trainers");

            migrationBuilder.DropIndex(
                name: "IX_Exercises_TrainerId",
                table: "Exercises");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "264a5fe1-4eee-4f71-8820-378da84ceb16");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5cdc29ee-400c-416c-b537-0db13dfd622f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c43e2847-abb9-4e89-8bdd-00edeb166a76");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cf6e4031-8b39-4126-9a37-d64f53477399");

            migrationBuilder.DropColumn(
                name: "TrainerId",
                table: "Exercises");

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
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TechBlogWeb.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Tag = table.Column<string>(nullable: true),
                    NormalizedTag = table.Column<string>(nullable: true),
                    Author = table.Column<string>(nullable: true),
                    TitleImagePath = table.Column<string>(nullable: true),
                    MetaTitle = table.Column<string>(nullable: true),
                    MetaDescription = table.Column<string>(nullable: true),
                    MetaKeywords = table.Column<string>(nullable: true),
                    DateTime = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    SubTitle = table.Column<string>(nullable: true),
                    Text = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "Author", "DateTime", "MetaDescription", "MetaKeywords", "MetaTitle", "NormalizedTag", "SubTitle", "Tag", "Text", "Title", "TitleImagePath" },
                values: new object[,]
                {
                    { new Guid("91c2c13f-cc17-4443-a61f-ed0b1c861705"), "testAuthor11", new DateTime(2020, 8, 9, 14, 38, 54, 568, DateTimeKind.Utc).AddTicks(6986), null, null, null, "Worldwide", "testSub11", "Worldwide", "testText11", "testTitle11", "tech_menu.jpg" },
                    { new Guid("3929f606-a875-47cc-8ef6-ac1ed8bd9f65"), "testAuthor22", new DateTime(2020, 8, 9, 14, 38, 54, 568, DateTimeKind.Utc).AddTicks(7156), null, null, null, "Gadgets", "testSub22", "Gadgets", "testText22", "testTitle22", "tech_menu.jpg" },
                    { new Guid("256a1923-e9a5-4490-a81c-3d6886ab359c"), "testAuthor21", new DateTime(2020, 8, 9, 14, 38, 54, 568, DateTimeKind.Utc).AddTicks(7152), null, null, null, "Gadgets", "testSub21", "Gadgets", "testText21", "testTitle21", "tech_menu.jpg" },
                    { new Guid("85daa3b2-9592-425c-9c3f-ce2947aea432"), "testAuthor20", new DateTime(2020, 8, 9, 14, 38, 54, 568, DateTimeKind.Utc).AddTicks(7146), null, null, null, "Socia lMedia", "testSub20", "SocialMedia", "testText20", "testTitle20", "tech_menu.jpg" },
                    { new Guid("744a0dca-e9a8-47b0-8e47-93405fbf2752"), "testAuthor19", new DateTime(2020, 8, 9, 14, 38, 54, 568, DateTimeKind.Utc).AddTicks(7141), null, null, null, "Socia lMedia", "testSub19", "SocialMedia", "testText19", "testTitle19", "tech_menu.jpg" },
                    { new Guid("88c928e1-e68e-425e-921a-da7d7d1d45d0"), "testAuthor18", new DateTime(2020, 8, 9, 14, 38, 54, 568, DateTimeKind.Utc).AddTicks(7135), null, null, null, "Socia lMedia", "testSub18", "SocialMedia", "testText18", "testTitle18", "tech_menu.jpg" },
                    { new Guid("6010dd64-1d0b-4067-ada3-8ff4af1fd1f6"), "testAuthor17", new DateTime(2020, 8, 9, 14, 38, 54, 568, DateTimeKind.Utc).AddTicks(7127), null, null, null, "Socia lMedia", "testSub17", "SocialMedia", "testText17", "testTitle17", "tech_menu.jpg" },
                    { new Guid("bc1a6d46-f938-4669-9942-2cb85e4addae"), "testAuthor16", new DateTime(2020, 8, 9, 14, 38, 54, 568, DateTimeKind.Utc).AddTicks(7122), null, null, null, "Car News", "testSub16", "CarNews", "testText16", "testTitle16", "tech_menu.jpg" },
                    { new Guid("709a5a7a-13ad-4bf1-bed1-339fcd5f36d6"), "testAuthor15", new DateTime(2020, 8, 9, 14, 38, 54, 568, DateTimeKind.Utc).AddTicks(7112), null, null, null, "Car News", "testSub15", "CarNews", "testText15", "testTitle15", "tech_menu.jpg" },
                    { new Guid("f37e48a6-7532-440d-b601-93fbbc1fdd05"), "testAuthor14", new DateTime(2020, 8, 9, 14, 38, 54, 568, DateTimeKind.Utc).AddTicks(7101), null, null, null, "Car News", "testSub14", "CarNews", "testText14", "testTitle14", "tech_menu.jpg" },
                    { new Guid("42f5855d-a7bc-442a-aa4a-f4735453d7ef"), "testAuthor13", new DateTime(2020, 8, 9, 14, 38, 54, 568, DateTimeKind.Utc).AddTicks(6996), null, null, null, "Car News", "testSub13", "CarNews", "testText13", "testTitle13", "tech_menu.jpg" },
                    { new Guid("7e64829c-0b1c-4d03-9a90-fd51568f4843"), "testAuthor12", new DateTime(2020, 8, 9, 14, 38, 54, 568, DateTimeKind.Utc).AddTicks(6991), null, null, null, "Worldwide", "testSub12", "Worldwide", "testText12", "testTitle12", "tech_menu.jpg" },
                    { new Guid("e1072ed1-b0fd-49a7-94ef-2cdb88daf0bf"), "testAuthor23", new DateTime(2020, 8, 9, 14, 38, 54, 568, DateTimeKind.Utc).AddTicks(7161), null, null, null, "Gadgets", "testSub23", "Gadgets", "testText23", "testTitle23", "tech_menu.jpg" },
                    { new Guid("57c3aa63-e6eb-4912-9a4b-087072c56fe3"), "testAuthor24", new DateTime(2020, 8, 9, 14, 38, 54, 568, DateTimeKind.Utc).AddTicks(7206), null, null, null, "Gadgets", "testSub24", "Gadgets", "testText24", "testTitle24", "tech_menu.jpg" },
                    { new Guid("cfa58c39-0b5d-4ef1-9595-058ba88cc1cc"), "testAuthor9", new DateTime(2020, 8, 9, 14, 38, 54, 568, DateTimeKind.Utc).AddTicks(6905), null, null, null, "Worldwide", "testSub9", "Worldwide", "testText9", "testTitle9", "tech_menu.jpg" },
                    { new Guid("218a13eb-b095-4e79-9087-dbc659ee8d5e"), "testAuthor8", new DateTime(2020, 8, 9, 14, 38, 54, 568, DateTimeKind.Utc).AddTicks(6900), null, null, null, "Technology", "testSub8", "Technology", "testText8", "testTitle8", "tech_menu.jpg" },
                    { new Guid("291bc113-7bc1-431a-9ba7-d253d1aa60c8"), "testAuthor7", new DateTime(2020, 8, 9, 14, 38, 54, 568, DateTimeKind.Utc).AddTicks(6884), null, null, null, "Technology", "testSub7", "Technology", "testText7", "testTitle7", "tech_menu.jpg" },
                    { new Guid("30100c23-0f1e-451b-ac77-79f65c1527a4"), "testAuthor6", new DateTime(2020, 8, 9, 14, 38, 54, 568, DateTimeKind.Utc).AddTicks(6879), null, null, null, "Technology", "testSub6", "Technology", "testText6", "testTitle6", "tech_menu.jpg" },
                    { new Guid("d2855081-113b-4c57-8031-25da1a0f8306"), "testAuthor5", new DateTime(2020, 8, 9, 14, 38, 54, 568, DateTimeKind.Utc).AddTicks(6871), null, null, null, "Technology", "testSub5", "Technology", "testText5", "testTitle5", "tech_menu.jpg" },
                    { new Guid("198cf58c-b097-4f40-8fb5-985cbfe54589"), "testAuthor4", new DateTime(2020, 8, 9, 14, 38, 54, 568, DateTimeKind.Utc).AddTicks(6866), null, null, null, "Science", "testSub4", "Science", "testText4", "testTitle4", "tech_menu.jpg" },
                    { new Guid("2387a96a-fc97-42e8-8ded-d30f229ae20c"), "testAuthor3", new DateTime(2020, 8, 9, 14, 38, 54, 568, DateTimeKind.Utc).AddTicks(6859), null, null, null, "Science", "testSub3", "Science", "testText3", "testTitle3", "tech_menu.jpg" },
                    { new Guid("6bc96678-7700-46ae-a711-4c112bd3ee8f"), "testAuthor2", new DateTime(2020, 8, 9, 14, 38, 54, 568, DateTimeKind.Utc).AddTicks(6803), null, null, null, "Science", "testSub2", "Science", "testText2", "testTitle2", "tech_menu.jpg" },
                    { new Guid("088dc525-cb5c-4fe9-baf2-076527b7c7c4"), "testAuthor1", new DateTime(2020, 8, 9, 14, 38, 54, 568, DateTimeKind.Utc).AddTicks(1475), null, null, null, "Science", "testSub1", "Science", "testText1", "testTitle1", "tech_menu.jpg" },
                    { new Guid("b562ccaf-d9e4-4954-9259-b64c54714e71"), "testAuthor10", new DateTime(2020, 8, 9, 14, 38, 54, 568, DateTimeKind.Utc).AddTicks(6979), null, null, null, "Worldwide", "testSub10", "Worldwide", "testText10", "testTitle10", "tech_menu.jpg" }
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "AD2CC976-21B4-4A15-9F6D-50B51D23F2AC", "b3dde91b-25b6-400c-ba30-e0d4418aec56", "admin", "ADMIN" },
                    { "3BC4D90C-D7B0-47D7-8387-B1DBDECA82CF", "3ad7fcd7-b6ad-4f70-8ab6-e8420aab4a94", "user", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "4D2CE2C5-2C04-42DA-A47D-1DD4A2010723", 0, "aa46187c-0cbf-4bdf-a875-84b20e286643", null, true, false, null, null, "ADMIN", "AQAAAAEAACcQAAAAEBlNbcw/qwmxzassmYMS5lzJwLoG0BdK9I6cuaywzPQLeViw2nPQ74BwQCyiVcZfXw==", null, false, "", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "4D2CE2C5-2C04-42DA-A47D-1DD4A2010723", "AD2CC976-21B4-4A15-9F6D-50B51D23F2AC" });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}

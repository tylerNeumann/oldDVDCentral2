using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TN.DVDCentral.PL2.Migrations
{
    /// <inheritdoc />
    public partial class CreateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblCustomer",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Address = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    City = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    State = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    ZIP = table.Column<string>(type: "varchar(12)", unicode: false, maxLength: 12, nullable: false),
                    Phone = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCustomer_Id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblDirector",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblDirector_Id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblFormat",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblFormat_Id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblGenre",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblGenre_Id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblRating",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblRating_Id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblUser",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    UserName = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: false),
                    Password = table.Column<string>(type: "varchar(28)", unicode: false, maxLength: 28, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblUser_Id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblOrder",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ShipDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblOrder_Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblOrder_tblCustomer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "tblCustomer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblMovie",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    FormatId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DirectorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RatingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Cost = table.Column<double>(type: "float", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    ImagePath = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblMovie_Id", x => x.Id);
                    table.ForeignKey(
                        name: "fk_tblMovie_DirectorId",
                        column: x => x.DirectorId,
                        principalTable: "tblDirector",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "fk_tblMovie_FormatId",
                        column: x => x.FormatId,
                        principalTable: "tblFormat",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "fk_tblMovie_RatingId",
                        column: x => x.RatingId,
                        principalTable: "tblRating",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "tblCart",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCart", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblCart_tblUser_UserId",
                        column: x => x.UserId,
                        principalTable: "tblUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblMovieGenre",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MovieId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GenreId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblMovieGenre_Id", x => x.Id);
                    table.ForeignKey(
                        name: "tblMovieGenre_GenreId",
                        column: x => x.GenreId,
                        principalTable: "tblGenre",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "tblMovieGenre_MovieId",
                        column: x => x.MovieId,
                        principalTable: "tblMovie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblOrderItem",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    MovieId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Cost = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblOrderItem_Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblOrderItem_tblMovie_MovieId",
                        column: x => x.MovieId,
                        principalTable: "tblMovie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblOrderItem_tblOrder_OrderId",
                        column: x => x.OrderId,
                        principalTable: "tblOrder",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblCartItem",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CartId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MovieId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCartItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblCartItem_tblCart_CartId",
                        column: x => x.CartId,
                        principalTable: "tblCart",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblCartItem_tblMovie_MovieId",
                        column: x => x.MovieId,
                        principalTable: "tblMovie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "tblCustomer",
                columns: new[] { "Id", "Address", "City", "FirstName", "LastName", "Phone", "State", "UserId", "ZIP" },
                values: new object[,]
                {
                    { new Guid("37d74e40-ec42-4599-a664-325ea6061d08"), "987 Willow Road", "Slinger", "John", "Doro", "9202623345", "WI", new Guid("c31b0ca5-678e-4c8b-bb00-3c556c770146"), "56495" },
                    { new Guid("64966745-1d86-4338-950b-e3347a29c2b5"), "159 Johnson Avenue", "Allenton", "Brian", "Foote", "9202623415", "WI", new Guid("a861a8d5-e5ee-43f9-b8ee-1d639529934b"), "53142" },
                    { new Guid("b02bae9d-977d-467d-bf3a-43bbc082537b"), "453 Oak Street", "Fond du Lac", "Steve", "Marin", "9205879797", "WI", new Guid("72b5640f-6736-40e5-a7f2-d885ab379dd6"), "54935" }
                });

            migrationBuilder.InsertData(
                table: "tblDirector",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[,]
                {
                    { new Guid("86671109-aa71-402b-9359-44e9538e589f"), "Other", "Other" },
                    { new Guid("c231fa86-5313-4999-b909-ff3e0af56886"), "George", "Lucas" },
                    { new Guid("e1471dd2-1546-4487-aeae-03755e594fc6"), "Clint", "Eastwood" },
                    { new Guid("f1e5ca89-8771-43b4-8cef-05c73d4442ca"), "John", "Avildsen" },
                    { new Guid("f92b54f7-b982-412e-afaf-e2c006c2d65e"), "Steven", "Spielberg" },
                    { new Guid("faef9a92-ff19-4f0b-86dc-5e9eae9f1e7d"), "Rob", "Reiner" }
                });

            migrationBuilder.InsertData(
                table: "tblFormat",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { new Guid("176ec3d1-589c-4e26-a718-f5380eb81ee9"), "DVD" },
                    { new Guid("31380c4f-730c-4dcb-bc0d-1bfe8c0c6271"), "VHS" },
                    { new Guid("5fb3347f-776a-4f15-bfb1-092d0a452c34"), "Blu-Ray" },
                    { new Guid("a32ff621-4995-4e36-b465-29e3167d1710"), "Other" }
                });

            migrationBuilder.InsertData(
                table: "tblGenre",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { new Guid("1979a458-e21b-4d9c-a94b-10a1f26bd7b6"), "Sci-Fi" },
                    { new Guid("246bb906-a3ce-427b-a3ab-075c7a20d805"), "Romance" },
                    { new Guid("31ae5e72-05b3-427c-a220-4e907f6bffde"), "Western" },
                    { new Guid("35b91b59-efde-4940-89d8-73d140cb656c"), "Mystery" },
                    { new Guid("4eb99a2e-6e61-4813-a7b3-e382ce91f6d7"), "Horror" },
                    { new Guid("52407425-23e4-47d7-b402-45e60ce9bee5"), "Comedy" },
                    { new Guid("6fe9ee31-e218-4f64-b092-2be21b1ce115"), "Documentary" },
                    { new Guid("72613e03-06f6-488a-9d04-301a08fd7a41"), "Other" },
                    { new Guid("aed3f82d-1785-4a97-b90a-8a99c5be539e"), "Action" },
                    { new Guid("cd985c01-bf35-4d94-9d11-787eb48c1c16"), "Musical" }
                });

            migrationBuilder.InsertData(
                table: "tblRating",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { new Guid("3a1db43e-1054-4fd6-b68f-b4cfa31befec"), "PG-13" },
                    { new Guid("83bea5ae-6ce1-4e14-aab7-7b022ea2cd4e"), "PG" },
                    { new Guid("8aa41446-2acc-40ac-aaf6-bb3c3b79b308"), "Other" },
                    { new Guid("96c87ade-554c-4768-b71a-bcac405a9b56"), "G" },
                    { new Guid("f2890847-1bfa-4833-aefd-858bf51fc19a"), "R" }
                });

            migrationBuilder.InsertData(
                table: "tblUser",
                columns: new[] { "Id", "FirstName", "LastName", "Password", "UserName" },
                values: new object[,]
                {
                    { new Guid("72b5640f-6736-40e5-a7f2-d885ab379dd6"), "Steve", "Marin", "pYfdnNb8sO0FgS4H0MRSwLGOIME=", "smarin" },
                    { new Guid("a861a8d5-e5ee-43f9-b8ee-1d639529934b"), "Brian", "Foote", "pYfdnNb8sO0FgS4H0MRSwLGOIME=", "bfoote" },
                    { new Guid("c31b0ca5-678e-4c8b-bb00-3c556c770146"), "John", "Doro", "pYfdnNb8sO0FgS4H0MRSwLGOIME=", "jdoro" }
                });

            migrationBuilder.InsertData(
                table: "tblCart",
                columns: new[] { "Id", "UserId" },
                values: new object[,]
                {
                    { new Guid("524baa50-12ac-4c0b-9110-f18358b17e30"), new Guid("c31b0ca5-678e-4c8b-bb00-3c556c770146") },
                    { new Guid("d5c1a522-aed1-4784-8c09-a6912df2527e"), new Guid("72b5640f-6736-40e5-a7f2-d885ab379dd6") }
                });

            migrationBuilder.InsertData(
                table: "tblMovie",
                columns: new[] { "Id", "Cost", "Description", "DirectorId", "FormatId", "ImagePath", "Quantity", "RatingId", "Title" },
                values: new object[,]
                {
                    { new Guid("076313f0-89c5-47ee-a4fc-bd12d0a99705"), 9.9900000000000002, "Pale Rider is a 1985 American Western film produced and directed by Clint Eastwood, who also stars in the lead role.", new Guid("f92b54f7-b982-412e-afaf-e2c006c2d65e"), new Guid("176ec3d1-589c-4e26-a718-f5380eb81ee9"), "PaleRider.jpg", 1, new Guid("3a1db43e-1054-4fd6-b68f-b4cfa31befec"), "Pale Rider" },
                    { new Guid("271bafbd-9427-4d31-83b5-ef0c640945ca"), 6.9900000000000002, "Other", new Guid("f1e5ca89-8771-43b4-8cef-05c73d4442ca"), new Guid("31380c4f-730c-4dcb-bc0d-1bfe8c0c6271"), "Rocky.jpg", 2, new Guid("96c87ade-554c-4768-b71a-bcac405a9b56"), "Other" },
                    { new Guid("4b1dd22b-d861-4c72-9c4b-20afb04f3fe6"), 7.5, "Star Wars: Episode IV – A New Hope is a 1977 American epic space-opera film written and directed by George Lucas, produced by Lucasfilm and distributed by 20th Century Fox.", new Guid("f92b54f7-b982-412e-afaf-e2c006c2d65e"), new Guid("176ec3d1-589c-4e26-a718-f5380eb81ee9"), "StarWarsNewHope.jpg", 1, new Guid("3a1db43e-1054-4fd6-b68f-b4cfa31befec"), "Star Wars: Episode IV – A New Hope" },
                    { new Guid("84367a0f-5e58-4087-a55c-55dade74ff02"), 6.9900000000000002, "Rocky is a 1976 American sports drama film directed by John G. Avildsen, written by and starring Sylvester Stallone.", new Guid("f1e5ca89-8771-43b4-8cef-05c73d4442ca"), new Guid("31380c4f-730c-4dcb-bc0d-1bfe8c0c6271"), "Rocky.jpg", 2, new Guid("96c87ade-554c-4768-b71a-bcac405a9b56"), "Rocky" },
                    { new Guid("9479327c-e16e-459d-86e8-bfa4a18e008e"), 10.5, "Indiana Jones and the Last Crusade is a 1989 American action-adventure film directed by Steven Spielberg, from a story co-written by executive producer George Lucas.", new Guid("c231fa86-5313-4999-b909-ff3e0af56886"), new Guid("5fb3347f-776a-4f15-bfb1-092d0a452c34"), "IndianaJonesLastCrusade.jpg", 2, new Guid("f2890847-1bfa-4833-aefd-858bf51fc19a"), "Indiana Jones and the Last Crusade" },
                    { new Guid("bd30859c-bed0-40e1-af8a-4f2b1fb86d70"), 8.9900000000000002, "Jaws is a 1975 American thriller film directed by Steven Spielberg and based on the Peter Benchley 1974 novel of the same name.", new Guid("f92b54f7-b982-412e-afaf-e2c006c2d65e"), new Guid("176ec3d1-589c-4e26-a718-f5380eb81ee9"), "Jaws1.jpg", 1, new Guid("3a1db43e-1054-4fd6-b68f-b4cfa31befec"), "Jaws" },
                    { new Guid("f0d83531-5c27-4151-8396-55f7c470b393"), 12.5, "The Princess Bride is a 1987 American fantasy adventure comedy film directed and co-produced by Rob Reiner, starring Cary Elwes, Robin Wright, Mandy Patinkin, Chris Sarandon, Wallace Shawn, André the Giant, and Christopher Guest.", new Guid("faef9a92-ff19-4f0b-86dc-5e9eae9f1e7d"), new Guid("5fb3347f-776a-4f15-bfb1-092d0a452c34"), "PrincessBride.jpg", 4, new Guid("83bea5ae-6ce1-4e14-aab7-7b022ea2cd4e"), "The Princess Bride" }
                });

            migrationBuilder.InsertData(
                table: "tblOrder",
                columns: new[] { "Id", "CustomerId", "OrderDate", "ShipDate", "UserId" },
                values: new object[,]
                {
                    { new Guid("87ba3640-4da1-4b6c-89da-ce45699622a4"), new Guid("37d74e40-ec42-4599-a664-325ea6061d08"), new DateTime(2017, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2017, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("c31b0ca5-678e-4c8b-bb00-3c556c770146") },
                    { new Guid("8df20bf0-6978-461c-a236-685be51ca6b2"), new Guid("64966745-1d86-4338-950b-e3347a29c2b5"), new DateTime(2022, 10, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("a861a8d5-e5ee-43f9-b8ee-1d639529934b") },
                    { new Guid("d33870c6-d44a-46f3-9cee-7db0af7a97c9"), new Guid("64966745-1d86-4338-950b-e3347a29c2b5"), new DateTime(2021, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("c31b0ca5-678e-4c8b-bb00-3c556c770146") }
                });

            migrationBuilder.InsertData(
                table: "tblCartItem",
                columns: new[] { "Id", "CartId", "MovieId", "Quantity" },
                values: new object[,]
                {
                    { new Guid("02b852b0-25f6-4998-bb60-4d408e0750f5"), new Guid("524baa50-12ac-4c0b-9110-f18358b17e30"), new Guid("bd30859c-bed0-40e1-af8a-4f2b1fb86d70"), 1 },
                    { new Guid("4642ea04-63d9-499d-b106-0d1521d38459"), new Guid("d5c1a522-aed1-4784-8c09-a6912df2527e"), new Guid("bd30859c-bed0-40e1-af8a-4f2b1fb86d70"), 2 },
                    { new Guid("c7eb59df-0b88-45f6-9be9-122eb85703d5"), new Guid("d5c1a522-aed1-4784-8c09-a6912df2527e"), new Guid("84367a0f-5e58-4087-a55c-55dade74ff02"), 1 }
                });

            migrationBuilder.InsertData(
                table: "tblMovieGenre",
                columns: new[] { "Id", "GenreId", "MovieId" },
                values: new object[,]
                {
                    { new Guid("1a118625-d5a3-42f5-94e1-49274a9fb497"), new Guid("6fe9ee31-e218-4f64-b092-2be21b1ce115"), new Guid("f0d83531-5c27-4151-8396-55f7c470b393") },
                    { new Guid("2326c3ce-0aec-461c-bcbb-1711a32b506e"), new Guid("4eb99a2e-6e61-4813-a7b3-e382ce91f6d7"), new Guid("84367a0f-5e58-4087-a55c-55dade74ff02") },
                    { new Guid("2571b956-2911-4ebb-b6f8-69558e32dd30"), new Guid("4eb99a2e-6e61-4813-a7b3-e382ce91f6d7"), new Guid("bd30859c-bed0-40e1-af8a-4f2b1fb86d70") },
                    { new Guid("3a1eea23-4d5f-4f5f-b26c-11e8bf97c231"), new Guid("6fe9ee31-e218-4f64-b092-2be21b1ce115"), new Guid("84367a0f-5e58-4087-a55c-55dade74ff02") },
                    { new Guid("4d636480-338c-4417-9fe5-3329589f8f64"), new Guid("4eb99a2e-6e61-4813-a7b3-e382ce91f6d7"), new Guid("4b1dd22b-d861-4c72-9c4b-20afb04f3fe6") },
                    { new Guid("76c6de8e-5a2d-4ee3-897a-5b88dbef6c06"), new Guid("1979a458-e21b-4d9c-a94b-10a1f26bd7b6"), new Guid("bd30859c-bed0-40e1-af8a-4f2b1fb86d70") },
                    { new Guid("9958c788-468e-4d0c-80ea-7f44901c2d60"), new Guid("cd985c01-bf35-4d94-9d11-787eb48c1c16"), new Guid("4b1dd22b-d861-4c72-9c4b-20afb04f3fe6") },
                    { new Guid("ab983a2a-f5c5-4468-8e2d-8e3edf2e4a29"), new Guid("6fe9ee31-e218-4f64-b092-2be21b1ce115"), new Guid("9479327c-e16e-459d-86e8-bfa4a18e008e") },
                    { new Guid("c723eedc-7a48-4778-9e2f-0fcdd03b2ce6"), new Guid("aed3f82d-1785-4a97-b90a-8a99c5be539e"), new Guid("f0d83531-5c27-4151-8396-55f7c470b393") },
                    { new Guid("c7e932ae-55d3-4469-afb8-a347d253c396"), new Guid("1979a458-e21b-4d9c-a94b-10a1f26bd7b6"), new Guid("84367a0f-5e58-4087-a55c-55dade74ff02") },
                    { new Guid("cbf09478-4e41-49db-85c6-1f38db039cc6"), new Guid("52407425-23e4-47d7-b402-45e60ce9bee5"), new Guid("f0d83531-5c27-4151-8396-55f7c470b393") },
                    { new Guid("e67e52ee-5529-4a46-82f0-2a81849f45a1"), new Guid("35b91b59-efde-4940-89d8-73d140cb656c"), new Guid("076313f0-89c5-47ee-a4fc-bd12d0a99705") },
                    { new Guid("f5151936-a93b-40c8-80c9-18eb82c80764"), new Guid("4eb99a2e-6e61-4813-a7b3-e382ce91f6d7"), new Guid("9479327c-e16e-459d-86e8-bfa4a18e008e") }
                });

            migrationBuilder.InsertData(
                table: "tblOrderItem",
                columns: new[] { "Id", "Cost", "MovieId", "OrderId", "Quantity" },
                values: new object[,]
                {
                    { new Guid("98f32354-d98d-46e1-bd8d-9babe48cba2d"), 8.9900000000000002, new Guid("84367a0f-5e58-4087-a55c-55dade74ff02"), new Guid("87ba3640-4da1-4b6c-89da-ce45699622a4"), 0 },
                    { new Guid("ec53639b-3c9a-4c14-bb67-2954a2609e49"), 10.99, new Guid("bd30859c-bed0-40e1-af8a-4f2b1fb86d70"), new Guid("d33870c6-d44a-46f3-9cee-7db0af7a97c9"), 0 },
                    { new Guid("f7142e48-af23-41c4-b1c6-d9be8d885d7e"), 9.9900000000000002, new Guid("bd30859c-bed0-40e1-af8a-4f2b1fb86d70"), new Guid("87ba3640-4da1-4b6c-89da-ce45699622a4"), 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblCart_UserId",
                table: "tblCart",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_tblCartItem_CartId",
                table: "tblCartItem",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_tblCartItem_MovieId",
                table: "tblCartItem",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_tblMovie_DirectorId",
                table: "tblMovie",
                column: "DirectorId");

            migrationBuilder.CreateIndex(
                name: "IX_tblMovie_FormatId",
                table: "tblMovie",
                column: "FormatId");

            migrationBuilder.CreateIndex(
                name: "IX_tblMovie_RatingId",
                table: "tblMovie",
                column: "RatingId");

            migrationBuilder.CreateIndex(
                name: "IX_tblMovieGenre_GenreId",
                table: "tblMovieGenre",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_tblMovieGenre_MovieId",
                table: "tblMovieGenre",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_tblOrder_CustomerId",
                table: "tblOrder",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_tblOrderItem_MovieId",
                table: "tblOrderItem",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_tblOrderItem_OrderId",
                table: "tblOrderItem",
                column: "OrderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblCartItem");

            migrationBuilder.DropTable(
                name: "tblMovieGenre");

            migrationBuilder.DropTable(
                name: "tblOrderItem");

            migrationBuilder.DropTable(
                name: "tblCart");

            migrationBuilder.DropTable(
                name: "tblGenre");

            migrationBuilder.DropTable(
                name: "tblMovie");

            migrationBuilder.DropTable(
                name: "tblOrder");

            migrationBuilder.DropTable(
                name: "tblUser");

            migrationBuilder.DropTable(
                name: "tblDirector");

            migrationBuilder.DropTable(
                name: "tblFormat");

            migrationBuilder.DropTable(
                name: "tblRating");

            migrationBuilder.DropTable(
                name: "tblCustomer");
        }
    }
}

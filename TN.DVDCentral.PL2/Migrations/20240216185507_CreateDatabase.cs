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
                    { new Guid("2eae0067-fa93-4262-b9a5-76f4e7ed1b38"), "159 Johnson Avenue", "Allenton", "Brian", "Foote", "9202623415", "WI", new Guid("b987fb3e-ec49-4f6b-94a1-665e9e370ab4"), "53142" },
                    { new Guid("3447086f-6d6d-4adc-bc5a-a38f6e49e96e"), "987 Willow Road", "Slinger", "John", "Doro", "9202623345", "WI", new Guid("043b72bb-4d27-4fd2-a660-42afdea8c641"), "56495" },
                    { new Guid("ed2173fb-110a-4eef-96ec-565fa3362c3d"), "453 Oak Street", "Fond du Lac", "Steve", "Marin", "9205879797", "WI", new Guid("5df1ac63-f39d-4a72-bf66-68c686fcf7c8"), "54935" }
                });

            migrationBuilder.InsertData(
                table: "tblDirector",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[,]
                {
                    { new Guid("02fbe255-509e-4cb4-847d-4737b857bce6"), "John", "Avildsen" },
                    { new Guid("0b4d6664-4575-48f6-ac50-6d4a8136f060"), "Other", "Other" },
                    { new Guid("2368626c-a669-48e7-9cab-cf37954c6ebf"), "Clint", "Eastwood" },
                    { new Guid("a664e12f-4949-45b7-bfc9-ba5e16f3af53"), "Rob", "Reiner" },
                    { new Guid("b22e65db-93b7-4006-9f27-a8fe47b71464"), "George", "Lucas" },
                    { new Guid("c3b52051-8b13-4542-8bdf-f08863da8b80"), "Steven", "Spielberg" }
                });

            migrationBuilder.InsertData(
                table: "tblFormat",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { new Guid("53764a6c-13ec-475b-b263-f0425e3af752"), "VHS" },
                    { new Guid("6e12b338-aca5-4084-9cbb-8b3f34cd87fa"), "Blu-Ray" },
                    { new Guid("b78bdb04-5116-4e96-b22e-582b486fb460"), "Other" },
                    { new Guid("e345f8ba-a1a0-4db9-8130-7416595b8a24"), "DVD" }
                });

            migrationBuilder.InsertData(
                table: "tblGenre",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { new Guid("2a5fb788-cd3b-4141-bea3-21aeae6a619a"), "Other" },
                    { new Guid("5be2e564-d78b-4758-b71a-93158c44ed39"), "Horror" },
                    { new Guid("63159406-cac9-4bc0-af64-930cd67330bb"), "Western" },
                    { new Guid("6627e07a-41eb-4d01-b3ce-e2668a8822c5"), "Comedy" },
                    { new Guid("7e348927-1292-4583-9412-087d0352236a"), "Musical" },
                    { new Guid("80d4d8de-d2ba-4b41-bee9-e206e6cc692e"), "Action" },
                    { new Guid("b42f15b8-6da6-4055-8971-95cfb0436f7d"), "Documentary" },
                    { new Guid("bb0bd146-66f6-4fc6-a6ef-8ec426d7cf8b"), "Sci-Fi" },
                    { new Guid("cd38b527-ec83-496a-bfab-59e29f87d82e"), "Romance" },
                    { new Guid("fe57bcee-9a97-494c-916e-e12fe61c2aa3"), "Mystery" }
                });

            migrationBuilder.InsertData(
                table: "tblRating",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { new Guid("06dda4de-8da4-4019-89a1-574e5bd04e19"), "PG-13" },
                    { new Guid("477e9a89-1a39-42ce-bb5b-a58a05698203"), "Other" },
                    { new Guid("d0a399c3-891a-4a8b-9ffe-48774a1c22cd"), "R" },
                    { new Guid("d0b93b2f-d81c-44b9-9a06-3b4265ccda9e"), "PG" },
                    { new Guid("e13bc8de-1d4c-4623-a1e8-3d87da1bc861"), "G" }
                });

            migrationBuilder.InsertData(
                table: "tblUser",
                columns: new[] { "Id", "FirstName", "LastName", "Password", "UserName" },
                values: new object[,]
                {
                    { new Guid("043b72bb-4d27-4fd2-a660-42afdea8c641"), "John", "Doro", "pYfdnNb8sO0FgS4H0MRSwLGOIME=", "jdoro" },
                    { new Guid("5df1ac63-f39d-4a72-bf66-68c686fcf7c8"), "Steve", "Marin", "pYfdnNb8sO0FgS4H0MRSwLGOIME=", "smarin" },
                    { new Guid("b987fb3e-ec49-4f6b-94a1-665e9e370ab4"), "Brian", "Foote", "pYfdnNb8sO0FgS4H0MRSwLGOIME=", "bfoote" }
                });

            migrationBuilder.InsertData(
                table: "tblCart",
                columns: new[] { "Id", "UserId" },
                values: new object[,]
                {
                    { new Guid("767b8c7b-081b-4d08-9ed4-4e1f27674cd0"), new Guid("5df1ac63-f39d-4a72-bf66-68c686fcf7c8") },
                    { new Guid("de33ce0f-4ae6-47ad-8b27-7748895fcc01"), new Guid("043b72bb-4d27-4fd2-a660-42afdea8c641") }
                });

            migrationBuilder.InsertData(
                table: "tblMovie",
                columns: new[] { "Id", "Cost", "Description", "DirectorId", "FormatId", "ImagePath", "Quantity", "RatingId", "Title" },
                values: new object[,]
                {
                    { new Guid("3a23c0d0-3834-439b-92f0-62296a15e51a"), 8.9900000000000002, "Jaws is a 1975 American thriller film directed by Steven Spielberg and based on the Peter Benchley 1974 novel of the same name.", new Guid("c3b52051-8b13-4542-8bdf-f08863da8b80"), new Guid("e345f8ba-a1a0-4db9-8130-7416595b8a24"), "Jaws1.jpg", 1, new Guid("06dda4de-8da4-4019-89a1-574e5bd04e19"), "Jaws" },
                    { new Guid("4857d2cc-4ec3-4f58-9f75-ef295f68e725"), 7.5, "Star Wars: Episode IV – A New Hope is a 1977 American epic space-opera film written and directed by George Lucas, produced by Lucasfilm and distributed by 20th Century Fox.", new Guid("c3b52051-8b13-4542-8bdf-f08863da8b80"), new Guid("e345f8ba-a1a0-4db9-8130-7416595b8a24"), "StarWarsNewHope.jpg", 1, new Guid("06dda4de-8da4-4019-89a1-574e5bd04e19"), "Star Wars: Episode IV – A New Hope" },
                    { new Guid("58b9773a-bdcf-4d45-ac4c-2a9812ddb6ef"), 6.9900000000000002, "Other", new Guid("02fbe255-509e-4cb4-847d-4737b857bce6"), new Guid("53764a6c-13ec-475b-b263-f0425e3af752"), "Rocky.jpg", 2, new Guid("e13bc8de-1d4c-4623-a1e8-3d87da1bc861"), "Other" },
                    { new Guid("a198cd7d-309f-4ebe-ac84-89ba637193ef"), 10.5, "Indiana Jones and the Last Crusade is a 1989 American action-adventure film directed by Steven Spielberg, from a story co-written by executive producer George Lucas.", new Guid("b22e65db-93b7-4006-9f27-a8fe47b71464"), new Guid("6e12b338-aca5-4084-9cbb-8b3f34cd87fa"), "IndianaJonesLastCrusade.jpg", 2, new Guid("d0a399c3-891a-4a8b-9ffe-48774a1c22cd"), "Indiana Jones and the Last Crusade" },
                    { new Guid("bf4aaef8-562e-4f67-b0e8-5a2733931244"), 6.9900000000000002, "Rocky is a 1976 American sports drama film directed by John G. Avildsen, written by and starring Sylvester Stallone.", new Guid("02fbe255-509e-4cb4-847d-4737b857bce6"), new Guid("53764a6c-13ec-475b-b263-f0425e3af752"), "Rocky.jpg", 2, new Guid("e13bc8de-1d4c-4623-a1e8-3d87da1bc861"), "Rocky" },
                    { new Guid("cfb6729f-9d15-4142-97a8-735ad2140c51"), 9.9900000000000002, "Pale Rider is a 1985 American Western film produced and directed by Clint Eastwood, who also stars in the lead role.", new Guid("c3b52051-8b13-4542-8bdf-f08863da8b80"), new Guid("e345f8ba-a1a0-4db9-8130-7416595b8a24"), "PaleRider.jpg", 1, new Guid("06dda4de-8da4-4019-89a1-574e5bd04e19"), "Pale Rider" },
                    { new Guid("f9846378-7304-416a-bd56-a7d95cac76c8"), 12.5, "The Princess Bride is a 1987 American fantasy adventure comedy film directed and co-produced by Rob Reiner, starring Cary Elwes, Robin Wright, Mandy Patinkin, Chris Sarandon, Wallace Shawn, André the Giant, and Christopher Guest.", new Guid("a664e12f-4949-45b7-bfc9-ba5e16f3af53"), new Guid("6e12b338-aca5-4084-9cbb-8b3f34cd87fa"), "PrincessBride.jpg", 4, new Guid("d0b93b2f-d81c-44b9-9a06-3b4265ccda9e"), "The Princess Bride" }
                });

            migrationBuilder.InsertData(
                table: "tblOrder",
                columns: new[] { "Id", "CustomerId", "OrderDate", "ShipDate", "UserId" },
                values: new object[,]
                {
                    { new Guid("424501bf-96a4-4ce2-8057-094981f26c15"), new Guid("3447086f-6d6d-4adc-bc5a-a38f6e49e96e"), new DateTime(2017, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2017, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("043b72bb-4d27-4fd2-a660-42afdea8c641") },
                    { new Guid("d6ee8c02-b008-415e-9e96-f214d9bedfa9"), new Guid("2eae0067-fa93-4262-b9a5-76f4e7ed1b38"), new DateTime(2021, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("043b72bb-4d27-4fd2-a660-42afdea8c641") },
                    { new Guid("de7a0d8a-fef5-48a7-8a7b-4a53ae441164"), new Guid("2eae0067-fa93-4262-b9a5-76f4e7ed1b38"), new DateTime(2022, 10, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("b987fb3e-ec49-4f6b-94a1-665e9e370ab4") }
                });

            migrationBuilder.InsertData(
                table: "tblCartItem",
                columns: new[] { "Id", "CartId", "MovieId", "Quantity" },
                values: new object[,]
                {
                    { new Guid("8ae5d9f0-4992-47b7-a701-ce5042341faa"), new Guid("767b8c7b-081b-4d08-9ed4-4e1f27674cd0"), new Guid("bf4aaef8-562e-4f67-b0e8-5a2733931244"), 1 },
                    { new Guid("a5108349-4b9f-415f-b453-e7d1a3ed7b8f"), new Guid("de33ce0f-4ae6-47ad-8b27-7748895fcc01"), new Guid("3a23c0d0-3834-439b-92f0-62296a15e51a"), 1 },
                    { new Guid("c92574fc-bed2-48fc-b383-8f481d444393"), new Guid("767b8c7b-081b-4d08-9ed4-4e1f27674cd0"), new Guid("3a23c0d0-3834-439b-92f0-62296a15e51a"), 2 }
                });

            migrationBuilder.InsertData(
                table: "tblMovieGenre",
                columns: new[] { "Id", "GenreId", "MovieId" },
                values: new object[,]
                {
                    { new Guid("08cdc0cc-8d6c-4a29-9ba0-c52e76e83a5f"), new Guid("b42f15b8-6da6-4055-8971-95cfb0436f7d"), new Guid("bf4aaef8-562e-4f67-b0e8-5a2733931244") },
                    { new Guid("11d8521a-8191-451d-8d0c-140e8f0247f8"), new Guid("b42f15b8-6da6-4055-8971-95cfb0436f7d"), new Guid("a198cd7d-309f-4ebe-ac84-89ba637193ef") },
                    { new Guid("46c8633d-28f4-4489-b907-298350edf0ba"), new Guid("80d4d8de-d2ba-4b41-bee9-e206e6cc692e"), new Guid("f9846378-7304-416a-bd56-a7d95cac76c8") },
                    { new Guid("5902a2d4-efb6-4a3c-991f-fc6d1051a39d"), new Guid("6627e07a-41eb-4d01-b3ce-e2668a8822c5"), new Guid("f9846378-7304-416a-bd56-a7d95cac76c8") },
                    { new Guid("5e6ac83e-2499-43da-9b07-454056199864"), new Guid("5be2e564-d78b-4758-b71a-93158c44ed39"), new Guid("bf4aaef8-562e-4f67-b0e8-5a2733931244") },
                    { new Guid("6acc0f79-4325-48b5-84f0-5b85ff3bd84b"), new Guid("5be2e564-d78b-4758-b71a-93158c44ed39"), new Guid("3a23c0d0-3834-439b-92f0-62296a15e51a") },
                    { new Guid("6ec86810-0f0a-43ab-9462-78a57f7a563e"), new Guid("5be2e564-d78b-4758-b71a-93158c44ed39"), new Guid("a198cd7d-309f-4ebe-ac84-89ba637193ef") },
                    { new Guid("8d64ba9c-bad2-412a-96a6-54cc23858c2c"), new Guid("7e348927-1292-4583-9412-087d0352236a"), new Guid("4857d2cc-4ec3-4f58-9f75-ef295f68e725") },
                    { new Guid("bfa85a77-0252-4cc9-b65b-14d6f942444e"), new Guid("bb0bd146-66f6-4fc6-a6ef-8ec426d7cf8b"), new Guid("3a23c0d0-3834-439b-92f0-62296a15e51a") },
                    { new Guid("c42af495-62d2-4a62-bf7e-79ff8a62ae8e"), new Guid("b42f15b8-6da6-4055-8971-95cfb0436f7d"), new Guid("f9846378-7304-416a-bd56-a7d95cac76c8") },
                    { new Guid("c4417640-ae84-4f45-a77a-8c0ca7881731"), new Guid("fe57bcee-9a97-494c-916e-e12fe61c2aa3"), new Guid("cfb6729f-9d15-4142-97a8-735ad2140c51") },
                    { new Guid("e1c6557e-2732-42ec-abba-f66ef675ca94"), new Guid("bb0bd146-66f6-4fc6-a6ef-8ec426d7cf8b"), new Guid("bf4aaef8-562e-4f67-b0e8-5a2733931244") },
                    { new Guid("fdd272f2-b6fa-487b-8c3c-b679363b857b"), new Guid("5be2e564-d78b-4758-b71a-93158c44ed39"), new Guid("4857d2cc-4ec3-4f58-9f75-ef295f68e725") }
                });

            migrationBuilder.InsertData(
                table: "tblOrderItem",
                columns: new[] { "Id", "Cost", "MovieId", "OrderId", "Quantity" },
                values: new object[,]
                {
                    { new Guid("2d6cf04c-3370-4c39-863f-06e07884cc9d"), 9.9900000000000002, new Guid("3a23c0d0-3834-439b-92f0-62296a15e51a"), new Guid("424501bf-96a4-4ce2-8057-094981f26c15"), 0 },
                    { new Guid("a8fc790a-78fa-4436-8452-966f85fefdab"), 8.9900000000000002, new Guid("bf4aaef8-562e-4f67-b0e8-5a2733931244"), new Guid("424501bf-96a4-4ce2-8057-094981f26c15"), 0 },
                    { new Guid("af95b2c3-688d-4a7b-acc4-9c4a91e37cae"), 10.99, new Guid("3a23c0d0-3834-439b-92f0-62296a15e51a"), new Guid("d6ee8c02-b008-415e-9e96-f214d9bedfa9"), 0 }
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

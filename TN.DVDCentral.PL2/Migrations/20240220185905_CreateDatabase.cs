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
                    { new Guid("0c929e50-c146-4a58-a062-ed60007d8b1d"), "987 Willow Road", "Slinger", "John", "Doro", "9202623345", "WI", new Guid("97876b90-63b0-40d7-9697-b5fb13eb13c2"), "56495" },
                    { new Guid("6a978aa6-e5f0-4d44-b05a-bbb2a790ceca"), "453 Oak Street", "Fond du Lac", "Steve", "Marin", "9205879797", "WI", new Guid("ed05b4b0-cc38-4549-9505-480f225dc135"), "54935" },
                    { new Guid("b520d8d7-152a-40e0-b2db-8ee42e3f739d"), "159 Johnson Avenue", "Allenton", "Brian", "Foote", "9202623415", "WI", new Guid("92583004-cf8f-47fa-9055-7af4620dc8ec"), "53142" }
                });

            migrationBuilder.InsertData(
                table: "tblDirector",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[,]
                {
                    { new Guid("3bfc900f-e0f1-44d0-8f18-93279623a5df"), "Clint", "Eastwood" },
                    { new Guid("6b86c69d-f020-403a-9eed-d831b59e4e4b"), "George", "Lucas" },
                    { new Guid("72a04064-fdf0-4794-af0d-d7a2a3a96c70"), "Other", "Other" },
                    { new Guid("88dc49f2-9955-4821-bacd-8bf85949ba35"), "Rob", "Reiner" },
                    { new Guid("a3962d0e-9390-4c7b-ac0a-c38e67d316f3"), "John", "Avildsen" },
                    { new Guid("eca68128-ae00-4a5c-b3d0-c3f52d3f7600"), "Steven", "Spielberg" }
                });

            migrationBuilder.InsertData(
                table: "tblFormat",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { new Guid("000512ce-8e47-4059-84d2-02dc72caef57"), "DVD" },
                    { new Guid("31bcc75a-2d3b-4b61-9d8d-5ede87a51bb6"), "VHS" },
                    { new Guid("550cacf1-8cce-430c-a7d8-9290232249f7"), "Other" },
                    { new Guid("9aa496be-0daa-46e2-9999-7e203f6edd70"), "Blu-Ray" }
                });

            migrationBuilder.InsertData(
                table: "tblGenre",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { new Guid("24073d54-e4db-43f7-b68f-2d7779e66612"), "Documentary" },
                    { new Guid("30d85d21-57e7-4c12-9b74-4adb80d8898e"), "Sci-Fi" },
                    { new Guid("7c9b4594-22a2-484b-8cdd-b2aae88420e9"), "Romance" },
                    { new Guid("9e9c618c-eca4-48c8-b7a7-57d1ae5d506c"), "Western" },
                    { new Guid("af84ec5a-4aff-4f0b-a91c-2267d8144322"), "Horror" },
                    { new Guid("dc137b92-eb56-41b8-8dfe-049c6dc08504"), "Mystery" },
                    { new Guid("e5bf982e-f6ac-4367-af21-62c8cbb41294"), "Musical" },
                    { new Guid("e8b75e63-a21f-4aa1-821b-87f696873661"), "Comedy" },
                    { new Guid("efec83bc-e889-4807-b553-77992a126db8"), "Action" },
                    { new Guid("f3b26c92-31d9-411a-8392-6e2c6311c1d0"), "Other" }
                });

            migrationBuilder.InsertData(
                table: "tblRating",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { new Guid("4b4b07a9-a816-47e2-a919-6dea5911f4a2"), "Other" },
                    { new Guid("769dcba4-e41e-414d-8121-57353e377527"), "R" },
                    { new Guid("99ebc812-8b6e-4920-b0df-aa554f348e6b"), "PG-13" },
                    { new Guid("b16c39e3-8a24-48f8-bcfd-bebc47b6c045"), "G" },
                    { new Guid("fde245dc-30d1-4c4c-a7a9-e673da309560"), "PG" }
                });

            migrationBuilder.InsertData(
                table: "tblUser",
                columns: new[] { "Id", "FirstName", "LastName", "Password", "UserName" },
                values: new object[,]
                {
                    { new Guid("92583004-cf8f-47fa-9055-7af4620dc8ec"), "Brian", "Foote", "pYfdnNb8sO0FgS4H0MRSwLGOIME=", "bfoote" },
                    { new Guid("97876b90-63b0-40d7-9697-b5fb13eb13c2"), "John", "Doro", "pYfdnNb8sO0FgS4H0MRSwLGOIME=", "jdoro" },
                    { new Guid("ed05b4b0-cc38-4549-9505-480f225dc135"), "Steve", "Marin", "pYfdnNb8sO0FgS4H0MRSwLGOIME=", "smarin" }
                });

            migrationBuilder.InsertData(
                table: "tblCart",
                columns: new[] { "Id", "UserId" },
                values: new object[,]
                {
                    { new Guid("717c2657-2dbd-465c-9406-066241f68edf"), new Guid("ed05b4b0-cc38-4549-9505-480f225dc135") },
                    { new Guid("ca7f2486-51ec-4a2d-8f92-3eeef4b49588"), new Guid("97876b90-63b0-40d7-9697-b5fb13eb13c2") }
                });

            migrationBuilder.InsertData(
                table: "tblMovie",
                columns: new[] { "Id", "Cost", "Description", "DirectorId", "FormatId", "ImagePath", "Quantity", "RatingId", "Title" },
                values: new object[,]
                {
                    { new Guid("009c321b-ef2f-4cb5-888c-164a3ac63d76"), 6.9900000000000002, "Rocky is a 1976 American sports drama film directed by John G. Avildsen, written by and starring Sylvester Stallone.", new Guid("a3962d0e-9390-4c7b-ac0a-c38e67d316f3"), new Guid("31bcc75a-2d3b-4b61-9d8d-5ede87a51bb6"), "Rocky.jpg", 2, new Guid("b16c39e3-8a24-48f8-bcfd-bebc47b6c045"), "Rocky" },
                    { new Guid("09b9d7ef-8a3f-46f9-bece-f48f039a4f9a"), 7.5, "Star Wars: Episode IV – A New Hope is a 1977 American epic space-opera film written and directed by George Lucas, produced by Lucasfilm and distributed by 20th Century Fox.", new Guid("eca68128-ae00-4a5c-b3d0-c3f52d3f7600"), new Guid("000512ce-8e47-4059-84d2-02dc72caef57"), "StarWarsNewHope.jpg", 1, new Guid("99ebc812-8b6e-4920-b0df-aa554f348e6b"), "Star Wars: Episode IV – A New Hope" },
                    { new Guid("5c01a5ab-9dda-402c-b1c4-04c7cb602e55"), 8.9900000000000002, "Jaws is a 1975 American thriller film directed by Steven Spielberg and based on the Peter Benchley 1974 novel of the same name.", new Guid("eca68128-ae00-4a5c-b3d0-c3f52d3f7600"), new Guid("000512ce-8e47-4059-84d2-02dc72caef57"), "Jaws1.jpg", 1, new Guid("99ebc812-8b6e-4920-b0df-aa554f348e6b"), "Jaws" },
                    { new Guid("6594aea4-d61d-4358-83e7-a5f906413435"), 12.5, "The Princess Bride is a 1987 American fantasy adventure comedy film directed and co-produced by Rob Reiner, starring Cary Elwes, Robin Wright, Mandy Patinkin, Chris Sarandon, Wallace Shawn, André the Giant, and Christopher Guest.", new Guid("88dc49f2-9955-4821-bacd-8bf85949ba35"), new Guid("9aa496be-0daa-46e2-9999-7e203f6edd70"), "PrincessBride.jpg", 4, new Guid("fde245dc-30d1-4c4c-a7a9-e673da309560"), "The Princess Bride" },
                    { new Guid("9ccf99f6-ab5f-4dcc-9404-8fe3f053551b"), 10.5, "Indiana Jones and the Last Crusade is a 1989 American action-adventure film directed by Steven Spielberg, from a story co-written by executive producer George Lucas.", new Guid("6b86c69d-f020-403a-9eed-d831b59e4e4b"), new Guid("9aa496be-0daa-46e2-9999-7e203f6edd70"), "IndianaJonesLastCrusade.jpg", 2, new Guid("769dcba4-e41e-414d-8121-57353e377527"), "Indiana Jones and the Last Crusade" },
                    { new Guid("ad4b9ce4-6f59-4a59-a4de-787859b3ce38"), 9.9900000000000002, "Pale Rider is a 1985 American Western film produced and directed by Clint Eastwood, who also stars in the lead role.", new Guid("eca68128-ae00-4a5c-b3d0-c3f52d3f7600"), new Guid("000512ce-8e47-4059-84d2-02dc72caef57"), "PaleRider.jpg", 1, new Guid("99ebc812-8b6e-4920-b0df-aa554f348e6b"), "Pale Rider" },
                    { new Guid("f93b4db6-e6da-498f-8139-71c16a1a5142"), 6.9900000000000002, "Other", new Guid("a3962d0e-9390-4c7b-ac0a-c38e67d316f3"), new Guid("31bcc75a-2d3b-4b61-9d8d-5ede87a51bb6"), "Rocky.jpg", 2, new Guid("b16c39e3-8a24-48f8-bcfd-bebc47b6c045"), "Other" }
                });

            migrationBuilder.InsertData(
                table: "tblOrder",
                columns: new[] { "Id", "CustomerId", "OrderDate", "ShipDate", "UserId" },
                values: new object[,]
                {
                    { new Guid("379bdffc-124c-4fbe-8328-1606f294de2f"), new Guid("0c929e50-c146-4a58-a062-ed60007d8b1d"), new DateTime(2017, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2017, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("97876b90-63b0-40d7-9697-b5fb13eb13c2") },
                    { new Guid("b4e91f1e-0c53-407b-b329-2ef836e06190"), new Guid("b520d8d7-152a-40e0-b2db-8ee42e3f739d"), new DateTime(2021, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("97876b90-63b0-40d7-9697-b5fb13eb13c2") },
                    { new Guid("dab66914-7cfb-4c1c-8181-2b7b7f56ad48"), new Guid("b520d8d7-152a-40e0-b2db-8ee42e3f739d"), new DateTime(2022, 10, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("92583004-cf8f-47fa-9055-7af4620dc8ec") }
                });

            migrationBuilder.InsertData(
                table: "tblCartItem",
                columns: new[] { "Id", "CartId", "MovieId", "Quantity" },
                values: new object[,]
                {
                    { new Guid("5a5effe0-2bbf-4ff2-9f04-93d2c5c18848"), new Guid("ca7f2486-51ec-4a2d-8f92-3eeef4b49588"), new Guid("5c01a5ab-9dda-402c-b1c4-04c7cb602e55"), 1 },
                    { new Guid("8fbe48e2-9be5-4f35-a218-586b76c7c945"), new Guid("717c2657-2dbd-465c-9406-066241f68edf"), new Guid("009c321b-ef2f-4cb5-888c-164a3ac63d76"), 1 },
                    { new Guid("b9542aee-f864-4e78-8b4d-c9b410efb2d7"), new Guid("717c2657-2dbd-465c-9406-066241f68edf"), new Guid("5c01a5ab-9dda-402c-b1c4-04c7cb602e55"), 2 }
                });

            migrationBuilder.InsertData(
                table: "tblMovieGenre",
                columns: new[] { "Id", "GenreId", "MovieId" },
                values: new object[,]
                {
                    { new Guid("208cd059-817e-474e-932e-aef997479287"), new Guid("af84ec5a-4aff-4f0b-a91c-2267d8144322"), new Guid("5c01a5ab-9dda-402c-b1c4-04c7cb602e55") },
                    { new Guid("3aa13a4e-8e9e-423e-8735-dd90d7b830ce"), new Guid("af84ec5a-4aff-4f0b-a91c-2267d8144322"), new Guid("9ccf99f6-ab5f-4dcc-9404-8fe3f053551b") },
                    { new Guid("4f742eba-16ad-4d45-8840-d893be42df00"), new Guid("24073d54-e4db-43f7-b68f-2d7779e66612"), new Guid("009c321b-ef2f-4cb5-888c-164a3ac63d76") },
                    { new Guid("62410701-5a6c-40f7-8dbe-503bb2d65141"), new Guid("dc137b92-eb56-41b8-8dfe-049c6dc08504"), new Guid("ad4b9ce4-6f59-4a59-a4de-787859b3ce38") },
                    { new Guid("6ebdaba1-2113-4caf-9f10-40baf3367e44"), new Guid("24073d54-e4db-43f7-b68f-2d7779e66612"), new Guid("9ccf99f6-ab5f-4dcc-9404-8fe3f053551b") },
                    { new Guid("9427e653-3442-47ba-8253-ce1943c0512e"), new Guid("af84ec5a-4aff-4f0b-a91c-2267d8144322"), new Guid("009c321b-ef2f-4cb5-888c-164a3ac63d76") },
                    { new Guid("9b5cd0b6-e85c-4fbe-aa3d-a13b5b7c45b5"), new Guid("af84ec5a-4aff-4f0b-a91c-2267d8144322"), new Guid("09b9d7ef-8a3f-46f9-bece-f48f039a4f9a") },
                    { new Guid("aacde5b9-36a4-47e4-ab4e-b4e38e5965a9"), new Guid("30d85d21-57e7-4c12-9b74-4adb80d8898e"), new Guid("009c321b-ef2f-4cb5-888c-164a3ac63d76") },
                    { new Guid("c1625214-0e0c-4b8e-9312-0d028c5c8b6a"), new Guid("e5bf982e-f6ac-4367-af21-62c8cbb41294"), new Guid("09b9d7ef-8a3f-46f9-bece-f48f039a4f9a") },
                    { new Guid("c4d1b6d1-60f2-46ba-a6b2-2f894a0f8c8b"), new Guid("30d85d21-57e7-4c12-9b74-4adb80d8898e"), new Guid("5c01a5ab-9dda-402c-b1c4-04c7cb602e55") },
                    { new Guid("c5ba3665-4d38-4936-80ed-74a9accdc601"), new Guid("e8b75e63-a21f-4aa1-821b-87f696873661"), new Guid("6594aea4-d61d-4358-83e7-a5f906413435") },
                    { new Guid("c5cee358-5fcf-415b-83c3-a38be83e4ff7"), new Guid("efec83bc-e889-4807-b553-77992a126db8"), new Guid("6594aea4-d61d-4358-83e7-a5f906413435") },
                    { new Guid("e0ff5fb6-0278-4d6e-aaed-978412b69364"), new Guid("24073d54-e4db-43f7-b68f-2d7779e66612"), new Guid("6594aea4-d61d-4358-83e7-a5f906413435") }
                });

            migrationBuilder.InsertData(
                table: "tblOrderItem",
                columns: new[] { "Id", "Cost", "MovieId", "OrderId", "Quantity" },
                values: new object[,]
                {
                    { new Guid("31e2f35b-37e4-4e4e-ba93-e424e21dc296"), 10.99, new Guid("5c01a5ab-9dda-402c-b1c4-04c7cb602e55"), new Guid("b4e91f1e-0c53-407b-b329-2ef836e06190"), 0 },
                    { new Guid("970770bf-0efd-4ae6-a9e6-9eb4b7ffe6d0"), 8.9900000000000002, new Guid("009c321b-ef2f-4cb5-888c-164a3ac63d76"), new Guid("379bdffc-124c-4fbe-8328-1606f294de2f"), 0 },
                    { new Guid("d5352479-a22a-4ece-a28f-e7202892985b"), 9.9900000000000002, new Guid("5c01a5ab-9dda-402c-b1c4-04c7cb602e55"), new Guid("379bdffc-124c-4fbe-8328-1606f294de2f"), 0 }
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

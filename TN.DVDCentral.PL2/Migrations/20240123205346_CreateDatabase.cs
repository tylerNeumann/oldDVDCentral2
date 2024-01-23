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
                name: "tblCartItem",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CartId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MovieId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Qty = table.Column<int>(type: "int", nullable: false)
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
                    { new Guid("2f2ee76d-ba8f-45ca-b75a-8ec8b7e3fffa"), "453 Oak Street", "Fond du Lac", "Steve", "Marin", "9205879797", "WI", new Guid("1c3534b6-dbd6-45d5-af1e-4534dcaac405"), "54935" },
                    { new Guid("639275be-b8a6-4e2b-8f21-ce776eb0069a"), "987 Willow Road", "Slinger", "John", "Doro", "9202623345", "WI", new Guid("c54d37de-62c6-4618-b9b3-572d63889e20"), "56495" },
                    { new Guid("8eb43006-d60a-499d-9291-a7a89027a1a3"), "159 Johnson Avenue", "Allenton", "Brian", "Foote", "9202623415", "WI", new Guid("76efa159-4f92-48d7-9f04-6ceb36ae1274"), "53142" }
                });

            migrationBuilder.InsertData(
                table: "tblDirector",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[,]
                {
                    { new Guid("02de908a-06a8-4b2a-835b-14482b08a4db"), "Clint", "Eastwood" },
                    { new Guid("21742ace-b696-4917-a60b-f607172500b6"), "Other", "Other" },
                    { new Guid("257781ec-41e0-4d10-9204-77501af48611"), "Steven", "Spielberg" },
                    { new Guid("5f4bde64-23db-4596-aa07-5be5732a090a"), "George", "Lucas" },
                    { new Guid("b412454f-e32b-4802-a49e-7fab9d38fbaa"), "John", "Avildsen" },
                    { new Guid("f53ae989-0583-4190-b7a2-f51b50e67875"), "Rob", "Reiner" }
                });

            migrationBuilder.InsertData(
                table: "tblFormat",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { new Guid("237d70f8-5956-4ac6-ab86-4ff80b50e10a"), "VHS" },
                    { new Guid("28da639c-13fc-4c10-8cb8-c40241c7b2b7"), "DVD" },
                    { new Guid("2fce2f29-ca74-477d-9675-e22ebd29d551"), "Other" },
                    { new Guid("9a7ae84f-b5eb-4e84-8f79-6da6ad11cdae"), "Blu-Ray" }
                });

            migrationBuilder.InsertData(
                table: "tblGenre",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { new Guid("07bf4cd3-f31d-46ef-9d38-7448e2de7843"), "Western" },
                    { new Guid("1163ca18-4826-44b3-a4f2-5d22c5949b82"), "Other" },
                    { new Guid("30250b51-de3d-4c31-9945-baa42b4045e6"), "Sci-Fi" },
                    { new Guid("46d6c105-e800-46d1-b2b0-f0f79ec5c68b"), "Mystery" },
                    { new Guid("552e90f2-7ba5-4a63-98ce-b22af2e5b2e0"), "Horror" },
                    { new Guid("94115536-2970-479e-8b75-104e1a2754d5"), "Romance" },
                    { new Guid("9a6d5011-b53f-4aca-93c7-3982805670ac"), "Comedy" },
                    { new Guid("c1a0c9ba-c006-40e6-9d96-0b47e0af0aa9"), "Musical" },
                    { new Guid("eb0da3e9-b2c0-4e8c-9e60-b77652619057"), "Action" },
                    { new Guid("f79941bf-4261-4d77-b1e0-eac40a351d33"), "Documentary" }
                });

            migrationBuilder.InsertData(
                table: "tblOrder",
                columns: new[] { "Id", "CustomerId", "OrderDate", "ShipDate", "UserId" },
                values: new object[,]
                {
                    { new Guid("5775792d-d638-46d6-ae1c-1b8584f3f84d"), new Guid("8eb43006-d60a-499d-9291-a7a89027a1a3"), new DateTime(2022, 10, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("76efa159-4f92-48d7-9f04-6ceb36ae1274") },
                    { new Guid("95101d80-5af1-4f08-94ea-f222064e581b"), new Guid("639275be-b8a6-4e2b-8f21-ce776eb0069a"), new DateTime(2017, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2017, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("c54d37de-62c6-4618-b9b3-572d63889e20") },
                    { new Guid("cfc0ca9f-6290-4d1a-88b4-958ed0c82756"), new Guid("8eb43006-d60a-499d-9291-a7a89027a1a3"), new DateTime(2021, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("c54d37de-62c6-4618-b9b3-572d63889e20") }
                });

            migrationBuilder.InsertData(
                table: "tblOrderItem",
                columns: new[] { "Id", "Cost", "MovieId", "OrderId", "Quantity" },
                values: new object[,]
                {
                    { new Guid("a5deca7e-4c7d-415f-997e-1441bea3c465"), 10.99, new Guid("8f9158df-1e1b-41dc-bfbc-d6e9a3e8c205"), new Guid("cfc0ca9f-6290-4d1a-88b4-958ed0c82756"), 0 },
                    { new Guid("a9b68375-d259-4232-ba93-02045fbaca5e"), 8.9900000000000002, new Guid("bbddac5e-72c3-4db1-a50b-8498f7f117d8"), new Guid("95101d80-5af1-4f08-94ea-f222064e581b"), 0 },
                    { new Guid("dc1f2fba-3980-4f4e-89d0-40e7e512f9d9"), 9.9900000000000002, new Guid("8f9158df-1e1b-41dc-bfbc-d6e9a3e8c205"), new Guid("95101d80-5af1-4f08-94ea-f222064e581b"), 0 }
                });

            migrationBuilder.InsertData(
                table: "tblRating",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { new Guid("07949f29-e64e-4489-aeb6-952603f93e09"), "Other" },
                    { new Guid("7bcb352a-c319-4a7c-8fec-0e9550cb92df"), "PG" },
                    { new Guid("865591cf-df4e-4e6f-aece-c3865a7422f9"), "G" },
                    { new Guid("e0869197-fded-4543-938c-020d04491f9a"), "R" },
                    { new Guid("f6945cd3-a39e-4dcb-b98f-4bd584adba0c"), "PG-13" }
                });

            migrationBuilder.InsertData(
                table: "tblUser",
                columns: new[] { "Id", "FirstName", "LastName", "Password", "UserName" },
                values: new object[,]
                {
                    { new Guid("1c3534b6-dbd6-45d5-af1e-4534dcaac405"), "Steve", "Marin", "pYfdnNb8sO0FgS4H0MRSwLGOIME=", "smarin" },
                    { new Guid("76efa159-4f92-48d7-9f04-6ceb36ae1274"), "Brian", "Foote", "pYfdnNb8sO0FgS4H0MRSwLGOIME=", "bfoote" },
                    { new Guid("c54d37de-62c6-4618-b9b3-572d63889e20"), "John", "Doro", "pYfdnNb8sO0FgS4H0MRSwLGOIME=", "jdoro" }
                });

            migrationBuilder.InsertData(
                table: "tblCart",
                columns: new[] { "Id", "UserId" },
                values: new object[,]
                {
                    { new Guid("217e0167-d876-46e0-8bd3-ff26ffae89e3"), new Guid("c54d37de-62c6-4618-b9b3-572d63889e20") },
                    { new Guid("5e0f3f22-d753-4b95-84a6-3bbb2577de75"), new Guid("1c3534b6-dbd6-45d5-af1e-4534dcaac405") }
                });

            migrationBuilder.InsertData(
                table: "tblMovie",
                columns: new[] { "Id", "Cost", "Description", "DirectorId", "FormatId", "ImagePath", "Quantity", "RatingId", "Title" },
                values: new object[,]
                {
                    { new Guid("1dacec1f-deaf-41d1-932b-acd6f228cf56"), 6.9900000000000002, "Other", new Guid("b412454f-e32b-4802-a49e-7fab9d38fbaa"), new Guid("237d70f8-5956-4ac6-ab86-4ff80b50e10a"), "Rocky.jpg", 2, new Guid("865591cf-df4e-4e6f-aece-c3865a7422f9"), "Other" },
                    { new Guid("401e3be3-9cdb-4f8e-afa2-8973cf6d57fb"), 7.5, "Star Wars: Episode IV – A New Hope is a 1977 American epic space-opera film written and directed by George Lucas, produced by Lucasfilm and distributed by 20th Century Fox.", new Guid("257781ec-41e0-4d10-9204-77501af48611"), new Guid("28da639c-13fc-4c10-8cb8-c40241c7b2b7"), "StarWarsNewHope.jpg", 1, new Guid("f6945cd3-a39e-4dcb-b98f-4bd584adba0c"), "Star Wars: Episode IV – A New Hope" },
                    { new Guid("8a29e702-8646-4690-8da0-833aa6bb13a1"), 12.5, "The Princess Bride is a 1987 American fantasy adventure comedy film directed and co-produced by Rob Reiner, starring Cary Elwes, Robin Wright, Mandy Patinkin, Chris Sarandon, Wallace Shawn, André the Giant, and Christopher Guest.", new Guid("f53ae989-0583-4190-b7a2-f51b50e67875"), new Guid("9a7ae84f-b5eb-4e84-8f79-6da6ad11cdae"), "PrincessBride.jpg", 4, new Guid("7bcb352a-c319-4a7c-8fec-0e9550cb92df"), "The Princess Bride" },
                    { new Guid("8f9158df-1e1b-41dc-bfbc-d6e9a3e8c205"), 8.9900000000000002, "Jaws is a 1975 American thriller film directed by Steven Spielberg and based on the Peter Benchley 1974 novel of the same name.", new Guid("257781ec-41e0-4d10-9204-77501af48611"), new Guid("28da639c-13fc-4c10-8cb8-c40241c7b2b7"), "Jaws1.jpg", 1, new Guid("f6945cd3-a39e-4dcb-b98f-4bd584adba0c"), "Jaws" },
                    { new Guid("b5485a28-b011-4e79-b6b8-de99f874ce69"), 9.9900000000000002, "Pale Rider is a 1985 American Western film produced and directed by Clint Eastwood, who also stars in the lead role.", new Guid("257781ec-41e0-4d10-9204-77501af48611"), new Guid("28da639c-13fc-4c10-8cb8-c40241c7b2b7"), "PaleRider.jpg", 1, new Guid("f6945cd3-a39e-4dcb-b98f-4bd584adba0c"), "Pale Rider" },
                    { new Guid("bbddac5e-72c3-4db1-a50b-8498f7f117d8"), 6.9900000000000002, "Rocky is a 1976 American sports drama film directed by John G. Avildsen, written by and starring Sylvester Stallone.", new Guid("b412454f-e32b-4802-a49e-7fab9d38fbaa"), new Guid("237d70f8-5956-4ac6-ab86-4ff80b50e10a"), "Rocky.jpg", 2, new Guid("865591cf-df4e-4e6f-aece-c3865a7422f9"), "Rocky" },
                    { new Guid("dc3b2c9f-0efb-4ffa-831d-774555c20b24"), 10.5, "Indiana Jones and the Last Crusade is a 1989 American action-adventure film directed by Steven Spielberg, from a story co-written by executive producer George Lucas.", new Guid("5f4bde64-23db-4596-aa07-5be5732a090a"), new Guid("9a7ae84f-b5eb-4e84-8f79-6da6ad11cdae"), "IndianaJonesLastCrusade.jpg", 2, new Guid("e0869197-fded-4543-938c-020d04491f9a"), "Indiana Jones and the Last Crusade" }
                });

            migrationBuilder.InsertData(
                table: "tblCartItem",
                columns: new[] { "Id", "CartId", "MovieId", "Qty" },
                values: new object[,]
                {
                    { new Guid("12734636-a0cf-4354-b26a-d114cb4c2ac0"), new Guid("5e0f3f22-d753-4b95-84a6-3bbb2577de75"), new Guid("8f9158df-1e1b-41dc-bfbc-d6e9a3e8c205"), 2 },
                    { new Guid("663198c8-fcdc-49a1-9436-a678c572215f"), new Guid("5e0f3f22-d753-4b95-84a6-3bbb2577de75"), new Guid("bbddac5e-72c3-4db1-a50b-8498f7f117d8"), 1 },
                    { new Guid("f3e1c648-88ff-4e94-94c6-4dd2090a28f9"), new Guid("217e0167-d876-46e0-8bd3-ff26ffae89e3"), new Guid("8f9158df-1e1b-41dc-bfbc-d6e9a3e8c205"), 1 }
                });

            migrationBuilder.InsertData(
                table: "tblMovieGenre",
                columns: new[] { "Id", "GenreId", "MovieId" },
                values: new object[,]
                {
                    { new Guid("008f0fcb-be1f-46eb-97e3-bca76f1f4351"), new Guid("30250b51-de3d-4c31-9945-baa42b4045e6"), new Guid("bbddac5e-72c3-4db1-a50b-8498f7f117d8") },
                    { new Guid("0b86b8b1-b76b-40ea-a1fb-bcf2200730e6"), new Guid("30250b51-de3d-4c31-9945-baa42b4045e6"), new Guid("8f9158df-1e1b-41dc-bfbc-d6e9a3e8c205") },
                    { new Guid("150e4d37-fb9f-459f-bac1-dc983c5443bd"), new Guid("552e90f2-7ba5-4a63-98ce-b22af2e5b2e0"), new Guid("8f9158df-1e1b-41dc-bfbc-d6e9a3e8c205") },
                    { new Guid("241dcadb-8377-4362-82f2-eaed8c0085e5"), new Guid("552e90f2-7ba5-4a63-98ce-b22af2e5b2e0"), new Guid("bbddac5e-72c3-4db1-a50b-8498f7f117d8") },
                    { new Guid("33769060-6657-499f-9b55-694d686d52dc"), new Guid("552e90f2-7ba5-4a63-98ce-b22af2e5b2e0"), new Guid("dc3b2c9f-0efb-4ffa-831d-774555c20b24") },
                    { new Guid("44ebbb48-f120-47c9-b860-7d755a829e7d"), new Guid("eb0da3e9-b2c0-4e8c-9e60-b77652619057"), new Guid("8a29e702-8646-4690-8da0-833aa6bb13a1") },
                    { new Guid("69dd79d3-6fd6-4411-b081-69ca78a1ff6c"), new Guid("f79941bf-4261-4d77-b1e0-eac40a351d33"), new Guid("8a29e702-8646-4690-8da0-833aa6bb13a1") },
                    { new Guid("6be222ff-7695-43fe-977c-a89cf732fefb"), new Guid("f79941bf-4261-4d77-b1e0-eac40a351d33"), new Guid("bbddac5e-72c3-4db1-a50b-8498f7f117d8") },
                    { new Guid("890572a1-5484-4c0c-baa8-53f22f8c878e"), new Guid("552e90f2-7ba5-4a63-98ce-b22af2e5b2e0"), new Guid("401e3be3-9cdb-4f8e-afa2-8973cf6d57fb") },
                    { new Guid("cbab7362-4132-4c1e-a214-49a20c325175"), new Guid("46d6c105-e800-46d1-b2b0-f0f79ec5c68b"), new Guid("b5485a28-b011-4e79-b6b8-de99f874ce69") },
                    { new Guid("d9366dfc-4f6b-4f32-97d2-4f35036e2f45"), new Guid("c1a0c9ba-c006-40e6-9d96-0b47e0af0aa9"), new Guid("401e3be3-9cdb-4f8e-afa2-8973cf6d57fb") },
                    { new Guid("daecb85f-d306-4787-ae52-860d05baf909"), new Guid("f79941bf-4261-4d77-b1e0-eac40a351d33"), new Guid("dc3b2c9f-0efb-4ffa-831d-774555c20b24") },
                    { new Guid("f7438bbc-30ad-4646-963e-069914e6f908"), new Guid("9a6d5011-b53f-4aca-93c7-3982805670ac"), new Guid("8a29e702-8646-4690-8da0-833aa6bb13a1") }
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblCartItem");

            migrationBuilder.DropTable(
                name: "tblCustomer");

            migrationBuilder.DropTable(
                name: "tblMovieGenre");

            migrationBuilder.DropTable(
                name: "tblOrder");

            migrationBuilder.DropTable(
                name: "tblOrderItem");

            migrationBuilder.DropTable(
                name: "tblCart");

            migrationBuilder.DropTable(
                name: "tblGenre");

            migrationBuilder.DropTable(
                name: "tblMovie");

            migrationBuilder.DropTable(
                name: "tblUser");

            migrationBuilder.DropTable(
                name: "tblDirector");

            migrationBuilder.DropTable(
                name: "tblFormat");

            migrationBuilder.DropTable(
                name: "tblRating");
        }
    }
}

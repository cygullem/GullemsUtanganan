using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GULLEMNEWMVC.Migrations
{
    /// <inheritdoc />
    public partial class UpdateLoanSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClientInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UerType = table.Column<int>(type: "int", nullable: true),
                    FirstName = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    MiddleName = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    LastName = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Address = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    ZipCode = table.Column<int>(type: "int", nullable: true),
                    Birthday = table.Column<DateTime>(type: "date", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: true),
                    NameOfFather = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    NameOfMother = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    CivilStatus = table.Column<string>(name: "Civil_Status", type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Religion = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Occupation = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ClientIn__3214EC0708E42098", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__UserType__3214EC075EC7863B", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Loan",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Borrower = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    Term = table.Column<int>(type: "int", nullable: false),
                    Payment = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    PaymentAmount = table.Column<float>(type: "real", nullable: false),
                    InterestAmount = table.Column<float>(type: "real", nullable: false),
                    TotalAmount = table.Column<float>(type: "real", nullable: false),
                    Interest = table.Column<float>(type: "real", nullable: false),
                    Deduction = table.Column<float>(type: "real", nullable: false),
                    ReceivableAmount = table.Column<float>(type: "real", nullable: false),
                    Status = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    DueDate = table.Column<DateTime>(type: "date", nullable: false),
                    dateCreated = table.Column<DateTime>(type: "datetime2", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Loan__3214EC07BBECB326", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Loan_ClientInfo_Borrower",
                        column: x => x.Borrower,
                        principalTable: "ClientInfo",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Loan_Borrower",
                table: "Loan",
                column: "Borrower");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Loan");

            migrationBuilder.DropTable(
                name: "UserType");

            migrationBuilder.DropTable(
                name: "ClientInfo");
        }
    }
}

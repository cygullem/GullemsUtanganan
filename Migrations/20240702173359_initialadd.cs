using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GULLEMNEWMVC.Migrations
{
    /// <inheritdoc />
    public partial class initialadd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Loan_ClientInfo_Borrower",
                table: "Loan");

            migrationBuilder.RenameColumn(
                name: "dateCreated",
                table: "Loan",
                newName: "DateCreated");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Loan",
                type: "datetime",
                rowVersion: true,
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldRowVersion: true);

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Loan",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: false,
                defaultValue: "unpaid",
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldUnicode: false,
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Payment",
                table: "Loan",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldUnicode: false,
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<int>(
                name: "Borrower",
                table: "Loan",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Loan_ClientInfo_Borrower",
                table: "Loan",
                column: "Borrower",
                principalTable: "ClientInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Loan_ClientInfo_Borrower",
                table: "Loan");

            migrationBuilder.RenameColumn(
                name: "DateCreated",
                table: "Loan",
                newName: "dateCreated");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Loan",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldUnicode: false,
                oldMaxLength: 50,
                oldDefaultValue: "unpaid");

            migrationBuilder.AlterColumn<string>(
                name: "Payment",
                table: "Loan",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldUnicode: false,
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "dateCreated",
                table: "Loan",
                type: "datetime2",
                rowVersion: true,
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldRowVersion: true);

            migrationBuilder.AlterColumn<int>(
                name: "Borrower",
                table: "Loan",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Loan_ClientInfo_Borrower",
                table: "Loan",
                column: "Borrower",
                principalTable: "ClientInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}

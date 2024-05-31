﻿// <auto-generated />
using System;
using GULLEM_NEW_MVC.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GULLEMNEWMVC.Migrations
{
    [DbContext(typeof(GullemsUtangananContext))]
    partial class GullemsUtangananContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GULLEM_NEW_MVC.Entities.ClientInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<int?>("Age")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Birthday")
                        .HasColumnType("date");

                    b.Property<string>("CivilStatus")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("Civil_Status");

                    b.Property<string>("FirstName")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("LastName")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("MiddleName")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("NameOfFather")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("NameOfMother")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Occupation")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Religion")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<int?>("UerType")
                        .HasColumnType("int");

                    b.Property<int?>("ZipCode")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PK__ClientIn__3214EC0708E42098");

                    b.ToTable("ClientInfo", (string)null);
                });

            modelBuilder.Entity("GULLEM_NEW_MVC.Entities.Loan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<int>("Borrower")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreated")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasColumnName("dateCreated");

                    b.Property<float>("Deduction")
                        .HasColumnType("real");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("date");

                    b.Property<float>("Interest")
                        .HasColumnType("real");

                    b.Property<float>("InterestAmount")
                        .HasColumnType("real");

                    b.Property<string>("Payment")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.Property<float>("PaymentAmount")
                        .HasColumnType("real")
                        .HasColumnName("PaymentAmount");

                    b.Property<float>("ReceivableAmount")
                        .HasColumnType("real");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("Term")
                        .HasColumnType("int");

                    b.Property<float>("TotalAmount")
                        .HasColumnType("real")
                        .HasColumnName("TotalAmount");

                    b.HasKey("Id")
                        .HasName("PK__Loan__3214EC07BBECB326");

                    b.HasIndex("Borrower");

                    b.ToTable("Loan", (string)null);
                });

            modelBuilder.Entity("GULLEM_NEW_MVC.Entities.UserType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("PK__UserType__3214EC075EC7863B");

                    b.ToTable("UserType", (string)null);
                });

            modelBuilder.Entity("GULLEM_NEW_MVC.Entities.Loan", b =>
                {
                    b.HasOne("GULLEM_NEW_MVC.Entities.ClientInfo", "ClientInfo")
                        .WithMany("Loans")
                        .HasForeignKey("Borrower")
                        .IsRequired();

                    b.Navigation("ClientInfo");
                });

            modelBuilder.Entity("GULLEM_NEW_MVC.Entities.ClientInfo", b =>
                {
                    b.Navigation("Loans");
                });
#pragma warning restore 612, 618
        }
    }
}
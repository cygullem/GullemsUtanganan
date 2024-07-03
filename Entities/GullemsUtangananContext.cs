using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace GULLEM_NEW_MVC.Entities
{
    public partial class GullemsUtangananContext : DbContext
    {
        public GullemsUtangananContext() { }

        public GullemsUtangananContext(DbContextOptions<GullemsUtangananContext> options)
            : base(options) 
            { 
            }

        public virtual DbSet<ClientInfo> ClientInfos { get; set; }
        public virtual DbSet<UserType> UserTypes { get; set; }
        public virtual DbSet<Loan> Loans { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=GullemsUtanganan;TrustServerCertificate=true;Trusted_Connection=True");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClientInfo>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__ClientIn__3214EC0708E42098");

                entity.ToTable("ClientInfo");

                entity.Property(e => e.Address)
                    .HasMaxLength(255)
                    .IsUnicode(false);
                entity.Property(e => e.Birthday).HasColumnType("date");
                entity.Property(e => e.CivilStatus)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("Civil_Status");
                entity.Property(e => e.FirstName)
                    .HasMaxLength(255)
                    .IsUnicode(false);
                entity.Property(e => e.LastName)
                    .HasMaxLength(255)
                    .IsUnicode(false);
                entity.Property(e => e.MiddleName)
                    .HasMaxLength(255)
                    .IsUnicode(false);
                entity.Property(e => e.NameOfFather)
                    .HasMaxLength(255)
                    .IsUnicode(false);
                entity.Property(e => e.NameOfMother)
                    .HasMaxLength(255)
                    .IsUnicode(false);
                entity.Property(e => e.Occupation)
                    .HasMaxLength(255)
                    .IsUnicode(false);
                entity.Property(e => e.Religion)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Loan>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Loan__3214EC07BBECB326");

                entity.ToTable("Loan");

                entity.Property(e => e.DateCreated)
                    .HasColumnType("datetime")
                    .IsRequired();

                entity.Property(e => e.DueDate)
                    .HasColumnType("date");

                entity.Property(e => e.Payment)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValue("unpaid");

                entity.Property(e => e.Amount)
                    .IsRequired()
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Term)
                    .IsRequired();

                entity.Property(e => e.AmountPaid)
                    .HasColumnName("AmountPaid")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.InterestAmount)
                    .HasColumnName("InterestAmount")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Total)
                    .HasColumnName("Total")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Interest)
                    .HasColumnName("Interest")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Deduction)
                    .HasColumnName("Deduction")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ReceivableAmount)
                    .HasColumnName("ReceivableAmount")
                    .HasColumnType("decimal(18, 2)");

                // Configure relationship with ClientInfo
                entity.HasOne(e => e.ClientInfo)
                    .WithMany(c => c.Loans)
                    .HasForeignKey(e => e.Borrower)
                    .IsRequired(false)
                    .OnDelete(DeleteBehavior.Restrict);
            });



            modelBuilder.Entity<UserType>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__UserType__3214EC075EC7863B");

                entity.ToTable("UserType");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

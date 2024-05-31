using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace GULLEM_NEW_MVC.Entities;

public partial class GullemsUtangananContext : DbContext
{
    public GullemsUtangananContext()
    {
    }

    public GullemsUtangananContext(DbContextOptions<GullemsUtangananContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ClientInfo> ClientInfos { get; set; }
    public virtual DbSet<UserType> UserTypes { get; set; }
    public virtual DbSet<Loan> Loans { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
// #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
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

                // Define relationship with Loan
                entity.HasMany(e => e.Loans)
                      .WithOne(l => l.ClientInfo)
                      .HasForeignKey(l => l.Borrower);
            });

            modelBuilder.Entity<Loan>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Loan__3214EC07BBECB326");

                entity.ToTable("Loan");

                entity.Property(e => e.DateCreated)
                    .HasColumnName("dateCreated")
                    .IsRowVersion()
                    .IsConcurrencyToken();
                entity.Property(e => e.DueDate).HasColumnType("date");
                entity.Property(e => e.Payment)
                    .HasMaxLength(20)
                    .IsUnicode(false);
                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PaymentAmount).HasColumnName("PaymentAmount");
                entity.Property(e => e.TotalAmount).HasColumnName("TotalAmount");
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

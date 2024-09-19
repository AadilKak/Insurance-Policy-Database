using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Insurance.Models;

public partial class ProjectInsuranceContext : DbContext
{
    public ProjectInsuranceContext()
    {
    }

    public ProjectInsuranceContext(DbContextOptions<ProjectInsuranceContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Policy> Policies { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=ProjectInsurance;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Policy>(entity =>
        {
            entity.HasKey(e => e.PolicyNumber);

            entity.ToTable("Policy");

            entity.Property(e => e.Beneficiary)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Coverage).HasMaxLength(100);
            entity.Property(e => e.CustomerEmail).HasMaxLength(50);
            entity.Property(e => e.CustomerFirstName).HasMaxLength(50);
            entity.Property(e => e.CustomerLastName).HasMaxLength(50);
            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.ExistingConditions)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.HomeAddress)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.HouseArea)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.HousePrice)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(2, 0)");
            entity.Property(e => e.Make)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Model)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.MonthlyPayment)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(2, 0)");
            entity.Property(e => e.StartDate).HasColumnType("datetime");
            entity.Property(e => e.Vin)
                .HasMaxLength(15)
                .IsFixedLength()
                .HasColumnName("VIN");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

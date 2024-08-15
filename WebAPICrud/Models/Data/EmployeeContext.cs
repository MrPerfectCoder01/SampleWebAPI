using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebAPICrud.Models.Data;

public partial class EmployeeContext : DbContext
{
    public EmployeeContext()
    {
    }

    public EmployeeContext(DbContextOptions<EmployeeContext> options)
        : base(options)
    {
    }

    public virtual DbSet<EmployeeCity> EmployeeCities { get; set; }

    public virtual DbSet<EmployeeDetail> EmployeeDetails { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if(!optionsBuilder.IsConfigured)
        {

        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EmployeeCity>(entity =>
        {
            entity.ToTable("EmployeeCity");

            entity.Property(e => e.City)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<EmployeeDetail>(entity =>
        {
            entity.HasKey(e => e.EmpId);

            entity.ToTable("EmployeeDetail");

            entity.Property(e => e.EmpAddress)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.EmpName)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.EmpPhone)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.EmpRegion)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.EmployeeEmail)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

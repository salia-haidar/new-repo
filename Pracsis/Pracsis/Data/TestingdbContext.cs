using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pracsis.Models;

namespace Pracsis.DB;

public partial class TestingdbContext : DbContext
{
    public TestingdbContext()
    {
    }

    public TestingdbContext(DbContextOptions<TestingdbContext> options) : base(options)
    {
    }

    public virtual DbSet<Designation> Designations { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server = 10.10.30.162; Database = testingdb; User Id = mtbcweb; Password = mtbcweb@mtbc;Encrypt = false");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Designation>(entity =>
        {
            entity.HasKey(e => e.Id)
                .HasName("PK__Designat__3214EC070C7183B2")
                .HasFillFactor(75);

            entity.ToTable("Designation");

            entity.Property(e => e.AtPlace).HasMaxLength(50);
            entity.Property(e => e.Designation1)
                .HasMaxLength(50)
                .HasColumnName("Designation");
            entity.Property(e => e.YourName).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

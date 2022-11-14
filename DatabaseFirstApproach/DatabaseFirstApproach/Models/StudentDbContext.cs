using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DatabaseFirstApproach.Models;

public partial class StudentDbContext : DbContext
{
    public StudentDbContext()
    {
    }

    public StudentDbContext(DbContextOptions<StudentDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<StudentDb> StudentDbs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=AYAN\\SQLEXPRESS;Database=StudentDB;Integrated Security=True;Encrypt = False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<StudentDb>(entity =>
        {
            entity.HasKey(e => e.StudentId);

            entity.ToTable("studentDB");

            entity.Property(e => e.StudentId)
                .ValueGeneratedNever()
                .HasColumnName("studentID");
            entity.Property(e => e.Course)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("course");
            entity.Property(e => e.Department)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("department");
            entity.Property(e => e.StudentName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("studentName");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

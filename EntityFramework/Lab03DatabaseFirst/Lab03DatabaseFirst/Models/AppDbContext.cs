using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Lab03DatabaseFirst.Models;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Dummytable> Dummytables { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Project> Projects { get; set; }

    public virtual DbSet<WorksOn> WorksOns { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
    {
        optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=AmiraCompany;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;");
        optionsBuilder.LogTo(message => System.Diagnostics.Debug.WriteLine(message), Microsoft.Extensions.Logging.LogLevel.Information);

        base.OnConfiguring(optionsBuilder);
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.DeptNo).HasName("PK__Departme__0148CAAE2EB6A76E");

            entity.ToTable("Department");

            entity.Property(e => e.DeptNo)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.DeptName)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Location)
                .HasMaxLength(3)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Dummytable>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("DUMMYTABLE");

            entity.Property(e => e.EmpId).HasColumnName("EmpID");
            entity.Property(e => e.Hours).HasColumnName("hours");
            entity.Property(e => e.ProjectId).HasColumnName("ProjectID");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmpNo).HasName("PK__Employee__AF2D66D38DC03445");

            entity.ToTable("Employee");

            entity.Property(e => e.EmpNo).ValueGeneratedNever();
            entity.Property(e => e.DeptNo)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Fname)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Lname)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.DeptNoNavigation).WithMany(p => p.Employees)
                .HasForeignKey(d => d.DeptNo)
                .HasConstraintName("FK__Employee__DeptNo__5BE2A6F2");
        });

        modelBuilder.Entity<Project>(entity =>
        {
            entity.HasKey(e => e.ProjectNo);

            entity.ToTable("Project");

            entity.Property(e => e.ProjectNo)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.ProjectName)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<WorksOn>(entity =>
        {
            entity.HasKey(e => new { e.EmpNo, e.ProjectNo });

            entity.ToTable("Works_on");

            entity.Property(e => e.ProjectNo)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.EnterDate).HasDefaultValueSql("(current_date)", "DF_Works_on_EnterDate");
            entity.Property(e => e.Job)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.EmpNoNavigation).WithMany(p => p.WorksOns)
                .HasForeignKey(d => d.EmpNo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EmpNo_Employee_Works_on");

            entity.HasOne(d => d.ProjectNoNavigation).WithMany(p => p.WorksOns)
                .HasForeignKey(d => d.ProjectNo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Project_Works_on");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

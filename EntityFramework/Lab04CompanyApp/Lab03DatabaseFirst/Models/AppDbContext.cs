using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace CompanyApp.Models
{
    public class AppDbContext : DbContext
    {
       
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            var connString = config.GetSection("constr").Value;
            optionsBuilder.UseSqlServer(connString);

            // Lazy Loading only works with virtual navigation properties
            //optionsBuilder.UseLazyLoadingProxies(true);

            optionsBuilder
                .LogTo(message => Debug.WriteLine(message),
                       new[] { DbLoggerCategory.Database.Command.Name },
                       LogLevel.Information);

        }
        // DbSets
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<WorksOn> WorksOn { get; set; }
        public DbSet<DepartmentLocations> DepartmentLocations { get; set; }
        public DbSet<Dependent> Dependents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee");

                entity.HasKey(e => e.SSN)
                      .HasName("PK_Employee_SSN");

                // Employee - Department (Many-to-One)
                entity.HasOne(e => e.Department)
                      .WithMany(d => d.Employees)
                      .HasForeignKey(e => e.DeptNum)
                      .OnDelete(DeleteBehavior.SetNull);

                // Employee - Manager (Self Reference)
                entity.HasOne(e => e.Manager)
                      .WithMany(e => e.Subordinates)
                      .HasForeignKey(e => e.MGR_SSN)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.Property(e => e.SSN).HasDefaultValueSql("NEWID()").ValueGeneratedOnAdd().IsRequired();

                entity.Property(e => e.FName)
                      .IsRequired()
                      .HasMaxLength(50);

                entity.Property(e => e.LName)
                      .IsRequired()
                      .HasMaxLength(50);

                entity.Property(e => e.gender)
                      .HasConversion<string>()
                      .IsRequired();

                entity.Property(e => e.Address)
                      .IsRequired(false);

                //entity.Property(e => e.BDate)
                //      .HasConversion<DateOnly>();

                entity.Property(e => e.DeptNum)
                      .IsRequired(false);

                entity.Property(e => e.MGR_SSN)
                      .IsRequired(false);
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.ToTable("Department");

                entity.HasKey(d => d.ID)
                      .HasName("PK_Department_ID");

                // Department Manager (One-to-One)
                entity.HasOne(d => d.DepartmentManager)
                      .WithMany()
                      .HasForeignKey(d => d.MGR_SSN)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.Property(d => d.ID)
                      .ValueGeneratedOnAdd();

                entity.HasIndex(u => u.Name)
                      .IsUnique();   

                //entity.Property(d => d.MGR_SSN)
                //      .IsRequired();

                entity.Property(d => d.MGR_StartDate)
                      .HasDefaultValueSql("GETDATE()");
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.ToTable("Project");

                entity.HasKey(p => p.ProjectNumber)
                      .HasName("PK_Project");

                entity.HasOne(p => p.Department)
                      .WithMany(d => d.Projects)
                      .HasForeignKey(p => p.DepartmentNum)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.Property(p => p.ProjectNumber)
                      .ValueGeneratedOnAdd();
            });

         
            modelBuilder.Entity<WorksOn>(entity =>
            {
                entity.ToTable("WorksOn");

                entity.HasKey(w => new { w.ProjectNumber, w.EmployeeSSN })
                      .HasName("PK_WorksOn");

                entity.HasOne(w => w.Project)
                      .WithMany(p => p.EmployeeProject)
                      .HasForeignKey(w => w.ProjectNumber);

                entity.HasOne(w => w.Employee)
                      .WithMany(e => e.EmployeeProject)
                      .HasForeignKey(w => w.EmployeeSSN);
            });

     
            modelBuilder.Entity<DepartmentLocations>(entity =>
            {
                entity.ToTable("DepartmentLocations");

                entity.HasKey(dl => new { dl.DepartmentNum, dl.Location })
                      .HasName("PK_DepartmentLocations");

                entity.HasOne(dl => dl.Department)
                      .WithMany(d => d.Locations)
                      .HasForeignKey(dl => dl.DepartmentNum);
            });

            modelBuilder.Entity<Dependent>(entity =>
            {
                entity.ToTable("Dependent");

                entity.HasKey(d => new { d.EmployeeSSN, d.Name })
                      .HasName("PK_Dependent");

                entity.HasOne(d => d.Employee)
                      .WithMany(e => e.Dependents)
                      .HasForeignKey(d => d.EmployeeSSN);

                entity.Property(d => d.Name)
                      .IsRequired();

                entity.Property(d => d.gender)
                      .HasConversion<string>()
                      .IsRequired();

                entity.Property(d => d.BDate)
                      .IsRequired(false);
            });
        }
    }
}
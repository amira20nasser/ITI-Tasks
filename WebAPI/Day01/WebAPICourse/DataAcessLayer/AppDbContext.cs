using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer
{
    public class AppDbContext : DbContext
    {
        public DbSet<Course> Courses { get; set; } 
        
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }


    }
}

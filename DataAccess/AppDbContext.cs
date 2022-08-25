using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace DataAccess
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> USERS { get; set; }
        public AppDbContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}

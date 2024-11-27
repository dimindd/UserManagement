using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using UserManagementApp.Domain.Entities;

namespace UserManagementApp.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
    }
}

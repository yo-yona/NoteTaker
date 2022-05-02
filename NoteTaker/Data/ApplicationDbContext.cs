using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NoteTaker.Models;
using Microsoft.AspNetCore.Identity;

namespace NoteTaker.Data
{
    public class ApplicationDbContext :  IdentityDbContext<ApplicationUser> 
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
        public DbSet<Note> Notes { get; set; }
        public DbSet<ApplicationUser> Users { get; set; }
    }
}
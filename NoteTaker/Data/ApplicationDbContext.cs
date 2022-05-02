using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NoteTaker.Models;
using Microsoft.AspNetCore.Identity;

namespace NoteTaker.Data
{
    public class ApplicationDbContext :  IdentityDbContext<IdentityUser> 
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Note> Notes { get; set; }
        public DbSet<IdentityUser> Users { get; set; }
    }
}
using Microsoft.EntityFrameworkCore;
using MyNotes.Models;

namespace MyNotes.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        //DbSets Area
        public DbSet<Note> Notes { get; set; }
    }
}

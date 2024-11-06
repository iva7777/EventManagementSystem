using EventManagementSystem.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace EventManagementSystem.Models
{
    public class ApplicationDbContext : DbContext
    {

        public DbSet<Event> Events { get; set; }
        public DbSet<Participant> Participants { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Event>()
                .HasMany(e => e.Participants)
                .WithOne(p => p.Event)
                .HasForeignKey(p => p.EventId);
        }
    }
}

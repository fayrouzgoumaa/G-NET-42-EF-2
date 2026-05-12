using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using G_NET_42_EF_2.Models;
namespace G_NET_42_EF_2.Data
{
    internal class AppDbContext: DbContext
    {
        // Tables
        public DbSet<Organizer> Organizers { get; set; }

        public DbSet<OrganizerProfile> OrganizerProfiles { get; set; }

        public DbSet<Event> Events { get; set; }

        public DbSet<Attendee> Attendees { get; set; }

        public DbSet<Registeration> Registrations { get; set; }

        public DbSet<Badge> Badges { get; set; }
        protected override void OnConfiguring
            (DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server=FAYROUZGOUMAA;Database=EventHubDB;Trusted_Connection=True;TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Organizer>()
                    .HasOne(o => o.Profile)
                    .WithOne(p => p.Organizer)
                    .HasForeignKey<OrganizerProfile>(p => p.OrganizerId);
            modelBuilder.Entity<Event>()
                    .HasOne(e => e.Organizer)
                    .WithMany(o => o.Events)
                    .HasForeignKey(e => e.OrganizerId);
            modelBuilder.Entity<Event>()
                    .HasOne(e => e.ParentEvent)
                    .WithMany(e => e.Sessions)
                    .HasForeignKey(e => e.ParentEventId)
                    .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Registeration>()
                    .HasOne(r => r.Event)
                    .WithMany(e => e.Registrations)
                    .HasForeignKey(r => r.EventId);
            modelBuilder.Entity<Registeration>()
                    .HasOne(r => r.Attendee)
                    .WithMany(a => a.Registrations)
                    .HasForeignKey(r => r.AttendeeId);
            modelBuilder.Entity<Registeration>()
                    .HasOne(r => r.Badge)
                    .WithOne(b => b.Registration)
                    .HasForeignKey<Badge>(b => b.RegistrationId);
            modelBuilder.Entity<Attendee>()
                    .OwnsOne(a => a.Address);
            modelBuilder.Entity<Organizer>()
                        .Property(o => o.Name)
                        .IsRequired()
                        .HasMaxLength(100);
            modelBuilder.Entity<Event>()
                    .Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(200);
            modelBuilder.Entity<Attendee>()
                    .Property(a => a.Email)
                    .IsRequired();
            modelBuilder.Entity<Badge>()
                    .HasIndex(b => b.BadgeCode)
                    .IsUnique();

        }
    }
}

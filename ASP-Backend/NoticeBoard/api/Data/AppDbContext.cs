using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Notice> Notices { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<EventCategory> EventCategories { get; set; }
        public DbSet<Poll> Polls { get; set; }
        public DbSet<PollOption> PollOptions { get; set; }
        public DbSet<Vote> Votes { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<EventRating> EventRatings { get; set; }
        public DbSet<WishlistItem> WishlistItems { get; set; }
        public DbSet<Society> Societies { get; set; }
        public DbSet<SocietyMembership> SocietyMemberships { get; set; }
        public DbSet<SocietyRepresentativeApplication> SocietyRepresentativeApplications { get; set; }
        public DbSet<SocietyPost> SocietyPosts { get; set; }
        public DbSet<PerkAssignment> PerkAssignments { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder); // Important for Identity setup

            // Configure Relationships

            // User - Notice (One-to-Many)
            builder.Entity<Notice>()
                .HasOne(n => n.Author)
                .WithMany(u => u.AuthoredNotices)
                .HasForeignKey(n => n.AuthorId)
                .OnDelete(DeleteBehavior.Cascade);

            // User - Event (One-to-Many)
            builder.Entity<Event>()
                .HasOne(e => e.Author)
                .WithMany(u => u.AuthoredEvents)
                .HasForeignKey(e => e.AuthorId)
                .OnDelete(DeleteBehavior.Cascade);

            // User - Poll (One-to-Many)
            builder.Entity<Poll>()
                .HasOne(p => p.Author)
                .WithMany(u => u.AuthoredPolls)
                .HasForeignKey(p => p.AuthorId)
                .OnDelete(DeleteBehavior.Cascade);

            // User - Comment (One-to-Many)
            builder.Entity<Comment>()
                .HasOne(c => c.User)
                .WithMany(u => u.Comments)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Notice - Comment (One-to-Many)
            builder.Entity<Comment>()
                .HasOne(c => c.Notice)
                .WithMany(n => n.Comments)
                .HasForeignKey(c => c.NoticeId)
                .OnDelete(DeleteBehavior.Cascade);

            // Event - Comment (One-to-Many)
            builder.Entity<Comment>()
                .HasOne(c => c.Event)
                .WithMany(e => e.Comments)
                .HasForeignKey(c => c.EventId)
                .OnDelete(DeleteBehavior.Cascade);

            // User - EventRating (One-to-Many)
            builder.Entity<EventRating>()
                .HasOne(er => er.User)
                .WithMany(u => u.EventRatings)
                .HasForeignKey(er => er.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Event - EventRating (One-to-Many)
            builder.Entity<EventRating>()
                .HasOne(er => er.Event)
                .WithMany(e => e.Ratings)
                .HasForeignKey(er => er.EventId)
                .OnDelete(DeleteBehavior.Cascade);

            // User - WishlistItem (One-to-Many)
            builder.Entity<WishlistItem>()
                .HasOne(wi => wi.User)
                .WithMany(u => u.WishlistItems)
                .HasForeignKey(wi => wi.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Notice - WishlistItem (One-to-Many)
            builder.Entity<WishlistItem>()
                .HasOne(wi => wi.Notice)
                .WithMany(n => n.WishlistItems)
                .HasForeignKey(wi => wi.NoticeId)
                .OnDelete(DeleteBehavior.Cascade);

            // Event - WishlistItem (One-to-Many)
            builder.Entity<WishlistItem>()
                .HasOne(wi => wi.Event)
                .WithMany(e => e.WishlistItems)
                .HasForeignKey(wi => wi.EventId)
                .OnDelete(DeleteBehavior.Cascade);

            // Society - SocietyMembership (One-to-Many)
            builder.Entity<SocietyMembership>()
                .HasOne(sm => sm.Society)
                .WithMany(s => s.Memberships)
                .HasForeignKey(sm => sm.SocietyId)
                .OnDelete(DeleteBehavior.Cascade);

            // User - SocietyMembership (One-to-Many)
            builder.Entity<SocietyMembership>()
                .HasOne(sm => sm.User)
                .WithMany(u => u.SocietyMemberships)
                .HasForeignKey(sm => sm.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Society - SocietyRepresentativeApplication (One-to-Many)
            builder.Entity<SocietyRepresentativeApplication>()
                .HasOne(sra => sra.Society)
                .WithMany(s => s.RepresentativeApplications)
                .HasForeignKey(sra => sra.SocietyId)
                .OnDelete(DeleteBehavior.Cascade);

            // User - SocietyRepresentativeApplication (One-to-Many)
            builder.Entity<SocietyRepresentativeApplication>()
                .HasOne(sra => sra.User)
                .WithMany(u => u.RepresentativeApplications)
                .HasForeignKey(sra => sra.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Society - SocietyPost (One-to-Many)
            builder.Entity<SocietyPost>()
                .HasOne(sp => sp.Society)
                .WithMany(s => s.Posts)
                .HasForeignKey(sp => sp.SocietyId)
                .OnDelete(DeleteBehavior.Cascade);

            // User - Vote (One-to-Many)
            builder.Entity<Vote>()
                .HasOne(v => v.User)
                .WithMany(u => u.Votes)
                .HasForeignKey(v => v.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // PollOption - Vote (One-to-Many)
            builder.Entity<Vote>()
                .HasOne(v => v.PollOption)
                .WithMany(po => po.Votes)
                .HasForeignKey(v => v.PollOptionId)
                .OnDelete(DeleteBehavior.Cascade);

            // Poll - PollOption (One-to-Many)
            builder.Entity<PollOption>()
                .HasOne(po => po.Poll)
                .WithMany(p => p.Options)
                .HasForeignKey(po => po.PollId)
                .OnDelete(DeleteBehavior.Cascade);

            // User - PerkAssignment (One-to-Many)
            builder.Entity<PerkAssignment>()
                .HasOne(pa => pa.User)
                .WithMany(u => u.PerkAssignments)
                .HasForeignKey(pa => pa.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Event - EventCategory (Many-to-Many) - Using a Join Table
            builder.Entity<Event>()
                .HasMany(e => e.EventCategories)
                .WithMany(ec => ec.Events)
                .UsingEntity(j => j.ToTable("EventEventCategory")); // Explicit name for the join table
        }
    }
}
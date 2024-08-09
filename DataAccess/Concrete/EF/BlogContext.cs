using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EF
{
    public class DbContext : DbContext
    {
        public DbContext(DbContextOptions<DbContext> options)
    : base(options)
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-04AMR15;Database=BlogDb;Trusted_Connection = true;TrustServerCertificate=True;");
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Trip> Tips { get; set; }
        public DbSet<TravelReview> TravelReviews { get; set;}
        public DbSet<TravelActivity> TravelActivities { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Faq> Faqs { get; set; }
        public DbSet<Destination> Destinations { get; set; }
        public  DbSet<Comment> Comments { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<DestinationtoTrip> DestinationtoTrips { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DestinationtoTrip>().HasKey(dt => new {dt.TripId, dt.DestinationId });
            modelBuilder.Entity<DestinationtoTrip>().HasOne(dt=>dt.Destination).WithMany(d=>d.DestinationstoTrips).HasForeignKey(dt=>dt.DestinationId);
            modelBuilder.Entity<DestinationtoTrip>().HasOne(dt => dt.Trip).WithMany(t => t.DestinationstoTrips).HasForeignKey(dt => dt.TripId);
                           

            modelBuilder.Entity<Comment>().HasOne(p=>p.User).WithMany(p=>p.Comments).HasForeignKey(p=>p.UserId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Comment>().HasOne(p=>p.Post).WithMany(p=>p.Comments).HasForeignKey(p=>p.PostId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Post>().HasOne(p => p.Category).WithMany(p => p.Posts).HasForeignKey(p => p.CategoryId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Post>().HasOne(p => p.User).WithMany(p => p.Posts).HasForeignKey(p => p.UserId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<TravelActivity>().HasOne(p=>p.Destination).WithMany(P=>P.Activities).HasForeignKey(p=>p.DestinationId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<TravelReview>().HasOne(p=>p.User).WithMany(P=>P.TravelReviews).HasForeignKey(p=>p.UserId).OnDelete(DeleteBehavior.Restrict);

        }
    }

    
}

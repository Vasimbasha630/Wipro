
//using Microsoft.EntityFrameworkCore;
//using HotelBookingApi.Models;

//namespace HotelBookingApi.Data
//{
//    public class AppDbContext : DbContext
//    {
//        public AppDbContext(DbContextOptions<AppDbContext> opts) : base(opts) { }

//        public DbSet<User> Users { get; set; } = null!;
//        public DbSet<Hotel> Hotels { get; set; } = null!;
//        public DbSet<Room> Rooms { get; set; } = null!;
//        public DbSet<Booking> Bookings { get; set; } = null!;
//        public DbSet<Payment> Payments { get; set; } = null!;

//        protected override void OnModelCreating(ModelBuilder modelBuilder)
//        {
//            modelBuilder.Entity<User>().HasIndex(u => u.Email).IsUnique();
//            modelBuilder.Entity<Booking>()
//                .HasCheckConstraint("CK_Bookings_Dates", "[CheckOutDate] > [CheckInDate]");
//            base.OnModelCreating(modelBuilder);
//        }
//    }
//}

using Microsoft.EntityFrameworkCore;
using HotelBookingApi.Models;

namespace HotelBookingApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opts) : base(opts) { }

        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Hotel> Hotels { get; set; } = null!;
        public DbSet<Room> Rooms { get; set; } = null!;
        public DbSet<Booking> Bookings { get; set; } = null!;
        public DbSet<Payment> Payments { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Unique constraint for email
            modelBuilder.Entity<User>().HasIndex(u => u.Email).IsUnique();

            // Booking date constraint
            modelBuilder.Entity<Booking>()
                .HasCheckConstraint("CK_Bookings_Dates", "[CheckOutDate] > [CheckInDate]");

            // ✅ Fix decimal precision warnings
            modelBuilder.Entity<Booking>()
                .Property(b => b.TotalAmount)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Payment>()
                .Property(p => p.Amount)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Room>()
                .Property(r => r.Price)
                .HasPrecision(18, 2);

            base.OnModelCreating(modelBuilder);
        }
    }
}

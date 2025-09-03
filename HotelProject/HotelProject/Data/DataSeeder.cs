using HotelBookingApi.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingApi.Data
{
    public static class DataSeeder
    {
        public static async Task SeedAsync(AppDbContext db)
        {
            // --- Seed Admin user ---
            if (!await db.Users.AnyAsync(u => u.Email == "admin@hotel.com"))
            {
                db.Users.Add(new User
                {
                    Email = "admin@hotel.com",
                    FullName = "Admin",
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword("Admin@123"), // ✅ hashed password
                    Role = "Admin"
                });

                await db.SaveChangesAsync(); // ✅ save immediately
            }

            // --- Seed Hotels + Rooms ---
            if (!await db.Hotels.AnyAsync())
            {
                var h1 = new Hotel
                {
                    Name = "Ocean View",
                    Address = "123 Beach Rd",
                    City = "Chennai",
                    Description = "Sea-facing hotel"
                };
                var h2 = new Hotel
                {
                    Name = "City Inn",
                    Address = "55 MG Road",
                    City = "Bengaluru",
                    Description = "Business hotel"
                };

                db.Hotels.AddRange(h1, h2);
                await db.SaveChangesAsync(); // ✅ so Hotels get Ids

                db.Rooms.AddRange(
                    new Room { HotelId = h1.Id, RoomNumber = "101", Type = "Single", Price = 1200, IsAvailable = true },
                    new Room { HotelId = h1.Id, RoomNumber = "102", Type = "Double", Price = 2000, IsAvailable = true },
                    new Room { HotelId = h2.Id, RoomNumber = "201", Type = "Single", Price = 1000, IsAvailable = true }
                );

                await db.SaveChangesAsync();
            }
        }
    }
}

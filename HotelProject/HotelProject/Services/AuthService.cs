using HotelBookingApi.Data;
using HotelBookingApi.DTOs.Auth;
using HotelBookingApi.Models;
using HotelBookingApi.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace HotelBookingApi.Services
{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext _db;
        private readonly IConfiguration _config;

        public AuthService(AppDbContext db, IConfiguration config)
        {
            _db = db;
            _config = config;
        }

        public async Task<(bool Success, string? Error)> RegisterAsync(RegisterDto dto)
        {
            // Check if email already exists
            var existing = await _db.Users.SingleOrDefaultAsync(u => u.Email == dto.Email);
            if (existing != null)
                return (false, "Email already exists");

            var user = new User
            {
                Email = dto.Email,
                FullName = dto.FullName,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password), // ✅ Hash
                Role = "User"
            };

            _db.Users.Add(user);
            await _db.SaveChangesAsync();
            return (true, null);
        }

        public async Task<(bool Success, string? Token, string? Error)> LoginAsync(LoginDto dto)
        {
            var user = await _db.Users.SingleOrDefaultAsync(u => u.Email == dto.Email);
            if (user == null)
                return (false, null, "Invalid credentials");

            // ✅ Verify hashed password
            if (!BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash))
                return (false, null, "Invalid credentials");

            // Build JWT token
            var key = Encoding.UTF8.GetBytes(_config["Jwt:Key"]);
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name, user.FullName ?? user.Email),
                new Claim(ClaimTypes.Role, user.Role ?? "User")
            };

            var creds = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(
                    double.TryParse(_config["Jwt:DurationMinutes"], out var minutes) ? minutes : 60
                ),
                signingCredentials: creds
            );

            var tokenStr = new JwtSecurityTokenHandler().WriteToken(token);

            return (true, tokenStr, null);
        }
    }
}

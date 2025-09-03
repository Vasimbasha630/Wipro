
using HotelBookingApi.DTOs.Auth;

namespace HotelBookingApi.Services.Interfaces
{
    public interface IAuthService
    {
        Task<(bool Success, string? Error)> RegisterAsync(RegisterDto dto);
        Task<(bool Success, string? Token, string? Error)> LoginAsync(LoginDto dto);
    }
}

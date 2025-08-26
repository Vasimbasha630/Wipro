namespace Aug_25_Car_Rental_Core.Models
{
    public interface IAuthService
    {
        Task<string> Authenticate(string username, string password);
    }
}

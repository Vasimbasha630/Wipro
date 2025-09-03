using System.ComponentModel.DataAnnotations;

namespace RoleBasedProductManagement.ViewModels
{
    public class RegisterViewModel
    {
        [Required] public string Username { get; set; }

        [Required, DataType(DataType.Password)]
        public string Password { get; set; }

        [Required] public string Role { get; set; }
    }
}

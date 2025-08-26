using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aug_25_Car_Rental_Core.Models

{
    public class User
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Column("userName")]
        public string? Username { get; set; }

        [Column("password")]
        public string? Password { get; set; }
    }
}

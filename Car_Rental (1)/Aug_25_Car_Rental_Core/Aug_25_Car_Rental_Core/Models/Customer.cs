using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aug_25_Car_Rental_Core.Models
{
    public class Customer
    {
        [Key]
        [Column("customerId")]
        public int CustomerID { get; set; }

        [Column("firstName")]
        public string? FirstName { get; set; }

        [Column("lastName")]
        public string? LastName { get; set; }

        [Column("email")]
        public string? Email { get; set; }

        [Column("phoneNumber")]
        public string? PhoneNumber { get; set; }

    }
}

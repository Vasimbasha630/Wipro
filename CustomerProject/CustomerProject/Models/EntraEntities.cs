using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    [Table("Menu")]
    public class Menu
    {
        [Key] public int MenuId { get; set; }
        public string? ItemName { get; set; }
        public string? ItemType { get; set; }
        public decimal Price { get; set; }
        public string? Description { get; set; }
        public double Rating { get; set; }
    }

    [Table("Vendor")]
    public class Vendor
    {
        [Key] public int VendorId { get; set; }
        public string? VendorName { get; set; }
        public string? VendorUserName { get; set; }
        public string? VendorPassword { get; set; }
        public string? VendorEmail { get; set; }
        public string? VendorMobile { get; set; }
    }

    [Table("Orders")]
    public class Order
    {
        [Key] public int OrderId { get; set; }
        public int CustId { get; set; }
        public int MenuId { get; set; }
        public int VendorId { get; set; }
        public int QtyOrd { get; set; }
        public decimal BillAmount { get; set; }
        public string? OrderStatus { get; set; }
        public string? OrderComments { get; set; }
    }
}

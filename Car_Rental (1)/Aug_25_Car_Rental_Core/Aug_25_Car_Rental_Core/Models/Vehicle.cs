using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aug_25_Car_Rental_Core.Models
{
    public class Vehicle
    {
        [Key]
        [Column("vehicleId")]
        public int VehicleID { get; set; }

        [Column("make")]
        public string? Make {  get; set; }

        [Column("model")]
        public string? Model { get; set; }

        [Column("year")]
        public string? Year { get; set; }

        [Column("dailyRate")]
        public string? DailyRate { get; set; }

        [Column("status")]
        public string? Status { get; set; }

        [Column("passengerCapacity")]
        public string? PassengerCapacity { get; set; }

        [Column("engineCapacity")]
        public string? EngineCapacity { get; set; }

    }
}


using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RajorExamples.Models
{
    public class Employ
    {
        [Key]
        [Column("Empno")]
        [Display(Name = "Employ Number")]
        public int Empno { get; set; }

        [Column("Name")]
        [Display(Name = "Employ Name")]
        [Required(ErrorMessage = "Name is required")]
        [StringLength(12, ErrorMessage = "Name cannot exceed 12 characters")]
        public string? Name { get; set; }
        [Column("Gender")]
        [Display(Name = "Gender")]
        [Required(ErrorMessage = "Gender is required")]
        [RegularExpression("^(MALE|FEMALE)$", ErrorMessage = "Gender must be Male, Female, or Other")]
        public string? Gender { get; set; }

        [Column("Dept")]
        [Display(Name = "Department")]
        [Required(ErrorMessage = "Department is required")]
        [StringLength(10, ErrorMessage = "Department cannot exceed 10 characters")]
        public string? Dept { get; set; }

        [Column("Desig")]
        [Display(Name = "Designation")]
        [Required(ErrorMessage = "Basic salary is required")]
        [Range(5000, 200000, ErrorMessage = "Basic salary must be between 5000 and 200000")]
        public string? Desig { get; set; }

        [Column("Basic")]
        [Display(Name = "Salary")]
        public decimal Basic { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.WebUI.DAL.Models
{
    [Table("tEmployee")]
    public class Employee
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [Display(Name = "First Name")]
        [MaxLength(255)]
        public string? Name { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [MaxLength(255)]
        public string? LastName { get; set; }
    }
}

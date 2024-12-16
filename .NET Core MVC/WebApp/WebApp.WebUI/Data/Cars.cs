using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.WebUI.Data
{
    [Table("tCars")]
    public class Cars
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Brand")]
        [MaxLength(255)]
        public string? Name { get; set; }

        [Required]
        [Display(Name = "Registration")]
        [MaxLength(255)]
        public string? Registration { get; set; }
    }
}
﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.WebUI.DAL.Models
{
    [Table("tTravelOrders")]
    public class TravelOrder
    {

        [Required]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Date")]
        public DateTime Date { get; set; }

        [Required]
        [Display(Name = "Milleage")]
        public int Mileage { get; set; }

        [Required]
        [Display(Name = "Route")]
        [MaxLength(255)]
        public string Route { get; set; }

        [Display(Name = "Employee")]
        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }

        [Display(Name = "Cars")]
        [ForeignKey("Cars")]
        public int CarsId { get; set; }

        public virtual Employee Employee { get; set; }

        public virtual Cars Cars { get; set; }
    }
}

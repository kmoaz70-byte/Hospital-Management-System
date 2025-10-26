using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Models.Models;
using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSystemweb.Models
{
    public class Patient
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Range(1, 200)]
        public int Age { get; set; }
        [Required]
        public string Gender { get; set; }
        [StringLength(14, ErrorMessage = "Too long number")]
        public string Phone { get; set; }
        public string Address { get; set; }
        [StringLength(3)]
        public string BloodGroup { get; set; }
        [Required]
        public string EmergencyContact { get; set; }
        [ValidateNever]
        public IEnumerable<Appointment> Appointments { get; set; }
    }
}

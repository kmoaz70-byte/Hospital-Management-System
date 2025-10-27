using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Models.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalManagementSystemweb.Models
{
    public class Doctor
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string Specialization { get; set; }
        [MinLength(8), MaxLength(14)]
        public string Phone { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [DisplayName("Consultation Fee")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal AppointmentFee { get; set; }
        [Required]
        [DisplayName("Experience")]
        public int YearsofExperience { get; set; }
        [ValidateNever]
        public IEnumerable<Appointment> Appointments { get; set; }

        public int DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        [ValidateNever]
        public Department Department { get; set; }

       
    }
}

using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Models.Models.ViewModel
{
    public class AppointmentVM
    {
        public Appointment appointment { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> doctorsSL { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> patientsSL { get; set; }
    }
}

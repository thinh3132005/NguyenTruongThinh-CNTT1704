using System.Collections.Generic;

namespace MedicalBooking.Infrastructure;

public partial class Specialty
{
    public int SpecialtyId { get; set; }

    public string? SpecialtyName { get; set; }

    public string? SpecialtyDescription { get; set; }

    public virtual ICollection<Doctor> Doctors { get; set; } = new List<Doctor>(); 
}

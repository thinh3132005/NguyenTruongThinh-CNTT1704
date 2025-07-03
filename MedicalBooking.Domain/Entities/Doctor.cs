using System;
using System.Collections.Generic;

namespace MedicalBooking.Infrastructure;

public partial class Doctor
{
    public int Id { get; set; }

    public string? FullName { get; set; }

    public string? LicenseNumber { get; set; }

    public int SpecialtyId { get; set; }

    public virtual ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();

    public virtual Specialty Specialty { get; set; } = null!;
}

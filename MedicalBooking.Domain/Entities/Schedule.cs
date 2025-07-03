using System;
using System.Collections.Generic;

namespace MedicalBooking.Infrastructure;

public partial class Schedule
{
    public int Id { get; set; }

    public int DoctorId { get; set; }

    public int ClinicId { get; set; }

    public DateTime Date { get; set; }

    public TimeOnly StartTime { get; set; }

    public TimeOnly EndTime { get; set; }

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    public virtual Clinic Clinic { get; set; } = null!;

    public virtual Doctor Doctor { get; set; } = null!;
}

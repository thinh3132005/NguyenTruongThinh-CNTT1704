using System;
using System.Collections.Generic;

namespace MedicalBooking.Infrastructure;

public partial class Appointment
{
    public int Id { get; set; }

    public int ScheduleId { get; set; }

    public int UserId { get; set; }

    public DateTime BookingTime { get; set; }

    public string? Status { get; set; }

    public virtual Schedule Schedule { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}

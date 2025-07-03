using System;

namespace MedicalBooking.Application.DTOS
{
    public class SpecialtyDto
    {
        public int SpecialtyId { get; set; }
        public string? SpecialtyName { get; set; }
        public string? SpecialtyDescription { get; set; }
    }
}
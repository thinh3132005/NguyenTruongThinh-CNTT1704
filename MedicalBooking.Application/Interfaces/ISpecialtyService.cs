using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedicalBooking.Application.DTOS;

namespace MedicalBooking.Application.Interfaces
{
    public interface ISpecialtyService
    {
        Task<IEnumerable<SpecialtyDto>> GetAllSpecialtiesAsync();
        Task<SpecialtyDto?> GetSpecialtyById(int id);
        Task AddSpecialtyAsync(SpecialtyDto specialtyDto);
        void UpdateSpecialty(SpecialtyDto specialtyDto);
        void DeleteSpecialty(int id);
    }
}
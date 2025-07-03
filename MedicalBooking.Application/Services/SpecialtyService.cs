using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedicalBooking.Application.DTOS;
using MedicalBooking.Application.Interfaces;
using MedicalBooking.Domain.Interfaces;
using MedicalBooking.Infrastructure;

namespace MedicalBooking.Application.Services
{
    public class SpecialtyService : ISpecialtyService
    {
        private readonly IRepository<Specialty> _repository;
        
        public SpecialtyService(IRepository<Specialty> repository)
        {
            _repository = repository;
        }
        public async Task AddSpecialtyAsync(SpecialtyDto specialtyDto)
        {
            var specialty = new Specialty
            {
                SpecialtyId= specialtyDto.SpecialtyId,
                SpecialtyName = specialtyDto.SpecialtyName,
                SpecialtyDescription = specialtyDto.SpecialtyDescription
            };
            await _repository.AddAsync(specialty);
            await _repository.SaveChangesAsync();
        }

        public async void DeleteSpecialty(int id)
        {
            var specialty = await _repository.GetByIdAsync(id);
            if (specialty!= null)
            {
                _repository.Delete(specialty);
                await _repository.SaveChangesAsync();

            }

        }

        public async Task<IEnumerable<SpecialtyDto>> GetAllSpecialtiesAsync()
        {
            var specialties = await _repository.GetAllAsync();
            return specialties.Select(c => new SpecialtyDto
            {
                SpecialtyId = c.SpecialtyId,
                SpecialtyName = c.SpecialtyName,
                SpecialtyDescription = c.SpecialtyDescription
            });
        }

        public Task<SpecialtyDto?> GetSpecialtyById(int id)
        {
            throw new NotImplementedException();
        }

        public async void UpdateSpecialty(SpecialtyDto specialtyDto)
        {
            var specialty = new Specialty()
            {
                SpecialtyId = specialtyDto.SpecialtyId,
                SpecialtyName = specialtyDto.SpecialtyName,
                SpecialtyDescription = specialtyDto.SpecialtyDescription
            };
            _repository.Update(specialty);
            await _repository.SaveChangesAsync();
        }
    }
}

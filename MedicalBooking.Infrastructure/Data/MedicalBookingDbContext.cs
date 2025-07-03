using System;
using System.Collections.Generic;
using MedicalBooking.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace MedicalBooking.Infrastructure.Data;

public partial class MedicalBookingDbContext : DbContext
{
    public MedicalBookingDbContext(DbContextOptions<MedicalBookingDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Appointment> Appointments { get; set; }

    public virtual DbSet<Clinic> Clinics { get; set; }

    public virtual DbSet<Doctor> Doctors { get; set; }

    public virtual DbSet<Schedule> Schedules { get; set; }

    public virtual DbSet<Specialty> Specialties { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Appointment>(entity =>
        {
            entity.HasIndex(e => e.ScheduleId, "IX_Appointments_ScheduleId");

            entity.HasIndex(e => e.UserId, "IX_Appointments_UserId");

            entity.HasOne(d => d.Schedule).WithMany(p => p.Appointments).HasForeignKey(d => d.ScheduleId);

            entity.HasOne(d => d.User).WithMany(p => p.Appointments).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<Doctor>(entity =>
        {
            entity.HasIndex(e => e.SpecialtyId, "IX_Doctors_SpecialtyId");

            entity.HasOne(d => d.Specialty).WithMany(p => p.Doctors).HasForeignKey(d => d.SpecialtyId);
        });

        modelBuilder.Entity<Schedule>(entity =>
        {
            entity.HasIndex(e => e.ClinicId, "IX_Schedules_ClinicId");

            entity.HasIndex(e => e.DoctorId, "IX_Schedules_DoctorId");

            entity.HasOne(d => d.Clinic).WithMany(p => p.Schedules).HasForeignKey(d => d.ClinicId);

            entity.HasOne(d => d.Doctor).WithMany(p => p.Schedules).HasForeignKey(d => d.DoctorId);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

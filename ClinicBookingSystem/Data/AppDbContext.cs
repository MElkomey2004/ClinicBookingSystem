using ClinicBookingSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace ClinicBookingSystem.Data
{
	public class AppDbContext : DbContext
	{

		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

		public DbSet<User> Users { get; set; }
		public DbSet<Doctor> Doctors { get; set; }
		public DbSet<Clinic> Clinics { get;set; }	
		public DbSet<Specialty> Specialties { get; set; }
		public DbSet<Appointment> Appointments { get; set; }
		public DbSet<TimeSlot> TimeSlots { get; set; }
		public DbSet<Notification> Notifications { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<Appointment>()
				.HasOne(a => a.Patient)
				.WithMany(u => u.Appointments)
				.HasForeignKey(a => a.PatientId)
				.OnDelete(DeleteBehavior.Restrict); 

			modelBuilder.Entity<Appointment>()
				.HasOne(a => a.Doctor)
				.WithMany(d => d.Appointments)
				.HasForeignKey(a => a.DoctorId)
				.OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<Clinic>()
			.HasOne(c => c.Specialty)
			.WithMany()
			.HasForeignKey(c => c.SpecialtyId)
			.OnDelete(DeleteBehavior.Restrict);
		}


	}
}

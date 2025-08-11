using HMS.Models;
using Microsoft.EntityFrameworkCore;

namespace HMS.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // Configure one-to-many relationship between Appointments and Doctor
            modelBuilder.Entity<Doctor>()
                .HasMany(d => d.Appointments)
                .WithOne(a => a.Doctor)
                .HasForeignKey(a => a.DoctorId);

            // Configure one-to-many relationship between Patient and Appointments
            modelBuilder.Entity<Patient>()
           .HasMany(p => p.MedicalRecords)
           .WithOne(m => m.Patient)
           .HasForeignKey(m => m.PatientId)
           .OnDelete(DeleteBehavior.Cascade);

            // Configure one-to-one relationship
                 modelBuilder.Entity<Admission>()
                .HasOne(a => a.HospitalRoom)
                .WithOne(r => r.Admission)
                .HasForeignKey<Admission>(a => a.HospitalRoomId);

            // Configure many-to-one relationship
            modelBuilder.Entity<LabTest>()
                .HasOne(l => l.Patient)
                .WithMany(p => p.LabTests)
                .HasForeignKey(l => l.PatientId)
                .OnDelete(DeleteBehavior.Cascade);

        }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<HospitalRoom> HospitalRooms { get; set; }
        public DbSet<Admission> Admissions { get; set; }
        public DbSet<MedicalRecord> MedicalRecords { get; set; }
        public DbSet<Invoice> invoices { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<LabTest> LabTests { get; set; }
    }
}

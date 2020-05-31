using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;

namespace Project01.Models
{
    public class MyDbContext : DbContext
    {
        public DbSet<Patient> Patient { get; set; }
        public DbSet<Prescription> Prescription { get; set; }
        public DbSet<PrescriptionMedicament> PrescriptionMedicament { get; set; }
        public DbSet<Medicament> Medicament { get; set; }
        public DbSet<Doctor> Doctor { get; set; }
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.HasKey(e => e.IdPatient).HasName("Patient_PK");
                entity.Property(e => e.FirstName).HasMaxLength(100).IsRequired();
                entity.Property(e => e.LastName).HasMaxLength(100).IsRequired();
                entity.Property(e => e.BirthDate).IsRequired(); 

            });
            modelBuilder.SeedEmployee();

            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.HasKey(d => d.IdDoctor).HasName("Doctor_PK");
                entity.Property(d => d.FirstName).HasMaxLength(100).IsRequired();
                entity.Property(d => d.LastName).HasMaxLength(100).IsRequired();
                entity.Property(d => d.Email).HasMaxLength(100).IsRequired();
            });

            modelBuilder.Entity<Prescription>(entity =>
            {
                entity.HasKey(e => e.IdPrescription).HasName("Prescription_PK");
                entity.Property(e => e.Date).HasDefaultValueSql("GETDATE()").IsRequired();
                entity.Property(e => e.DueDate).IsRequired();

                entity.HasOne(e => e.Patient)
                      .WithMany(d => d.Prescriptions)
                      .HasForeignKey(p => p.IdPatient)
                      .OnDelete(DeleteBehavior.Restrict)
                      .HasConstraintName("Prescription_Patient_FK");

                entity.HasOne(e => e.Doctor)
                      .WithMany(d => d.Prescriptions)
                      .HasForeignKey(p => p.IdDoctor)
                      .OnDelete(DeleteBehavior.Restrict)
                      .HasConstraintName("Prescription_Doctor_FK");
            });

            modelBuilder.Entity<Medicament>(entity =>
            {
                entity.HasKey(m => m.IdMedicament).HasName("Medicament_PK");
                entity.Property(m => m.Name).HasMaxLength(100).IsRequired();
                entity.Property(m => m.Description).HasMaxLength(200).IsRequired();
                entity.Property(m => m.Type).HasMaxLength(100).IsRequired();
            });

            modelBuilder.Entity<PrescriptionMedicament>(entity =>
            {
                entity.ToTable("Prescription_Medicament");
                entity.HasKey(e => new
                {
                    e.IdPresctiption,
                    e.IdMedicament
                });
                entity.Property(e => e.Dose).IsRequired();
                entity.Property(e => e.Details).HasMaxLength(100).IsRequired();
            });
        }
    }
}

using GestorPacientes.Core.Domain.Common;
using GestorPacientes.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GestorPacientes.Infrastucture.Persistance.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<LabTest> LabTests { get; set; }
        public DbSet<LabResult> LabResults { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<User> Users { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<BaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedAt = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.ModifiedAt = DateTime.Now;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Doctor>()
                .HasKey(d => d.Id);
            modelBuilder.Entity<Doctor>()
                .Property(d => d.FirstName)
                .IsRequired()
                .HasMaxLength(50); 
            modelBuilder.Entity<Doctor>()
                .HasMany(d => d.Patients)
                .WithOne(p => p.PrimaryDoctor)
                .HasForeignKey(p => p.DoctorId);

            modelBuilder.Entity<Patient>()
                .HasKey(p => p.Id);
            modelBuilder.Entity<Patient>()
                .Property(p => p.FirstName)
                .IsRequired()
                .HasMaxLength(50); 
            modelBuilder.Entity<Patient>()
                .Property(p => p.LastName)
                .IsRequired()
                .HasMaxLength(50); 
            modelBuilder.Entity<Patient>()
                .Property(p => p.Phone)
                .HasMaxLength(15); 

            modelBuilder.Entity<Patient>()
                .HasOne(p => p.PrimaryDoctor)
                .WithMany(d => d.Patients)
                .HasForeignKey(p => p.DoctorId);

            modelBuilder.Entity<LabResult>()
                .HasKey(lr => lr.Id);
            modelBuilder.Entity<LabResult>()
                .Property(lr => lr.Result)
                .HasMaxLength(500); 
            modelBuilder.Entity<LabResult>()
                .HasOne(lr => lr.Test)
                .WithMany(t => t.LabResults)
                .HasForeignKey(lr => lr.LabTestId);

            modelBuilder.Entity<LabTest>()
                .HasKey(lt => lt.Id);
            modelBuilder.Entity<LabTest>()
                .Property(lt => lt.Name)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Appointment>()
                .HasKey(a => a.Id);
            modelBuilder.Entity<Appointment>()
                .Property(a => a.Reason)
                .IsRequired()
                .HasMaxLength(255);
            modelBuilder.Entity<Appointment>()
                .Property(a => a.Status)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Patient)
                .WithMany(p => p.Appointments)
                .HasForeignKey(a => a.PatientId)
                .OnDelete(DeleteBehavior.Restrict); // Change to Restrict to avoid cascading

            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Doctor)
                .WithMany(d => d.Appointments)
                .HasForeignKey(a => a.DoctorId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<User>()
                .HasKey(u => u.Id);
            modelBuilder.Entity<User>()
                .Property(u => u.UserName)
                .IsRequired()
                .HasMaxLength(50); 
            modelBuilder.Entity<User>()
                .Property(u => u.FirstName)
                .IsRequired()
                .HasMaxLength(50);
            modelBuilder.Entity<User>()
                .Property(u => u.LastName)
                .IsRequired()
                .HasMaxLength(50); 
            modelBuilder.Entity<User>()
                .Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(100); 
            modelBuilder.Entity<User>()
                .Property(u => u.PasswordHash)
                .IsRequired()
                .HasMaxLength(200);
            modelBuilder.Entity<User>()
                .Property(u => u.IsAdmin)
                .IsRequired(); 
            
            modelBuilder.Entity<Doctor>()
                .HasIndex(d => d.LicenseNumber)
                .IsUnique(); 

            modelBuilder.Entity<Patient>()
                .HasIndex(p => p.IdentityNumber)
                .IsUnique(); 

            modelBuilder.Entity<User>()
                .HasIndex(u => u.UserName)
                .IsUnique(); 

            base.OnModelCreating(modelBuilder);
        }
    }
}

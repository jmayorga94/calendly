using Calendly.Domain.Commons;
using Calendly.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Calendly.Persistance
{
    public class CalendlyDbContext :DbContext
    {
        public CalendlyDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Office> Oficces { get; set; }
        public DbSet<Appointment> Appointments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CalendlyDbContext).Assembly);

            var appointmentGuid = Guid.Parse("{f9954c4a-45f9-464f-a12c-6c76b25b2837}");
            var officeId = Guid.Parse("{ae0bb628-9344-40d8-9753-61a9c5d46371}");
            modelBuilder.Entity<Office>().HasData(new Office
            {
                  Id= officeId,
                  ImageUrl ="http://localhost/image/123-png",
                  IsAvailable = false,
                  Name="Headquartes"
            }
            );

            modelBuilder.Entity<Appointment>().HasData(new Appointment
            {
                Id = appointmentGuid,
                Date = DateTime.Now,
                Description = "Appointment at dentist",
                CreationDate = DateTime.Now,
                StartHour = DateTime.Now.Hour,
                EndHour = DateTime.Now.AddHours(2).Hour,
                OfficeId = officeId
            });
           
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        break;
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.Now;
                        break;
                   
                }
            }

            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
    }
}

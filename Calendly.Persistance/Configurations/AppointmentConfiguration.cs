using Calendly.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Calendly.Persistance.Configurations
{
    public class AppointmentConfiguration : IEntityTypeConfiguration<Appointment>
    {
        public void Configure(EntityTypeBuilder<Appointment> builder)
        {
            builder.Property(e => e.Description).IsRequired().HasMaxLength(50);
            builder.HasOne(x => x.Office).WithMany(a=> a.Appoitments);
        }
    }
}

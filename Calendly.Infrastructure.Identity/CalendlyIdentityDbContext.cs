using Calendly.Infrastructure.Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Calendly.Infrastructure.Identity
{
    public class CalendlyIdentityDbContext : IdentityDbContext<ApplicationUser>
    {
        public CalendlyIdentityDbContext(DbContextOptions<CalendlyIdentityDbContext> options) : base(options)
        {

        }
    }
}

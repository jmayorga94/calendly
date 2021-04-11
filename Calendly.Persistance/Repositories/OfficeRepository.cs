using Calendly.Application.Contracts.Persistance;
using Calendly.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendly.Persistance.Repositories
{
    public class OfficeRepository : BaseRepository<Office>, IOfficeRepository
    {
        public OfficeRepository(CalendlyDbContext context) : base(context)
        {

        }
        public async Task<List<Office>> GetOffices(bool includeNotAvailable)
        {
            var offices = new List<Office>();

            offices = await _dbContext.Oficces.ToListAsync();

            if (!includeNotAvailable)
            {
                offices.RemoveAll(x => x.IsAvailable == false);
            }

            return offices;
        }
    }
}

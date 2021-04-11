using Calendly.Application.Contracts.Infrastructure;
using Calendly.Application.Features.Appointments.Queries.GetAppointmentsExport;
using CsvHelper;
using System.Collections.Generic;
using System.IO;

namespace Calendly.Infrastructure.Exporter
{
    public class CsvExporter : ICvsExporter
    {
        public byte[] ExportEventsToCvs(List<ExportAppointmentDto> allAppointments)
        {
            using var memoryStream = new MemoryStream();

            using (var streamWriter = new StreamWriter(memoryStream))
            {
                using CsvWriter cvsWriter = new CsvWriter(streamWriter);

                cvsWriter.WriteRecords(allAppointments);
            }

            return memoryStream.ToArray();
        }
    }
}

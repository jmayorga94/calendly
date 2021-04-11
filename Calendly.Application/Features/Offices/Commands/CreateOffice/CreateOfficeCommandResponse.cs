using Calendly.Application.Responses;
using System.Collections.Generic;

namespace Calendly.Application.Features.Offices.Commands.CreateOffice
{
    public class CreateOfficeCommandResponse : BaseResponse
    {
        public bool Sucess { get; internal set; }
        public List<string> ValidationErrors { get; internal set; }

        public CreateOfficeDto Office { get; set; }
    }
}
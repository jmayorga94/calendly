using AutoMapper;
using Calendly.Application.Contracts.Persistance;
using Calendly.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Calendly.Application.Features.Offices.Commands.CreateOffice
{
    public class CreateOfficeHandler : IRequestHandler<CreateOfficeCommand, CreateOfficeCommandResponse>
    {
        private readonly IAsyncRepository<Office> _officeRepository;
        private IMapper _mapper;

        public CreateOfficeHandler(IAsyncRepository<Office> officeRepository, IMapper mapper)
        {
            _officeRepository = officeRepository;
            _mapper = mapper;
        }
        public async Task<CreateOfficeCommandResponse> Handle(CreateOfficeCommand request, CancellationToken cancellationToken)
        {
            var createOfficeResponse = new CreateOfficeCommandResponse();
            var validator = new CreateOfficeValidator();

            var validationResult =  await validator.ValidateAsync(request);

            if (validationResult.Errors.Count >0)
            {
                createOfficeResponse.Sucess = false;
                createOfficeResponse.ValidationErrors = new List<string>();

                foreach (var error in validationResult.Errors)
                {
                    createOfficeResponse.ValidationErrors.Add(error.ErrorMessage);
                }

                throw new Exceptions.ValidationException(validationResult);
            }

            if (createOfficeResponse.Sucess)
            {
                var office = new Office()
                {
                    IsAvailable = true,
                    Name = request.Name,
                    CreatedDate = DateTime.Now,
                    ImageUrl = request.ImageUrl
                    
                };

                office = await _officeRepository.AddAsync(office);

                createOfficeResponse.Office = _mapper.Map<CreateOfficeDto>(office);
            }


            return createOfficeResponse;

                        
        }
    }
}

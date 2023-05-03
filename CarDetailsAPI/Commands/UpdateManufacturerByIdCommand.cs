using AutoMapper;
using CarDetailsDataAccess.Data;
using CarDetailsModels;
using MediatR;
using Manufacturer = CarDetailsAPI.Models.ManufacturersModel;

namespace CarDetailsAPI.Commands
{
    public record UpdateManufacturerByIdCommand : IRequest
    {
        public int Id { get; set; }
        public Manufacturer Manufacturer { get; set; }
        public class UpdateManufacturerByIdHandler : IRequestHandler<UpdateManufacturerByIdCommand>
        {

            private readonly IDataContext _data;
            private readonly IMapper _mapper;

            public UpdateManufacturerByIdHandler(IDataContext data, IMapper mapper)
            {
                _data = data;
                mapper = mapper;
            }

            public Task Handle(UpdateManufacturerByIdCommand request, CancellationToken cancellationToken)
            {
                var manufacturer = _data.ManufacturersDb.FirstOrDefault(x => x.Id == request.Manufacturer.Id);

                if (manufacturer is null)
                    return null;
                else
                {
                    manufacturer.Name = request.Manufacturer.MappedName;
                    manufacturer.Headquarters = request.Manufacturer.MappedHeadquarters;
                    manufacturer.Year = (int)request.Manufacturer.MappedYear;
                    
                    _data.ManufacturersDb.Update(manufacturer);
                    _data.SaveChanges();

                    return Task.FromResult(request.Manufacturer.Id);
                }
            }

        }
    }
}

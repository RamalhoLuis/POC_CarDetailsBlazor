using AutoMapper;
using CarDetailsDataAccess.Data;
using CarDetailsModels;
using MediatR;
using Manufacturer = CarDetailsAPI.Models.ManufacturersModel;


namespace CarDetailsAPI.Commands
{
    public class InsertManufacturerCommand : IRequest<Manufacturer>
    {
        public Manufacturer Manufacturer { get; set; }
        public class InsertManufacturerHandler : IRequestHandler<InsertManufacturerCommand, Manufacturer>
        {
            private readonly IDataContext _data;
            private readonly IMapper _mapper;
            public InsertManufacturerHandler(IDataContext data, IMapper mapper)
            {
                _data = data;
                _mapper = mapper;
            }
            public async Task<Manufacturer> Handle(InsertManufacturerCommand request, CancellationToken cancellationToken)
            {
                if (request.Manufacturer != null)
                {
                    var mapped = _mapper.Map<CarDetailsModels.Manufacturer>(request.Manufacturer);
                    _data.ManufacturersDb.Add(mapped);
                    await _data.SaveChangesAsync(cancellationToken);
                }

                else
                {
                    return null;
                }
                return await Task.FromResult(request.Manufacturer);
            }
        }
    }

}



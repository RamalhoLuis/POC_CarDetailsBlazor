using CarDetailsModels;
using Manufacturer = CarDetailsAPI.Models.ManufacturersModel;
using MediatR;
using AutoMapper;
using CarDetailsDataAccess.Data;

namespace CarDetailsAPI.Queries
{
    public class GetManufacturerByIdQuery : IRequest<Manufacturer>
    {
        public int Id { get; }

        public GetManufacturerByIdQuery(int id)
        {
            Id = id;
        }

        public class GetManufacturerByIdHandler : IRequestHandler<GetManufacturerByIdQuery, Manufacturer>
        {
            private readonly IMediator _mediator;

            private readonly IDataContext _dataContext;

            private readonly IMapper _mapper;
            public GetManufacturerByIdHandler(IMediator mediator, IDataContext dataContext, IMapper mapper)
            {
                _mediator = mediator;
                _dataContext = dataContext;
                _mapper = mapper;
            }

            public async Task<Manufacturer> Handle(GetManufacturerByIdQuery request, CancellationToken cancellationToken)
            {
                var manufacturer = _dataContext.ManufacturersDb.FirstOrDefault(x => x.Id == request.Id);

                if (manufacturer == null)
                {
                    return null;
                }
                else
                {
                    return _mapper.Map<CarDetailsAPI.Models.ManufacturersModel>(manufacturer);
                }
            }

        }
    }
}

using CarDetailsDataAccess.Data;
using CarDetailsModels;
using Manufacturer = CarDetailsAPI.Models.ManufacturersModel;
using MediatR;
using AutoMapper;

namespace CarDetailsAPI.Queries
{
    public class GetManufacturersListQuery : IRequest<List<Manufacturer>>
    {
        public class GetManufacturersListHandler : IRequestHandler<GetManufacturersListQuery, List<Manufacturer>>
        {
            private readonly IDataContext _manufacturerData;
            private readonly IMapper _mapper;
            public GetManufacturersListHandler(IDataContext manufacturerData, IMapper mapper)
            {
                _manufacturerData = manufacturerData;
                _mapper = mapper;   

            }
            public Task<List<Manufacturer>> Handle(GetManufacturersListQuery request, CancellationToken cancellationToken)
            {
                var mapped = _mapper.Map<List<Manufacturer>>(_manufacturerData.ManufacturersDb.ToList());
                return Task.FromResult(mapped);
            }
        }
    }
}

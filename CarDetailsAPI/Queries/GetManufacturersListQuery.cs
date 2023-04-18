using CarDetailsDataAccess.DataAccess;
using CarDetailsModels;
using MediatR;

namespace CarDetailsAPI.Queries
{
    public class GetManufacturersListQuery : IRequest<List<Manufacturer>>
    {
        public class GetManufacturersListHandler : IRequestHandler<GetManufacturersListQuery, List<Manufacturer>>
        {
            private readonly IManufacturerDataAccess _manufacturerData;
            public GetManufacturersListHandler(IManufacturerDataAccess manufacturerData)
            {
                _manufacturerData = manufacturerData;

            }
            public Task<List<Manufacturer>> Handle(GetManufacturersListQuery request, CancellationToken cancellationToken)
            {
                return Task.FromResult(_manufacturerData.GetManufacturers());
            }
        }
    }
}

using CarDetailsDataAccess.Data;
using CarDetailsDataAccess.DataAccess;
using CarDetailsModels;
using MediatR;

namespace CarDetailsAPI.Queries
{
    public class GetCarsListQuery : IRequest<List<Car>> 
    {
        public string? Search { get; set; }
        public class GetCarsListHandler : IRequestHandler<GetCarsListQuery, List<Car>>
        {
            private readonly IDataContext _carData;
            public GetCarsListHandler(IDataContext carData)
            {
                _carData = carData;

            }
            public Task<List<Car>> Handle(GetCarsListQuery request, CancellationToken cancellationToken)
            {
                var query = _carData.CarsDb.Where(x => x.Name.Contains(request.Search));

                return Task.FromResult(query.ToList());
            }
        }
    }

}

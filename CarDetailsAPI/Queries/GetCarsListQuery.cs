using CarDetailsDataAccess.DataAccess;
using CarDetailsModels;
using MediatR;

namespace CarDetailsAPI.Queries
{
    public class GetCarsListQuery : IRequest<List<Car>> 
    {
        public class GetCarsListHandler : IRequestHandler<GetCarsListQuery, List<Car>>
        {
            private readonly ICarDataAccess _carData;
            public GetCarsListHandler(ICarDataAccess carData)
            {
                _carData = carData;

            }
            public Task<List<Car>> Handle(GetCarsListQuery request, CancellationToken cancellationToken)
            {
                return Task.FromResult(_carData.GetCars());
            }
        }
    }

}

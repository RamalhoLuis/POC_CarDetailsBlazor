using CarDetailsDataAccess.Data;
using CarDetailsModels;
using Car = CarDetailsAPI.Models.CarsModel;
using MediatR;
using AutoMapper;


namespace CarDetailsAPI.Queries
{
    public class GetCarsListQuery : IRequest<List<Car>> 
    {
        public class GetCarsListHandler : IRequestHandler<GetCarsListQuery, List<Car>>
        {
            private readonly IDataContext _carData;
            private readonly IMapper _mapper;

            public GetCarsListHandler(IDataContext carData, IMapper mapper)
            {
                _carData = carData;
                _mapper = mapper;

            }
            public Task<List<Car>> Handle(GetCarsListQuery request, CancellationToken cancellationToken)
            {

                var mapped = _mapper.Map<List<Car>>(_carData.CarsDb.ToList());
                return Task.FromResult(mapped);
            }
        }
    }

}

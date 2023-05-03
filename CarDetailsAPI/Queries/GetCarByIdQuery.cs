using AutoMapper;
using CarDetailsDataAccess.Data;
using CarDetailsModels;
using MediatR;
using Car = CarDetailsAPI.Models.CarsModel;

namespace CarDetailsAPI.Queries
{
    public class GetCarByIdQuery : IRequest<Car> 
    {
        public int Id { get; }

        public GetCarByIdQuery(int id)
        {
            Id = id;
        }
        public class GetCarByIdHandler : IRequestHandler<GetCarByIdQuery, Car>
        {
            private readonly IMediator _mediator;

            private readonly IDataContext _dataContext;

            private readonly IMapper _mapper;

            public GetCarByIdHandler(IMediator mediator, IDataContext dataContext, IMapper mapper)
            {
                _mediator = mediator;
                _dataContext = dataContext;
                _mapper = mapper;
            }


            public async Task<Car> Handle(GetCarByIdQuery request, CancellationToken cancellationToken)
            {
                var car = _dataContext.CarsDb.FirstOrDefault(x => x.Id == request.Id);

                if (car == null) 
                {
                    return null;
                }
                else
                {
                    return _mapper.Map<CarDetailsAPI.Models.CarsModel>(car);
                }
                 
            }
        }
    }

}

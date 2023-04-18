using CarDetailsDataAccess.DataAccess;
using CarDetailsModels;
using MediatR;

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
            public GetCarByIdHandler(IMediator mediator)
            {
                _mediator = mediator;
            }


            public async Task<Car> Handle(GetCarByIdQuery request, CancellationToken cancellationToken)
            {
                var results = await _mediator.Send(new GetCarsListQuery());
                var output = results.FirstOrDefault(x => x.Id == request.Id);

                return output;
            }
        }
    }

}

using CarDetailsModels;
using Manufacturer = CarDetailsAPI.Models.ManufacturersModel;
using MediatR;

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
            public GetManufacturerByIdHandler(IMediator mediator)
            {
                _mediator = mediator;
            }

            public async Task<Manufacturer> Handle(GetManufacturerByIdQuery request, CancellationToken cancellationToken)
            {
                var results = await _mediator.Send(new GetManufacturersListQuery());
                var output = results.FirstOrDefault(x => x.Id == request.Id);

                return output;
            }

        }
    }
}

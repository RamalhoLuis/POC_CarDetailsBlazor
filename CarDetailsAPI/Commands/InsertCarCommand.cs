using AutoMapper;
using CarDetailsDataAccess.Data;
using CarDetailsModels;
using MediatR;
using Car = CarDetailsAPI.Models.CarsModel;

namespace CarDetailsAPI.Commands
{
    public class InsertCarCommand : IRequest
    {
        public Car Car { get; set; }
        public class InsertCarHandler : IRequestHandler<InsertCarCommand>
        {
            private readonly IDataContext _data;
            private readonly IMapper _mapper;
            public InsertCarHandler(IDataContext data, IMapper mapper)
            {
                _data = data;
                _mapper = mapper;
            }
            public Task Handle(InsertCarCommand request, CancellationToken cancellationToken)
            {
                if (request.Car != null)
                {
                    var mapped = _mapper.Map<CarDetailsModels.Car>(request.Car);
                    _data.CarsDb.Add(mapped);
                    _data.SaveChangesAsync(cancellationToken);
                }

                return Task.FromResult(request.Car.Id);
            }
        }
    }

}

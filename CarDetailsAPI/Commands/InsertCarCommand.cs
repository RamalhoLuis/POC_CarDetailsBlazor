using AutoMapper;
using CarDetailsDataAccess.Data;
using CarDetailsModels;
using MediatR;
using Car = CarDetailsAPI.Models.CarsModel;

namespace CarDetailsAPI.Commands
{
    public class InsertCarCommand : IRequest<Car>
    {
        public Car Car { get; set; }
        public class InsertCarHandler : IRequestHandler<InsertCarCommand, Car>
        {
            private readonly IDataContext _data;
            private readonly IMapper _mapper;
            public InsertCarHandler(IDataContext data, IMapper mapper)
            {
                _data = data;
                _mapper = mapper;

            }
            public async Task<Car> Handle(InsertCarCommand request, CancellationToken cancellationToken)
            {
                if (request.Car != null)
                {
                    var mapped = _mapper.Map<CarDetailsModels.Car>(request.Car);
                    _data.CarsDb.Add(mapped);
                    await _data.SaveChangesAsync(cancellationToken);
                }
                    
                else
                {
                    return null;
                }
                return await Task.FromResult(request.Car);
            }
        }
    }

}

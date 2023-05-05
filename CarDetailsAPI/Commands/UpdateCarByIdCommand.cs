using AutoMapper;
using CarDetailsDataAccess.Data;
using MediatR;
using Newtonsoft.Json.Linq;
using Car = CarDetailsAPI.Models.CarsModel;

namespace CarDetailsAPI.Commands
{

    public record UpdateCarByIdCommand : IRequest
    {
        public int Id { get; set; }
        public Car Car { get; set; }
        public class UpdateCarByIdHandler : IRequestHandler<UpdateCarByIdCommand>
        {

            private readonly IDataContext _data;
            private readonly IMapper _mapper;

            public UpdateCarByIdHandler(IDataContext data, IMapper mapper)
            {
                _data = data;
                mapper = mapper;
            }

            public Task Handle(UpdateCarByIdCommand request, CancellationToken cancellationToken)
            {
                var car = _data.CarsDb.FirstOrDefault(x => x.Id == request.Car.Id);

                if (car is null)
                    return null;
                else
                {
                    car.Year = (int)request.Car.MappedYear;
                    car.Name = request.Car.MappedName;
                    car.Displacement = (int)request.Car.MappedDisplacement;
                    car.Cylinders = (int)request.Car.MappedCylinders;
                    car.City = (int)request.Car.MappedCity;
                    car.Highway = (int)request.Car.MappedHighway;
                    car.Combined = (int)request.Car.MappedCombined;
;
                    _data.CarsDb.Update(car);
                    _data.SaveChanges();

                    return Task.FromResult(request.Car.Id);
                }
            }

        }
    }

}


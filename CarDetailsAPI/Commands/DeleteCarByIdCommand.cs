using CarDetailsModels;
using MediatR;

namespace CarDetailsAPI.Commands
{        public record DeleteCarByIdCommand(int Id ,int Year, string Manufacturer, string Name, double Displacement, int Cylinders, int City, int Highway, int Combined) : IRequest<List<Car>>;

}

using CarDetailsModels;
using MediatR;

namespace CarDetailsAPI.Commands
{
    public record InsertCarCommand(int Year, string Manufacturer, string Name, double Displacement, int Cylinders, int City, int Highway, int Combined) : IRequest<List<Car>>;

}

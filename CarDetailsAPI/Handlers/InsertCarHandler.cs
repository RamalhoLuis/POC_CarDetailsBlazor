using CarDetailsAPI.Commands;
using CarDetailsDataAccess.Data;
using CarDetailsDataAccess.DataAccess;
using CarDetailsModels;
using MediatR;

namespace CarDetailsAPI.Handlers
{
    public class InsertCarHandler : IRequestHandler<InsertCarCommand, List<Car>>
    {
        private readonly ICarDataAccess _data;
        public InsertCarHandler(ICarDataAccess data)
        {
            _data = data;
            
        }
        public Task<List<Car>> Handle(InsertCarCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_data.InsertCar(request.Year, request.Manufacturer, request.Name, request.Displacement, request.Cylinders, request.City, request.Highway, request.Combined));
        }
    }
}

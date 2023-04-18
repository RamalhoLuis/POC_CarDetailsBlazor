using CarDetailsDataAccess.Data;
using CarDetailsModels;
using MediatR;

namespace CarDetailsAPI.Commands
{
    public class InsertCarCommand : IRequest<Car>
    {
        public Car Car { get; set; }
        public class InsertCarHandler : IRequestHandler<InsertCarCommand, Car>
        {
            private readonly IDataContext _data;
            public InsertCarHandler(IDataContext data)
            {
                _data = data;

            }
            public async Task<Car> Handle(InsertCarCommand request, CancellationToken cancellationToken)
            {
                var car = _data.CarsDb.Contains(request.Car);
                if (car)
                    return null;
                else
                {
                     _data.CarsDb.Add(request.Car);
                     await _data.SaveChangesAsync(cancellationToken);
                }
                return await Task.FromResult(request.Car);
            }
        }
    }

}

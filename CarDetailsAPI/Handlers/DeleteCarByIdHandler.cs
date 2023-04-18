using CarDetailsAPI.Commands;
using CarDetailsDataAccess.DataAccess;
using CarDetailsModels;
using MediatR;

namespace CarDetailsAPI.Handlers
{
    public class DeleteCarByIdHandler
    {
        public class InsertCarHandler : IRequestHandler<DeleteCarByIdCommand, List<Car>>
        {
            private readonly ICarDataAccess _data;
            public InsertCarHandler(ICarDataAccess data)
            {
                _data = data;

            }
            public Task<List<Car>> Handle(DeleteCarByIdCommand request, CancellationToken cancellationToken)
            {
                return Task.FromResult(_data.DeleteCarById(request.Id));
            }
        }
    }
}

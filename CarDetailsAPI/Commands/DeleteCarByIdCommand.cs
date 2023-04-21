using CarDetailsDataAccess.Data;
using CarDetailsModels;
using MediatR;

namespace CarDetailsAPI.Commands
{
    public record DeleteCarByIdCommand : IRequest
    {
        private int Id { get; set; }
        public class DeleteCarByIdHandler : IRequestHandler<DeleteCarByIdCommand>
        {

                private readonly IDataContext _data;

                public DeleteCarByIdHandler(IDataContext data)
                {
                    _data = data;
                }

                public Task Handle(DeleteCarByIdCommand request, CancellationToken cancellationToken)
                {
                    var car = _data.CarsDb.FirstOrDefault(x => x.Id == request.Id);

                    if (car is null)
                        return null;
                    else
                    {
                        _data.CarsDb.Remove(car);
                        _data.SaveChanges();

                        return Task.FromResult(request.Id);
                    }
                }

        }
    }

}

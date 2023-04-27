using AutoMapper;
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
                private readonly IMapper _mapper;

            public DeleteCarByIdHandler(IDataContext data, IMapper mapper)
                {
                    _data = data;
                     mapper = mapper;
            }

                public Task Handle(DeleteCarByIdCommand request, CancellationToken cancellationToken)
                {
                    var car = _data.CarsDb.FirstOrDefault(x => x.Id == request.Id);

                    if (car is null)
                        return null;
                    else
                    {
                    var mapped = _mapper.Map<CarDetailsModels.Car>(request.Id);
                    _data.CarsDb.Remove(car);
                        _data.SaveChanges();

                        return Task.FromResult(request.Id);
                    }
                }

        }
    }

}

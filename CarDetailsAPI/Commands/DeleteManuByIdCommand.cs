using AutoMapper;
using CarDetailsDataAccess.Data;
using CarDetailsModels;
using MediatR;

namespace CarDetailsAPI.Commands
{
    public record DeleteManuByIdCommand : IRequest
    {
        public int Id { get; set; }
        public class DeleteManuByIdHandler : IRequestHandler<DeleteManuByIdCommand>
        {
            private readonly IDataContext _data;
            private readonly IMapper _mapper;

            public DeleteManuByIdHandler(IDataContext data, IMapper mapper)
            {
                _data = data;
                mapper = mapper;
            }

            public Task Handle(DeleteManuByIdCommand request, CancellationToken cancellationToken)
            {
                var manufacturer = _data.ManufacturersDb.FirstOrDefault(x => x.Id == request.Id);

                if (manufacturer is null)
                    return null;
                else
                {

                    _data.ManufacturersDb.Remove(manufacturer);
                    _data.SaveChanges();

                    return Task.FromResult(request.Id);
                }
            }

        }
    }
}

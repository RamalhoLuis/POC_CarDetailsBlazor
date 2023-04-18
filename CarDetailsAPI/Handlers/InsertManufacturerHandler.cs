using CarDetailsAPI.Commands;
using CarDetailsDataAccess.DataAccess;
using CarDetailsModels;
using MediatR;

namespace CarDetailsAPI.Handlers
{
    public class InsertManufacturerHandler : IRequestHandler<InsertManufacturerCommand, List<Manufacturer>>
    {
        private readonly IManufacturerDataAccess _data;
        public InsertManufacturerHandler(IManufacturerDataAccess data)
        {
            _data = data;

        }
        public Task<List<Manufacturer>> Handle(InsertManufacturerCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_data.InsertManufacturer(request.Name, request.Headquarters, request.Year));
        }
    }
}

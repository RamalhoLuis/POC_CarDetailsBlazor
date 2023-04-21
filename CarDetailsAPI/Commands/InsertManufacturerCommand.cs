using CarDetailsDataAccess.Data;
using CarDetailsModels;
using MediatR;


namespace CarDetailsAPI.Commands
{
    public class InsertManufacturerCommand : IRequest<Manufacturer>
    {
        public Manufacturer Manufacturer { get; set; }
        public class InsertManufacturerHandler : IRequestHandler<InsertManufacturerCommand, Manufacturer>
        {
            private readonly IDataContext _data;
            public InsertManufacturerHandler(IDataContext data)
            {
                _data = data;

            }
            public async Task<Manufacturer> Handle(InsertManufacturerCommand request, CancellationToken cancellationToken)
            {
                var manufacturer = _data.ManufacturersDb.Contains(request.Manufacturer);
                if (manufacturer)
                    return null;
                else
                {
                    _data.ManufacturersDb.Add(request.Manufacturer);
                    await _data.SaveChangesAsync(cancellationToken);
                }
                return await Task.FromResult(request.Manufacturer);
            }
        }
    }

}



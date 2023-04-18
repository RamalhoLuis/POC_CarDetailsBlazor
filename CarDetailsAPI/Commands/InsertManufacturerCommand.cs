using CarDetailsModels;
using MediatR;

namespace CarDetailsAPI.Commands
{
    public record InsertManufacturerCommand(  string Name, string Headquarters, int Year) : IRequest<List<Manufacturer>>;

}



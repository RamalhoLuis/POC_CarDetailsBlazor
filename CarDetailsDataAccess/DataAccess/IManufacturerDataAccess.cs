using CarDetailsModels;

namespace CarDetailsDataAccess.DataAccess
{
    public interface IManufacturerDataAccess
    {
        List<Manufacturer> GetManufacturers();
        List<Manufacturer> InsertManufacturer(string name,string headquarters,int year);
    }
}
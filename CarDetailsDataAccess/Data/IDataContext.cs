using CarDetailsModels;
using Microsoft.EntityFrameworkCore;

namespace CarDetailsDataAccess.Data
{
    public interface IDataContext
    {
        DbSet<Car> CarsDb { get; set; }
        DbSet<JointInfo> JointInfoDb { get; set; }
        DbSet<Manufacturer> ManufacturersDb { get; set; }

        int SaveChanges();

        Task<int> SaveChangesAsync(CancellationToken cancellation = default);
    }
}
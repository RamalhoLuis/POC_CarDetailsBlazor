using CarDetailsModels;

namespace CarDetailsDataAccess
{
    public class ManuDataStore
    {
        public List<Manufacturer> manufacturers;
        public static string manuFilePath;

        public ManuDataStore(string? path = null)
        {
            manuFilePath = path;
            manufacturers = GetManufacturersFromFile();
        }

        private static List<Manufacturer> GetManufacturersFromFile(string? path = null)
        {
            if (path == null) { path = manuFilePath; }

            var query =
                    File.ReadAllLines(path)
                    .Where(l => l.Length > 1)
                    .ToManufacturer();

            return query.ToList();
        }
    }
}

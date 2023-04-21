using CarDetailsModels;

namespace CarDetailsAPI.Models
{
    public class CarsModel
    {
        public int Id { get; set; }
        public int? MappedYear { get; set; }
        public string? MappedManufacturer { get; set; }
        public string? MappedName { get; set; }
        public double? MappedDisplacement { get; set; }
        public int? MappedCylinders { get; set; }
        public int? MappedCity { get; set; }
        public int? MappedHighway { get; set; }
        public int? MappedCombined { get; set; }

    }
}

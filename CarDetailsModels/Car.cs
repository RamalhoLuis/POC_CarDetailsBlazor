namespace CarDetailsModels
{
    public class Car
    {
        public int Id { get; set; }
        public int Year { get; set; }
        public string Name { get; set; }
        public double Displacement { get; set; }
        public int Cylinders { get; set; }
        public int City { get; set; }
        public int Highway { get; set; }
        public int Combined { get; set; }
        public int ManufacturerId { get; set; }
        public Manufacturer Manufacturer { get; set; }  

    }

    public static class CarExtensions
    {
        public static IEnumerable<Car> ToCar(this IEnumerable<string> source)
        {
            foreach (var line in source)
            {
                var columns = line.Split(',');

                yield return new Car
                {
                    Year = int.Parse(columns[0]),
                    Name = columns[1],
                    Displacement = double.Parse(columns[2].ToString().Replace('.', ',')),
                    Cylinders = int.Parse(columns[3]),
                    City = int.Parse(columns[4]),
                    Highway = int.Parse(columns[5]),
                    Combined = int.Parse(columns[6])

                };
            }
        }
    }
}
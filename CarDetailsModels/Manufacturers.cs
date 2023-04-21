using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDetailsModels
{
    public class Manufacturer
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Headquarters { get; set; }
        public int? Year { get; set; }
    }
    public static class ManuExtensions
    {
        public static IEnumerable<Manufacturer> ToManufacturer(this IEnumerable<string> source)
        {
            foreach (var line in source)
            {
                var columns = line.Split(',');


                yield return new Manufacturer
                {
                    Name = columns[0],
                    Headquarters = columns[1],
                    Year = int.Parse(columns[2])

                };
            }
        }
    }
}

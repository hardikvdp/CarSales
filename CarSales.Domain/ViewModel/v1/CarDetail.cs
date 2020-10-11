using CarSales.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarSales.Domain.ViewModel.v1
{
    public class CarDetail
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Engine { get; set; }
        public Decimal Price { get; set; }
        public DateTime? Created { get; set; }
        public int Doors { get; set; }
        public int Wheels { get; set; }
        public string BodyType { get; set; }
        public string VehicleType { get; set; }
    }
}

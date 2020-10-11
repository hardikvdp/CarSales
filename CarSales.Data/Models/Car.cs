using CarSales.Data.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarSales.Data.Models
{
    public class Car : Vehicle
    {
        public int Doors { get; set; }
        public int Wheels { get; set; }

        public int VehicleTypeId { get; set; }

        [ForeignKey("VehicleTypeId")]

        public VehicleType VehicleType { get; set; }

        public int BodyTypeId { get; set; }

        [ForeignKey("BodyTypeId")]
        public BodyType BodyType { get; set; }

    }
}

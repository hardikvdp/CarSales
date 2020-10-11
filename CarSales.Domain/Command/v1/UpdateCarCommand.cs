using CarSales.Data.Models;
using MediatR;
using System;
using System.ComponentModel.DataAnnotations;

namespace CarSales.Domain.Command.v1
{
    public class UpdateCarCommand : IRequest<bool>
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Make { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        public Decimal Price { get; set; }
        [Required]
        public string Engine { get; set; }
        [Required]
        public int Doors { get; set; }
        public int Wheels { get; set; }
        public string BodyType { get; set; }
        public string VehicleType { get; set; }

    }
}

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarSales.Data.Models.Base
{
    public class Vehicle
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Make { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Model { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Engine { get; set; }

        [Column(TypeName = "decimal(10, 2)")]
        public Decimal Price { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Modified { get; set; }
    }
}

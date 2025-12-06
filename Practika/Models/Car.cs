using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practika.Models
{
    public class Car
    {
        public int Id { get; set; }
        public int SellerId { get; set; }
        public int CategoryId { get; set; }
        public int BrandId { get; set; }
        public int ModelId { get; set; }
        public int Year { get; set; }
        public int Mileage { get; set; }
        public int EngineTypeId { get; set; }
        public int TransmissionId { get; set; }
        public int? BodyTypeId { get; set; }
        public int ColorId { get; set; }
        public decimal Price { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public int StatusId { get; set; }
    }
}

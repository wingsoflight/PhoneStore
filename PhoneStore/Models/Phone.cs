using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace PhoneStore.Models
{
    public class Phone
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public int? ManufacturerId { get; set; }
        public virtual Manufacturer Manufacturer { get; set; }
    }

    public class PhoneDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }

        public static PhoneDTO FromPhone(Phone phone) => new PhoneDTO
        {
            Id = phone.Id,
            Name = phone.Name,
            Price = phone.Price
        };
    }
    public class PhoneDetailDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public static PhoneDetailDTO FromPhone(Phone phone) => new PhoneDetailDTO
        {
            Id = phone.Id,
            Name = phone.Name,
            Price = phone.Price,
        };
    }
}

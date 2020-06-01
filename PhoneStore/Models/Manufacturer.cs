using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace PhoneStore.Models
{
    public class Manufacturer
    {
        public Manufacturer()
        {
            Phones = new List<Phone>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<Phone> Phones { get; set; }
    }

    public class ManufacturerDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public static ManufacturerDTO FromManufacturer(Manufacturer manufacturer) => new ManufacturerDTO
        {
            Id = manufacturer.Id,
            Name = manufacturer.Name
        };
    }

    public class ManufacturerDetailDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<PhoneDTO> Phones { get; set; }
        public static ManufacturerDetailDTO FromManufacturer(Manufacturer manufacturer) => new ManufacturerDetailDTO
        {
            Id = manufacturer.Id,
            Name = manufacturer.Name,
            Phones = manufacturer.Phones.Select(p=>PhoneDTO.FromPhone(p)).ToList()
        };
    }
}

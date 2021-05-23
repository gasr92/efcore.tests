using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace efcore.tests.Domain.Entities
{
    public class Car
    {
        public Car(string name, Guid brandId)
        {
            Name = name;
            BrandId = brandId;
        }

        public Car(string name, Brand brand)
        {
            Brand = brand;
            Name = name;
        }

        [Key]
        public Guid Id { get; private set; }

        [MinLength(2), MaxLength(40)]
        public string Name { get; private set; }

        [ForeignKey("BrandId")]
        public Guid BrandId { get; private set; }
        public virtual Brand Brand { get; private set; }

        public virtual IList<AutoStore> Stores { get; set; } = new List<AutoStore>();
    }
}
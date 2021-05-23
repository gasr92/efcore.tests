using System;
using System.ComponentModel.DataAnnotations;

namespace efcore.tests.Domain.Entities
{
    public class Brand
    {
        public Brand(string name)
        {
            Name = name;
        }

        [Key]
        public Guid Id { get; private set; }

        [MinLength(2), MaxLength(40)]
        public string Name { get; private set; }
    }
}
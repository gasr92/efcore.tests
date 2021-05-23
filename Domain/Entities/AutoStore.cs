using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace efcore.tests.Domain.Entities
{
    public class AutoStore
    {

        public AutoStore(string name)
        {
            this.Name = name;
        }

        [Key]
        public Guid Id { get; private set; }

        [MinLength(2), MaxLength(40)]
        public string Name { get; private set; }

        public virtual IList<Car> Cars { get; set; } = new List<Car>();
    }
}
using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Models
{
    public partial class Alphabitic
    {
        public Alphabitic()
        {
            People = new HashSet<Person>();
        }

        public int Id { get; set; }
        public string AlphabiticChar { get; set; }

        public ICollection<Person> People { get; set; }
    }
}

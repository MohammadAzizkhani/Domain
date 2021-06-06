using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Models
{
    public partial class Degree
    {
        public Degree()
        {
            People = new HashSet<Person>();
        }

        public int Id { get; set; }
        public string DegreeName { get; set; }

        public virtual ICollection<Person> People { get; set; }
    }
}

using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Models
{
    public partial class Nationality
    {
        public Nationality()
        {
            People = new HashSet<Person>();
        }

        public int Id { get; set; }
        public string NationalName { get; set; }

        public  ICollection<Person> People { get; set; }
    }
}

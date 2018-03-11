using System;
using System.Collections.Generic;
using System.Text;

namespace StarWars.Model
{
    public class PersonResponse
    {
        public int Count { get; set; }
        public string Next { get; set; }
        public object Previous { get; set; }
        public List<Person> Results { get; set; }
    }
}

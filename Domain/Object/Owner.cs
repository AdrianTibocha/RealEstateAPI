using System;
using System.Collections.Generic;

namespace Domain.Object
{
    public class Owner
    {
        public Owner(string id) 
        {
            this.id = id;
        }

        public readonly string id; 
        public string name { get; set; }
        public string address { get; set; }
        public string photoPath { get; set; }
        public DateTime birthday { get; set; }
        public List<Property> properties { get; set; }
    }
}

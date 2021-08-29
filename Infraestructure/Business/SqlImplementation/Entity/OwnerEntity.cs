using System;

namespace Infraestructure.Entity
{
    public class OwnerEntity
    {
        public readonly string idOwner; 
        public string name { get; set; }
        public string address { get; set; }
        public string photoPath { get; set; }
        public DateTime birthday { get; set; }
    }
}

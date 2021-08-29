using System.Collections.Generic;

namespace Domain.Object
{
    public class Property
    {
        public Property() { }
        public Property(int id)
        {
            this.id = id;
        }

        public readonly int id;
        public string name { get; set; }
        public string address { get; set; }
        public decimal price { get; set; }
        public string codeInternal { get; set; }
        public int year { get; set; }
        public List<PropertyImage> propertyImages { get; set; } = new List<PropertyImage>();
        public List<PropertyTrace> propertyTraces { get; set; } = new List<PropertyTrace>(); 
    }
}

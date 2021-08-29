using System;

namespace Domain.Object
{
    public class PropertyTrace
    {
        public PropertyTrace() { }
        public PropertyTrace(int id)
        {
            this.id = id;
        }

        public readonly int id;
        public DateTime dateSale { get; set; }
        public string name { get; set; }
        public string value { get; set; }
        public decimal tax { get; set; }
    }
}

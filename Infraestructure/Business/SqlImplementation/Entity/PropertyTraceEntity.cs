using System;

namespace Infraestructure.Entity
{
    public class PropertyTraceEntity
    {
        public int idPropertyTrace { get; set; }
        public int idProperty { get; set; }
        public DateTime dateSale { get; set; }
        public string name { get; set; }
        public string value { get; set; }
        public decimal tax { get; set; }
    }
}

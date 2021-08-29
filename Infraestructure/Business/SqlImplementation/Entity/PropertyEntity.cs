namespace Infraestructure.Entity
{
    public class PropertyEntity
    {
        public int idProperty { get; set; }
        public string idOwner { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public decimal price { get; set; }
        public string codeInternal { get; set; }
        public int year { get; set; }
    }
}

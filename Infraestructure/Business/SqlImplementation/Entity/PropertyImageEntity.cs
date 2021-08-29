namespace Infraestructure.Entity
{
    public class PropertyImageEntity
    {
        public int idPropertyImage { get; set; }
        public int idProperty { get; set; }
        public string filePath { get; set; }
        public bool enabled { get; set; }
    }
}

namespace Domain.Object
{
    public class PropertyImage
    {
        public PropertyImage() { }
        public PropertyImage(int id) 
        {
            this.id = id;
        }

        public readonly int id;
        public string filePath { get; set; }
        public bool enabled { get; set; }
    }
}

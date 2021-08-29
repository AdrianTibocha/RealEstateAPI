namespace Application.Dto.ResponseObject
{
    public class PropertyResponse
    {
        public PropertyResponse(int id)
        {
            this.id = id;
        }

        public readonly int id;
        public string name { get; set; }
        public string address { get; set; }
        public decimal price { get; set; }
        public string codeInternal { get; set; }
        public int year { get; set; }
    }
}

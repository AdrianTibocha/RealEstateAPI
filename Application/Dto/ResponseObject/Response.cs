using System.Text.Json;
using System.Text.Json.Serialization;

namespace Application.Dto.ResponseObject
{
    public class Response
    {
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public StatusResponse status { get; set; }
        public string message { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }

    public enum StatusResponse
    {
        UserError,
        SystemError,
        Success
    }

    public class ResponseMessage
    {
        public string value { get; private set; }
        private ResponseMessage(string value) { this.value = value; }
        
        public static ResponseMessage PropertyCreatedSuccessful { get { return new ResponseMessage("Propiedad creada exitosamente"); } }
        public static ResponseMessage PropertyChangePriceSuccessful { get { return new ResponseMessage("Cambio de precio de propiedad exitoso"); } }
        public static ResponseMessage PropertyUpdateSuccessful { get { return new ResponseMessage("Actualizacion de propiedad exitosa"); } }
        public static ResponseMessage PropertyAddImageSuccessful { get { return new ResponseMessage("Imagen agregada exitosamente"); } }
    }
}

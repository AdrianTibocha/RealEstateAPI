using System.ComponentModel.DataAnnotations;

namespace Application.Dto
{
    public class CreatePropertyRequest : PropertyRequest
    {
        [Required(ErrorMessage = "idOwner es requerido")]
        public string idOwner { get; set; }
    }

}

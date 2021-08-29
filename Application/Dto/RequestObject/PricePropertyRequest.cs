using System.ComponentModel.DataAnnotations;

namespace Application.Dto
{
    public class PricePropertyRequest
    {
        [Required(ErrorMessage = "price es requerido")]
        [Range(1, 99999999.99, ErrorMessage = "price debe estar entre 0 y 99999999.99")]
        public decimal price { get; set; }
    }
}

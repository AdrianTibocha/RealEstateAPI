using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace Application.Dto
{
    public class PropertyRequest
    {
        [Required(ErrorMessage = "name es requerido")]
        public string name { get; set; }

        [Required(ErrorMessage = "address es requerido")]
        public string address { get; set; }
        
        [Range(1, 99999999.99, ErrorMessage = "price debe estar entre 0 y 99999999.99")]
        [Required(ErrorMessage = "price es requerido")]
        public decimal price { get; set; }
        
        [Required(ErrorMessage = "codeInternal es requerido")]
        public string codeInternal { get; set; }    
        
        [Required(ErrorMessage = "year es requerido")]
        [Range(1800, 2022, ErrorMessage = "year debe estar entre 1800 y 2022")]
        public int year { get; set; }
    }

    public class ImageRequest
    {
        [Required(ErrorMessage = "formFile es requerido")]
        public IFormFile formFile { get; set; }
    }

}

using Application.Business.Input;
using Application.Dto;
using Application.Dto.ResponseObject;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace RealState.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class PropertyController : ControllerBase
    {

        private readonly IPropertyBusiness propertyBusiness;

        public PropertyController(IPropertyBusiness propertyBusiness)
        {
            this.propertyBusiness = propertyBusiness;
        }

        [HttpPost]
        public IActionResult Create(CreatePropertyRequest newPropertyRequest)
        {
            Response response = propertyBusiness.Create(newPropertyRequest);
            return Ok(response);
        }

        [HttpPut]
        [Route("{idProperty}")]
        public IActionResult Update(int idProperty, PropertyRequest property)
        {
            Response response = propertyBusiness.Update(idProperty, property);
            return Ok(response);
        }

        [HttpGet]
        [Route("{attribute}/{value}/{filter}")]
        public IActionResult Get(string attribute, string value, string filter)
        {
            List<PropertyResponse> properties = propertyBusiness.Get(attribute.ToLower(), value.ToLower(), filter.ToLower());
            return Ok(properties);
        }

        [HttpPut]
        [Route("{idProperty}/image")]
        public IActionResult AddImage(int idProperty,[FromForm] ImageRequest ImageRequest)
        {
            Response response = propertyBusiness.AddImage(idProperty, ImageRequest);
            return Ok(response);
        }
        
        [HttpPut]
        [Route("{idProperty}/price")]
        public IActionResult UpdatePrice(int idProperty, PricePropertyRequest newPricePropertyRequest)
        {
            Response response = propertyBusiness.UpdatePrice(idProperty, newPricePropertyRequest);
            return Ok(response);
        }

    }
}

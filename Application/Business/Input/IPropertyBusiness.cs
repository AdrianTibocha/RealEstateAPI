using Application.Dto;
using Application.Dto.ResponseObject;
using System.Collections.Generic;

namespace Application.Business.Input
{
    public interface IPropertyBusiness
    {
        Response Create(CreatePropertyRequest newPropertyRequest);
        Response Update(int idProperty, PropertyRequest property);
        List<PropertyResponse> Get(string attribute, string value, string filter);
        Response AddImage(int idProperty, ImageRequest ImageRequest);
        Response UpdatePrice(int idProperty, PricePropertyRequest newPricePropertyRequest);
    }
}

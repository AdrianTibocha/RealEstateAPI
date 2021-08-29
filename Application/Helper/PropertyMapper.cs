using Application.Dto;
using Application.Dto.ResponseObject;
using Domain.Object;

namespace Application.Helper
{
    public class PropertyMapper : IPropertyMapper
    {
        public PropertyImage GetPropertyImage(string filePath, bool enabled = true)
        {
            return new PropertyImage() { filePath = filePath, enabled = enabled };
        }

        public Property GetProperty(CreatePropertyRequest newPropertyRequest)
        {
            return new Property 
            {
                name = newPropertyRequest.name,
                address = newPropertyRequest.address,
                price = newPropertyRequest.price,
                codeInternal = newPropertyRequest.codeInternal,
                year = newPropertyRequest.year
            };
        }

        public Property GetProperty(int idProperty, PropertyRequest property)
        {
            return new Property (idProperty)
            {
                name = property.name,
                address = property.address,
                price = property.price,
                codeInternal = property.codeInternal,
                year = property.year
            };
        }

        public PropertyResponse GetPropertyResponse(Property property)
        {
            return new PropertyResponse(property.id)
            {
                name = property.name,
                address = property.address,
                price = property.price,
                codeInternal = property.codeInternal,
                year = property.year
            };
        }
    }
}

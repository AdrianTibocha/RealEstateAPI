using Application.Dto;
using Application.Dto.ResponseObject;
using Domain.Object;

namespace Application.Helper
{
    public interface IPropertyMapper
    {
        PropertyImage GetPropertyImage(string filePath, bool enabled = true);
        Property GetProperty(CreatePropertyRequest newPropertyRequest);
        Property GetProperty(int idProperty, PropertyRequest property);
        PropertyResponse GetPropertyResponse(Property property);
    }
}
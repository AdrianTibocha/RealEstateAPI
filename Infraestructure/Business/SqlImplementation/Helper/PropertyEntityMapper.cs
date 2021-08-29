using Application.Dto.ResponseObject;
using Domain.Object;
using Infraestructure.Entity;

namespace Infraestructure.Business.SqlImplementation.Helper
{
    public class PropertyEntityMapper
    {
        public PropertyEntity GetPropertyEntity(string idOwner, Property property)
        {
            return new PropertyEntity
            {
                idProperty = property.id,
                idOwner = idOwner,
                name = property.name,
                address = property.address,
                price = property.price,
                codeInternal = property.codeInternal,
                year = property.year
            };
        }

        public PropertyEntity GetPropertyEntity(Property property)
        {
            return new PropertyEntity
            {
                idProperty = property.id,
                name = property.name,
                address = property.address,
                price = property.price,
                codeInternal = property.codeInternal,
                year = property.year
            };
        }

        public Property GetProperty(PropertyEntity propertyEntity)
        {
            return new Property(propertyEntity.idProperty)
            {
                name = propertyEntity.name,
                address = propertyEntity.address,
                price = propertyEntity.price,
                codeInternal = propertyEntity.codeInternal,
                year = propertyEntity.year
            };
        }
    }
}

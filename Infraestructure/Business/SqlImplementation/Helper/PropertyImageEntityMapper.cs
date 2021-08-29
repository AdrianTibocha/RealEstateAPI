using Domain.Object;
using Infraestructure.Entity;

namespace Infraestructure.Business.SqlImplementation.Helper
{
    public class PropertyImageEntityMapper
    {
        public PropertyImageEntity GetImageEntity(int idProperty, PropertyImage propertyImage)
        {
            return new PropertyImageEntity()
            {
                idPropertyImage = propertyImage.id,
                idProperty = idProperty,
                filePath = propertyImage.filePath,
                enabled = propertyImage.enabled
            };
        }
    }
}

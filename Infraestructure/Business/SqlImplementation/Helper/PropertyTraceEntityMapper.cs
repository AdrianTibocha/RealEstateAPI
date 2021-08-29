using Domain.Object;
using Infraestructure.Entity;

namespace Infraestructure.Business.SqlImplementation.Helper
{
    public class PropertyTraceEntityMapper
    {
        public PropertyTraceEntity GetPropertyTraceEntity(int idProperty, PropertyTrace propertyTrace )
        {
            return new PropertyTraceEntity
            {
                idPropertyTrace = propertyTrace.id,
                idProperty = idProperty,
                dateSale = propertyTrace.dateSale,
                name = propertyTrace.name,
                value = propertyTrace.value,
                tax = propertyTrace.tax
            };
        } 
    }
}

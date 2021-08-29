using Domain.Object;
using Infraestructure.Entity;
using System.Collections.Generic;

namespace Infraestructure.Business.SqlImplementation.DB
{
    public interface IDataHelper
    {
        List<PropertyEntity> GetPropertyEntities(QueryAttribute queryAttribute);
        void InsertImage(PropertyImageEntity propertyImageEntity);
        void UpdatePrice(int idProperty, decimal price);
        void UpdateProperty(PropertyEntity propertyEntity);
        void InsertProperty(PropertyEntity propertyEntity);
    }
}

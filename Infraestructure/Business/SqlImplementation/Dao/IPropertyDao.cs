using Domain.Object;
using Infraestructure.Entity;
using System.Collections.Generic;

namespace Infraestructure.Business.SqlImplementation.Dao
{
    public interface IPropertyDao
    {
        void UpdatePrice(int idProperty, decimal price);
        void Create(PropertyEntity propertyEntity);
        void Update(PropertyEntity propertyEntity);
        List<PropertyEntity> Get(QueryAttribute queryAttribute);
    }
}


using Domain.Object;
using Infraestructure.Business.SqlImplementation.DB;
using Infraestructure.Entity;
using System.Collections.Generic;

namespace Infraestructure.Business.SqlImplementation.Dao
{
    public class PropertyDao : IPropertyDao
    {
        private readonly IDataHelper dataHelper;

        public PropertyDao(IDataHelper dataHelper)
        {
            this.dataHelper = dataHelper;
        }

        public void Create(PropertyEntity propertyEntity)
        {
            dataHelper.InsertProperty(propertyEntity);
        }

        public List<PropertyEntity> Get(QueryAttribute queryAttribute)
        {
            return dataHelper.GetPropertyEntities(queryAttribute);
        }

        public void Update(PropertyEntity propertyEntity)
        {
            dataHelper.UpdateProperty(propertyEntity);
        }

        public void UpdatePrice(int idProperty, decimal price)
        {
            dataHelper.UpdatePrice(idProperty, price);
        }

        

        
    }
}

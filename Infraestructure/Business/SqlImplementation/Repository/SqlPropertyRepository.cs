using Domain.Business.Output;
using Domain.Object;
using Infraestructure.Business.SqlImplementation.Dao;
using Infraestructure.Business.SqlImplementation.Helper;
using Infraestructure.Entity;
using System.Collections.Generic;

namespace Infraestructure.Business.Input
{
    public class SqlPropertyRepository : IPropertyRepository
    {
        private readonly IPropertyDao propertyDao;
        private readonly PropertyEntityMapper propertyEntityMapper;
        public SqlPropertyRepository(
            IPropertyDao propertyDao,
            PropertyEntityMapper propertyEntityMapper)
        {
            this.propertyDao = propertyDao;
            this.propertyEntityMapper = propertyEntityMapper;
        }

        public void add(string idOwner, Property property)
        {
            PropertyEntity propertyEntity = propertyEntityMapper.GetPropertyEntity(idOwner, property);
            propertyDao.Create(propertyEntity);
        }

        public List<Property> getProperties(QueryAttribute queryAttribute)
        {
            List<PropertyEntity> propertyEntities = propertyDao.Get(queryAttribute);
            List<Property> propertyResponses = new List<Property>();
            propertyEntities.ForEach(x =>
            {
                propertyResponses.Add(propertyEntityMapper.GetProperty(x));
            });

            return propertyResponses;
        }

        public void update(Property property)
        {
            PropertyEntity propertyEntity = propertyEntityMapper.GetPropertyEntity(property);
            propertyDao.Update(propertyEntity);
        }

        public void updatePrice(int idProperty, decimal price)
        {
            propertyDao.UpdatePrice(idProperty, price);
        }

    }
}

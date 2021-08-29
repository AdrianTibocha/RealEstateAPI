using Domain.Business;
using Domain.Business.Output;
using Domain.Object;
using System.Collections.Generic;

namespace Domain
{
    public class FactoryProperty : IFactoryProperty
    {
        private readonly IPropertyImageRepository propertyImageRepository;
        private readonly IPropertyRepository propertyRepository;

        public FactoryProperty(IPropertyImageRepository propertyImageRepository, IPropertyRepository propertyRepository)
        {
            this.propertyRepository = propertyRepository;
            this.propertyImageRepository = propertyImageRepository;
        }

        public void create(string idOwner, Property property) 
        {
            propertyRepository.add(idOwner, property);
        }
        public void update(Property property) 
        {
            propertyRepository.update(property);
        }
        public List<Property> getPropertys(QueryAttribute queryAttribute)
        {
            return propertyRepository.getProperties(queryAttribute);
        }
        public void addImage(int idProperty, PropertyImage propertyImage)
        {
            propertyImageRepository.add(idProperty, propertyImage);
        }
        public void updatePrice(int idProperty, decimal price)
        {
            propertyRepository.updatePrice(idProperty, price);
        }
    }
}

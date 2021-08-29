using Domain.Object;
using System.Collections.Generic;

namespace Domain.Business
{
    public interface IFactoryProperty
    {
        void create(string idOwner, Property property);
        void update(Property property);
        void addImage(int idProperty, PropertyImage propertyImage);
        void updatePrice(int idProperty, decimal price);
        List<Property> getPropertys(QueryAttribute QueryAttribute);
    }
}

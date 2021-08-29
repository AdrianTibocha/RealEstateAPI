using Domain.Object;
using System.Collections.Generic;

namespace Domain.Business.Output
{
    public interface IPropertyRepository
    {
        void add(string idOwner, Property property);
        void update(Property property);
        void updatePrice(int idProperty, decimal price);
        List<Property> getProperties(QueryAttribute queryAttribute);
    }
}

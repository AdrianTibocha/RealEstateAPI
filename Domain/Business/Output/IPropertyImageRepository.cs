using Domain.Object;

namespace Domain.Business.Output
{
    public interface IPropertyImageRepository
    {
        void add(int idProperty, PropertyImage propertyImage);
    }
}

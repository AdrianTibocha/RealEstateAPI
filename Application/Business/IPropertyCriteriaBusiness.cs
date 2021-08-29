using Domain.Object;

namespace Application.Business
{
    public interface IPropertyCriteriaBusiness
    {
        QueryAttribute GetPropertyCriteria(string attribute, string value, string filter);
    }
}

using Infraestructure.Business.SqlImplementation.DB;
using Infraestructure.Entity;

namespace Infraestructure.Business.SqlImplementation.Dao
{
    public class ImagePropertyDao : IImagePropertyDao
    {
        private readonly IDataHelper dataHelper;

        public ImagePropertyDao(IDataHelper dataHelper)
        {
            this.dataHelper = dataHelper;
        }

        public void Create(PropertyImageEntity propertyImageEntity)
        {
            dataHelper.InsertImage(propertyImageEntity);
        }
    }
}

using Domain.Business.Output;
using Domain.Object;
using Infraestructure.Business.SqlImplementation.Dao;
using Infraestructure.Business.SqlImplementation.Helper;
using Infraestructure.Entity;

namespace Infraestructure.Business.Input
{
    public class SqlPropertyImageRepository : IPropertyImageRepository
    {
        private readonly IImagePropertyDao imageDao;
        private readonly PropertyImageEntityMapper propertyImageEntityMapper;

        public SqlPropertyImageRepository(IImagePropertyDao imageDao, PropertyImageEntityMapper propertyImageEntityMapper)
        {
            this.imageDao = imageDao;
            this.propertyImageEntityMapper = propertyImageEntityMapper;
        }

        public void add(int idProperty, PropertyImage propertyImage)
        {
            PropertyImageEntity propertyImageEntity = propertyImageEntityMapper.GetImageEntity(idProperty, propertyImage);
            imageDao.Create(propertyImageEntity);
        }

    }
}

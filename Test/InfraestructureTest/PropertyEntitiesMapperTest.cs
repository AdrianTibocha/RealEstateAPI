using Domain.Object;
using Infraestructure.Business.SqlImplementation.Helper;
using Infraestructure.Entity;
using NUnit.Framework;
using System;

namespace Test.InfraestructureTest
{
    public class PropertyEntitiesMapperTest
    {
        private PropertyImageEntityMapper propertyImageEntityMapper;
        private PropertyEntityMapper propertyEntityMapper;
        private PropertyTraceEntityMapper propertyTraceEntityMapper;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            propertyImageEntityMapper = new PropertyImageEntityMapper();
            propertyEntityMapper = new PropertyEntityMapper();
            propertyTraceEntityMapper = new PropertyTraceEntityMapper();
        }


        [Test]
        public void ShouldReturnAPropertyImageEntityFromAPropertyImage()
        {

            int idPropertyImage = 1;
            PropertyImage propertyImage = new PropertyImage(4)
            {
                filePath = "testPath",
                enabled = true
            };

            PropertyImageEntity propertyImageEntity = propertyImageEntityMapper.GetImageEntity(idPropertyImage, propertyImage);
            Assert.AreEqual(idPropertyImage, propertyImageEntity.idProperty);
            Assert.AreEqual(propertyImage.id, propertyImageEntity.idPropertyImage);
            Assert.AreEqual(propertyImage.filePath, propertyImageEntity.filePath);
            Assert.AreEqual(propertyImage.enabled, propertyImageEntity.enabled);
        }

        [Test]
        public void ShouldReturnAPropertyTraceEntityFromAPropertyTrace()
        {
            int idProperty = 1;
            PropertyTrace propertyTrace = new PropertyTrace(4)
            {
                dateSale = DateTime.Now,
                name = "testTrace",
                value = "1750000",
                tax = 10
            };

            PropertyTraceEntity propertyTraceEntity = propertyTraceEntityMapper.GetPropertyTraceEntity(idProperty, propertyTrace);
            Assert.AreEqual(idProperty, propertyTraceEntity.idProperty);
            Assert.AreEqual(propertyTrace.id, propertyTraceEntity.idPropertyTrace);
            Assert.AreEqual(propertyTrace.dateSale, propertyTraceEntity.dateSale);
            Assert.AreEqual(propertyTrace.value, propertyTraceEntity.value);
            Assert.AreEqual(propertyTrace.tax, propertyTraceEntity.tax);
        }

        [Test]
        public void ShouldReturnAPropertyEntityFromAProperty()
        {
            int idProperty = 1;
            string idOwner = "1016578196";
            Property property = new Property(idProperty)
            {
                name = "nombre prueba",
                address = "direccion prueba",
                price = 1000000,
                codeInternal = "1457",
                year = 1780
            };

            PropertyEntity propertyEntityUpdate = propertyEntityMapper.GetPropertyEntity(property);
            PropertyEntity propertyEntityCreate = propertyEntityMapper.GetPropertyEntity(idOwner, property);

            Assert.AreEqual(idProperty, propertyEntityUpdate.idProperty);
            Assert.AreEqual(property.name, propertyEntityUpdate.name);
            Assert.AreEqual(property.address, propertyEntityUpdate.address);
            Assert.AreEqual(property.price, propertyEntityUpdate.price);
            Assert.AreEqual(property.codeInternal, propertyEntityUpdate.codeInternal);
            Assert.AreEqual(property.year, propertyEntityUpdate.year);

            Assert.AreEqual(idOwner, propertyEntityCreate.idOwner);
            Assert.AreEqual(idProperty, propertyEntityCreate.idProperty);
            Assert.AreEqual(property.name, propertyEntityCreate.name);
            Assert.AreEqual(property.address, propertyEntityCreate.address);
            Assert.AreEqual(property.price, propertyEntityCreate.price);
            Assert.AreEqual(property.codeInternal, propertyEntityCreate.codeInternal);
            Assert.AreEqual(property.year, propertyEntityCreate.year);

        }

        [Test]
        public void ShouldReturnAPropertyFromAPropertyEntity()
        {
            PropertyEntity propertyEntity = new PropertyEntity()
            {
                idProperty = 1,
                name = "nombre prueba",
                address = "direccion prueba",
                price = 1000000,
                codeInternal = "1457",
                year = 1780
            };

            Property property = propertyEntityMapper.GetProperty(propertyEntity);

            Assert.AreEqual(propertyEntity.idProperty, property.id);
            Assert.AreEqual(propertyEntity.name, property.name);
            Assert.AreEqual(propertyEntity.address, property.address);
            Assert.AreEqual(propertyEntity.price, property.price);
            Assert.AreEqual(propertyEntity.codeInternal, property.codeInternal);
            Assert.AreEqual(propertyEntity.year, property.year);
        }

    }
}

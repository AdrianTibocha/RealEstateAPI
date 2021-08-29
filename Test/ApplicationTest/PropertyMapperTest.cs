using Application.Dto;
using Application.Dto.ResponseObject;
using Application.Helper;
using Domain.Object;
using NUnit.Framework;

namespace Test.ApplicationTest
{
    public class PropertyMapperTest
    {
        private PropertyMapper propertyMapper;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            propertyMapper = new PropertyMapper();
        }

        [Test]
        public void ShouldReturnAPropertyImageObjectFromAFilePath()
        {
            string filePath = "testPath";
            PropertyImage propertyImage = propertyMapper.GetPropertyImage(filePath);
            Assert.AreEqual(filePath, propertyImage.filePath);
        }

        [Test]
        public void ShouldReturnAPropertyFromACreatePropertyRequest()
        {
            CreatePropertyRequest createPropertyRequest = new CreatePropertyRequest()
            {
                name = "nombre prueba",
                address = "direccion prueba",
                price = 1000000,
                codeInternal = "1457",
                year = 1780
            };

            Property property = propertyMapper.GetProperty(createPropertyRequest);
            Assert.AreEqual(createPropertyRequest.name, property.name);
            Assert.AreEqual(createPropertyRequest.address, property.address);
            Assert.AreEqual(createPropertyRequest.price, property.price);
            Assert.AreEqual(createPropertyRequest.codeInternal, property.codeInternal);
            Assert.AreEqual(createPropertyRequest.year, property.year);
        }

        [Test]
        public void ShouldReturnAPropertyFromAPropertyRequest()
        {
            PropertyRequest propertyRequest = new PropertyRequest()
            {
                name = "nombre prueba",
                address = "direccion prueba",
                price = 1000000,
                codeInternal = "1457",
                year = 1780
            };
            int idProperty = 4;

            Property property = propertyMapper.GetProperty(idProperty, propertyRequest);
            Assert.AreEqual(idProperty, property.id);
            Assert.AreEqual(propertyRequest.name, property.name);
            Assert.AreEqual(propertyRequest.address, property.address);
            Assert.AreEqual(propertyRequest.price, property.price);
            Assert.AreEqual(propertyRequest.codeInternal, property.codeInternal);
            Assert.AreEqual(propertyRequest.year, property.year);
        }

        [Test]
        public void ShouldReturnAPropertyResponseFromAProperty()
        {
            int idProperty = 4;
            Property property = new Property(idProperty)
            {
                name = "nombre prueba",
                address = "direccion prueba",
                price = 1000000,
                codeInternal = "1457",
                year = 1780
            };

            PropertyResponse propertyResponse = propertyMapper.GetPropertyResponse(property);
            Assert.AreEqual(idProperty, propertyResponse.id);
            Assert.AreEqual(property.name, propertyResponse.name);
            Assert.AreEqual(property.address, propertyResponse.address);
            Assert.AreEqual(property.price, propertyResponse.price);
            Assert.AreEqual(property.codeInternal, propertyResponse.codeInternal);
            Assert.AreEqual(property.year, propertyResponse.year);
        }

    }
}

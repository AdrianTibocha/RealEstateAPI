using Application.Helper.CustomException;
using Dapper;
using Domain.Object;
using Infraestructure.Business.SqlImplementation.DB;
using Infraestructure.Business.SqlImplementation.Helper.CustomException;
using Infraestructure.Entity;
using Moq;
using NUnit.Framework;

namespace Test.InfraestructureTest
{
    public class DataTest
    {
        private Data data;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            var dataMock = new Mock<Data>("testConnection").Object;
            Mock.Get(dataMock).Setup(x => x.GetList<It.IsAnyType>(It.IsAny<string>(), It.IsAny<DynamicParameters>())).Throws<CustomSqlException>();
            data = dataMock;
        }

        [Test]
        public void ShouldThrowPropertySearchExceptionByCustomSqlExceptio()
        {
            StringAttribute queryAttribute = new StringAttribute(); 
            Assert.Throws<PropertySearchException>(() => data.GetPropertyEntities(queryAttribute));
        }

        [Test]
        public void ShouldThrowPropertyNotFoundException()
        {
            Mock.Get(data).Setup(x => x.ExecuteSingle(It.IsAny<string>(), It.IsAny<DynamicParameters>())).Returns(0);
            PropertyEntity propertyEntity = new PropertyEntity();
            Assert.Throws<PropertyNotFoundException>(() => data.UpdatePrice(1, 4));
            Assert.Throws<PropertyNotFoundException>(() => data.UpdateProperty(propertyEntity));
        }

        [Test]
        public void ShouldThrowNewImageExceptionByCustomSqlExceptio()
        {
            Mock.Get(data).Setup(x => x.ExecuteSingle(It.IsAny<string>(), It.IsAny<DynamicParameters>())).Throws<CustomSqlException>();
            PropertyImageEntity propertyImage = new PropertyImageEntity();
            Assert.Throws<NewImageException>(() => data.InsertImage(propertyImage));
        }

        [Test]
        public void ShouldThrowNewPropertyExceptionByCustomSqlExceptio()
        {
            Mock.Get(data).Setup(x => x.ExecuteSingle(It.IsAny<string>(), It.IsAny<DynamicParameters>())).Throws<CustomSqlException>();
            PropertyEntity propertyEntity = new PropertyEntity();
            Assert.Throws<NewPropertyException>(() => data.InsertProperty(propertyEntity));
        }

    }
}

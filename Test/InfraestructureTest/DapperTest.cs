using Dapper;
using Infraestructure.Entity;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Test.InfraestructureTest
{
    public class DapperTest
    {
        private PropertyEntity propertyEntity;
        private DapperMockTest dapperMockTest;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            dapperMockTest = new DapperMockTest(":memory:");
            propertyEntity = new PropertyEntity()
            {
                idProperty = 1,
                idOwner = "123",
                name = "nombre prueba",
                address = "direccion prueba",
                price = 1000000,
                codeInternal = "1457",
                year = 1780
            };
        }

        [Test]
        public void ShouldThrowArgumentNullExceptionByEmptyConnectionString()
        {
            Assert.Throws<ArgumentNullException>(() => new DapperMockTest(""));
        }

        [Test, Order(1)]
        public void ShouldInsertPropertyEntity()
        {

            string insertSqlCommand = "insert into PropertyEntity (IdProperty, Name, Address, Price, CodeInternal, Year, IdOwner) values " +
                    "(@idProperty, @Name, @Address, @Price, @CodeInternal, @Year, @IdOwner)";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@idProperty", propertyEntity.idProperty);
            dynamicParameters.Add("@Name", propertyEntity.name);
            dynamicParameters.Add("@Address", propertyEntity.address);
            dynamicParameters.Add("@Price", propertyEntity.price);
            dynamicParameters.Add("@CodeInternal", propertyEntity.codeInternal);
            dynamicParameters.Add("@Year", propertyEntity.year);
            dynamicParameters.Add("@IdOwner", propertyEntity.idOwner);

            int result = dapperMockTest.ExecuteSingle(insertSqlCommand, dynamicParameters);

            Assert.AreEqual(1, result);
        }

        [Test, Order(2)]
        public void ShouldRetrievePropertyInserted()
        {
            string querySqlCommand = $"select * from PropertyEntity where IdProperty = @idProperty";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@idProperty", propertyEntity.idProperty);

            List<PropertyEntity> properties = dapperMockTest.GetList<PropertyEntity>(querySqlCommand, dynamicParameters);

            var expectedObjectJson = JsonConvert.SerializeObject(propertyEntity);
            var resultObjectJson = JsonConvert.SerializeObject(properties[0]);

            Assert.AreEqual(expectedObjectJson, resultObjectJson);
        }
    
    }
}

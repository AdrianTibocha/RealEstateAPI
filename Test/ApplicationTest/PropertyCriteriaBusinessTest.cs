using Application.Business;
using Application.Helper.CustomException;
using Domain.Object;
using NUnit.Framework;

namespace Test.ApplicationTest
{
    public class PropertyCriteriaBusinessTest
    {

        [Test]
        [TestCase("nombre","propiedad prueba","igual")]
        [TestCase("precio", "1785000", "mayor")]
        [TestCase("año", "1000", "igual")]
        public void ShouldThrowFilterPropertyException(string attribute, string value, string filter)
        {
            PropertyCriteriaBusiness propertyCriteriaBusiness = new PropertyCriteriaBusiness();

            Assert.Throws<FilterPropertyException>(() => propertyCriteriaBusiness.GetPropertyCriteria(attribute,value,filter));
        }

        [Test]
        [TestCase("name", "propiedad prueba", "equal")]
        [TestCase("codeInternal", "1234", "contains")]
        public void ShouldReturnStringQueryAttribute(string attribute, string value, string filter)
        {
            PropertyCriteriaBusiness propertyCriteriaBusiness = new PropertyCriteriaBusiness();
            QueryAttribute queryAttribute = propertyCriteriaBusiness.GetPropertyCriteria(attribute, value, filter);

            Assert.AreEqual(AttributeType.String, queryAttribute.type);
        }

        [Test]
        [TestCase("price", "1785000", "equal")]
        public void ShouldReturnDecimalQueryAttribute(string attribute, string value, string filter)
        {
            PropertyCriteriaBusiness propertyCriteriaBusiness = new PropertyCriteriaBusiness();
            QueryAttribute queryAttribute = propertyCriteriaBusiness.GetPropertyCriteria(attribute, value, filter);

            Assert.AreEqual(AttributeType.Decimal, queryAttribute.type);
        }

        [Test]
        [TestCase("year", "1785000", "greaterthan")]
        public void ShouldReturnIntegerQueryAttribute(string attribute, string value, string filter)
        {
            PropertyCriteriaBusiness propertyCriteriaBusiness = new PropertyCriteriaBusiness();
            QueryAttribute queryAttribute = propertyCriteriaBusiness.GetPropertyCriteria(attribute, value, filter);

            Assert.AreEqual(AttributeType.Integer, queryAttribute.type);
        }
    }
}

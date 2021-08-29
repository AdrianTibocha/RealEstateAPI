using Application.Helper.CustomException;
using Dapper;
using Domain.Object;
using Infraestructure.Business.SqlImplementation.Helper.CustomException;
using Infraestructure.Entity;
using System;
using System.Collections.Generic;

namespace Infraestructure.Business.SqlImplementation.DB
{
    public class Data : Dapper, IDataHelper
    {
        public Data(string connectionString) : base(connectionString)
        {
        }

        public List<PropertyEntity> GetPropertyEntities(QueryAttribute queryAttribute)
        {
            try
            {
                var sqlTuple = GetSqlQuery(queryAttribute);
                string sqlCommand = $"select * from dbo.[Property] where {queryAttribute.name} {sqlTuple.Item1}";
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@value", sqlTuple.Item2);

                return GetList<PropertyEntity>(sqlCommand, dynamicParameters);
            }
            catch (Exception ex) when (ex is CustomSqlException)
            {
                throw new PropertySearchException($"Error al consultar atributo: {queryAttribute.name}");
            }
        }

        public void InsertImage(PropertyImageEntity propertyImageEntity)
        {
            try
            {
                string sqlCommand = "insert into dbo.[PropertyImage] (IdProperty, FilePath, Enabled) values (@IdProperty, @FilePath, @Enabled)";
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@IdProperty", propertyImageEntity.idProperty);
                dynamicParameters.Add("@FilePath", propertyImageEntity.filePath);
                dynamicParameters.Add("@Enabled", propertyImageEntity.enabled);

                ExecuteSingle(sqlCommand, dynamicParameters);
            }
            catch (Exception ex) when (ex is CustomSqlException)
            {
                throw new NewImageException($"Error en la insercion de nueva imagen para la propiedad con id {propertyImageEntity.idProperty}");
            }
        }

        public void UpdatePrice(int idProperty, decimal price)
        {
            string sqlCommand = @"update dbo.[Property] set Price = @Price where IdProperty = @IdProperty";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@Price", price);
            dynamicParameters.Add("@IdProperty", idProperty);

            int result = ExecuteSingle(sqlCommand, dynamicParameters);
            if (result == 0)
                throw new PropertyNotFoundException($"Precio no actualizado, no se encontro propiedad con el id {idProperty}");
        }

        public void InsertProperty(PropertyEntity propertyEntity)
        {
            try
            {
                string sqlCommand = "insert into dbo.[Property] (Name, Address, Price, CodeInternal, Year, IdOwner) values " +
                    "(@Name, @Address, @Price, @CodeInternal, @Year, @IdOwner)";
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@Name", propertyEntity.name);
                dynamicParameters.Add("@Address", propertyEntity.address);
                dynamicParameters.Add("@Price", propertyEntity.price);
                dynamicParameters.Add("@CodeInternal", propertyEntity.codeInternal);
                dynamicParameters.Add("@Year", propertyEntity.year);
                dynamicParameters.Add("@IdOwner", propertyEntity.idOwner);

                ExecuteSingle(sqlCommand, dynamicParameters);
            }
            catch (Exception ex) when (ex is CustomSqlException)
            {
                throw new NewPropertyException($"Error en la creacion de nueva propiedad con idOwner {propertyEntity.idOwner} ");
            }
        }

        public void UpdateProperty(PropertyEntity propertyEntity)
        {
            string sqlCommand = "update dbo.[Property] set Name = @Name, Address = @Address, Price = @Price, CodeInternal = @CodeInternal," +
                "Year = @Year where IdProperty = @IdProperty";

            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@Name", propertyEntity.name);
            dynamicParameters.Add("@Address", propertyEntity.address);
            dynamicParameters.Add("@Price", propertyEntity.price);
            dynamicParameters.Add("@CodeInternal", propertyEntity.codeInternal);
            dynamicParameters.Add("@Year", propertyEntity.year);
            dynamicParameters.Add("@IdProperty", propertyEntity.idProperty);

            int result = ExecuteSingle(sqlCommand, dynamicParameters);
            if (result == 0)
                throw new PropertyNotFoundException($"Propiedad no actualizada, no se encontro propiedad con el id {propertyEntity.idProperty}");
        }

        private Tuple<string, object> GetSqlQuery(QueryAttribute queryAttribute)
        {
            string sqlQuery = "";
            object value = new object();
            switch (queryAttribute.type)
            {
                case AttributeType.String:
                    StringAttribute stringAttribute = ((StringAttribute)queryAttribute);
                    sqlQuery = GetSqlQueryStringCondition(stringAttribute.condition);
                    value = stringAttribute.value;
                    break;
                case AttributeType.Decimal:
                    DecimalAttribute decimalAttribute = ((DecimalAttribute)queryAttribute);
                    sqlQuery = GetSqlQueryNumericCondition(decimalAttribute.condition);
                    value = decimalAttribute.value;
                    break;
                case AttributeType.Integer:
                    IntegerAttribute integerAttribute = ((IntegerAttribute)queryAttribute);
                    sqlQuery = GetSqlQueryNumericCondition(integerAttribute.condition);
                    value = integerAttribute.value;
                    break;
            }

            return new Tuple<string, object>(sqlQuery, value);
        }

        private string GetSqlQueryStringCondition(StringCondition stringCondition)
        {
            if (stringCondition.Equals(StringCondition.Equal))
            {
                return " = @value";
            }
            else
            {
                return @" like '%' + @value + '%' ";
            }
        }

        private string GetSqlQueryNumericCondition(NumericCondition numericCondition)
        {
            if (numericCondition.Equals(NumericCondition.Equal))
            {
                return " = @value";
            }
            else if (numericCondition.Equals(NumericCondition.GreaterThan))
            {
                return " > @value";
            }
            else
            {
                return " < @value";
            }
        }

    }
}


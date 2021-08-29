using Application.Helper.CustomException;
using Domain.Object;
using System;

namespace Application.Business
{
    public class PropertyCriteriaBusiness : IPropertyCriteriaBusiness
    {
        public QueryAttribute GetPropertyCriteria(string attribute, string value, string filter)
        {
            string targetAttribute = attribute.ToLower();
            PropertyAttribute propertyAttribute;
            if (!Enum.TryParse(attribute, true, out propertyAttribute))
                throw new FilterPropertyException($"No existe ningun atributo de propiedad correspondiente a {attribute}, " +
                    $"solo son validos {string.Join(", ", Enum.GetNames(typeof(PropertyAttribute)))} ");

            switch (propertyAttribute)
            {
                case PropertyAttribute.Name:
                case PropertyAttribute.Address:
                case PropertyAttribute.CodeInternal:
                    StringCondition stringCondition = GetStringCondition(filter);
                    return new StringAttribute { name = targetAttribute, value = value, condition = stringCondition };
                case PropertyAttribute.Price:
                    NumericCondition decimalCondition = GetNumericCondition(filter);
                    decimal price;
                    if (!decimal.TryParse(value, out price))
                        throw new FilterPropertyException($"Incapaz de convertir {value} en numero decimal");
                    return new DecimalAttribute { name = targetAttribute, value = price, condition = decimalCondition };
                case PropertyAttribute.Year:
                    NumericCondition integerCondition = GetNumericCondition(filter);
                    int year;
                    if(!int.TryParse(value, out year))
                        throw new FilterPropertyException($"Incapaz de convertir {value} en numero entero");
                    return new IntegerAttribute { name = targetAttribute, value = year, condition = integerCondition };
                default:
                    throw new FilterPropertyException($"Atributo {attribute} no valido para operacion de busqueda");
            }

        }


        private StringCondition GetStringCondition(string filter)
        {
            StringCondition stringCondition;
            if (Enum.TryParse(filter, true, out stringCondition))
            {
                return stringCondition;
            }
            throw new FilterPropertyException($"Filtro {filter} no aceptado, para un dato no numerico solo se " +
                $"aceptan {string.Join(", ", Enum.GetNames(typeof(StringCondition)))}"); 
        }

        private NumericCondition GetNumericCondition(string filter)
        {
            NumericCondition numericCondition;
            if (Enum.TryParse(filter, true, out numericCondition))
            {
                return numericCondition;
            }
            throw new FilterPropertyException($"Filtro {filter} no aceptado, para un dato numerico solo se " +
                $"aceptan {string.Join(", ", Enum.GetNames(typeof(NumericCondition)))}");
        }

    }
}

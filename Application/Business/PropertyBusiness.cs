using Application.Business.Input;
using Application.Dto;
using Application.Dto.ResponseObject;
using Application.Helper;
using Domain.Business;
using Domain.Object;
using System.Collections.Generic;

namespace Application.Business
{
    public class PropertyBusiness : IPropertyBusiness
    {
        private readonly ImageBusiness imageBusiness;
        private readonly IPropertyCriteriaBusiness propertyCriteriaBusiness;
        private readonly IPropertyMapper propertyMapper;
        private readonly IFactoryProperty factoryProperty;

        public PropertyBusiness(
            ImageBusiness imageBusiness,
            IPropertyMapper propertyMapper,
            IFactoryProperty factoryProperty,
            IPropertyCriteriaBusiness propertyCriteriaBusiness)
        {
            this.imageBusiness = imageBusiness;
            this.propertyMapper = propertyMapper;
            this.factoryProperty = factoryProperty;
            this.propertyCriteriaBusiness = propertyCriteriaBusiness;
        }
        public Response AddImage(int idProperty, ImageRequest ImageRequest)
        {
            string filePath = imageBusiness.GetFilePath(ImageRequest.formFile, idProperty);
            factoryProperty.addImage(idProperty, propertyMapper.GetPropertyImage(filePath));
            return new Response { status = StatusResponse.Success, message = ResponseMessage.PropertyAddImageSuccessful.value };
        }

        public Response Create(CreatePropertyRequest newPropertyRequest)
        {
            factoryProperty.create(newPropertyRequest.idOwner, propertyMapper.GetProperty(newPropertyRequest));
            return new Response { status = StatusResponse.Success, message = ResponseMessage.PropertyCreatedSuccessful.value };
        }

        public List<PropertyResponse> Get(string attribute, string value, string filter)
        {
            QueryAttribute queryAttribute = propertyCriteriaBusiness.GetPropertyCriteria(attribute, value, filter);
            List<Property> properties = factoryProperty.getPropertys(queryAttribute);
            List<PropertyResponse> propertyResponses = new List<PropertyResponse>();
            properties.ForEach(x =>
            {
                propertyResponses.Add(propertyMapper.GetPropertyResponse(x));
            });

            return propertyResponses;
        }

        public Response Update(int idProperty, PropertyRequest property)
        {
            factoryProperty.update(propertyMapper.GetProperty(idProperty, property));
            return new Response { status = StatusResponse.Success, message = ResponseMessage.PropertyUpdateSuccessful.value };
        }

        public Response UpdatePrice(int idProperty, PricePropertyRequest newPricePropertyRequest)
        {
            factoryProperty.updatePrice(idProperty, newPricePropertyRequest.price);
            return new Response { status = StatusResponse.Success, message = ResponseMessage.PropertyChangePriceSuccessful.value };
        }
    }
}

using Application.Business.Input;
using Application.Dto;
using Application.Dto.ResponseObject;
using Application.Helper.CustomException;
using Domain.Object;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Moq;
using Newtonsoft.Json;
using NUnit.Framework;
using RealState;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;

namespace Test.PresentationTest
{
    public class PropertyControllerTest
    {
        HttpClient client;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            Response successfulResponse = new Response() { status = StatusResponse.Success };
            List<PropertyResponse> propertyResponses = new List<PropertyResponse>();
            var propertyBusinessMock = Mock.Of<IPropertyBusiness>();
            Mock.Get(propertyBusinessMock)
                .Setup(x=> x.Create(It.IsAny<CreatePropertyRequest>()))
                .Returns(successfulResponse);
            Mock.Get(propertyBusinessMock)
                .Setup(x => x.Update(It.IsAny<int>(),It.IsAny<PropertyRequest>()))
                .Returns(successfulResponse);
            Mock.Get(propertyBusinessMock)
                .Setup(x => x.Get(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                .Returns<string,string,string>((x,y,z) => {
                    Domain.Object.PropertyAttribute propertyAttribute;
                    StringCondition stringCondition;
                    if (Enum.TryParse(x, true, out propertyAttribute) && Enum.TryParse(z, true, out stringCondition))
                    {
                        return new List<PropertyResponse>();
                    }
                    else
                    {
                        throw new FilterPropertyException();
                    } 
                });
            Mock.Get(propertyBusinessMock)
                .Setup(x => x.AddImage(It.IsAny<int>(), It.IsAny<ImageRequest>()))
                .Returns(successfulResponse);
            Mock.Get(propertyBusinessMock)
                .Setup(x => x.UpdatePrice(It.IsAny<int>(), It.IsAny<PricePropertyRequest>()))
                .Returns(successfulResponse);

            var webHostBuilder = new WebHostBuilder()
                .ConfigureTestServices(services => {
                    services.RemoveAll<IPropertyBusiness>();
                    services.TryAddScoped(x => propertyBusinessMock);
                })
                .UseStartup<Startup>();

            var server = new TestServer(webHostBuilder);
            client = server.CreateClient();
        }

        [Test]
        public void ShouldReturnBadRequestResponseByRequestNewProperty()
        {
            var result = client.PostAsJsonAsync("/Property", new CreatePropertyRequest()).Result;
            Response response = JsonConvert.DeserializeObject<Response>(result.Content.ReadAsStringAsync().Result);

            Assert.AreEqual(400, (int) result.StatusCode);
            Assert.AreEqual(StatusResponse.UserError, response.status);
        }

        [Test]
        public void ShouldReturnSuccessfulRequestResponseByRequestNewProperty()
        {
            CreatePropertyRequest createPropertyRequest = new CreatePropertyRequest()
            {
                idOwner = "1016025478",
                name = "propiedad prueba",
                address = "Calle 68 # 78 - 87",
                price = 1758000,
                codeInternal = "17548",
                year = 1897

            };

            var result = client.PostAsJsonAsync("/Property", createPropertyRequest).Result;
            Response response = JsonConvert.DeserializeObject<Response>(result.Content.ReadAsStringAsync().Result);

            Assert.AreEqual(200, (int)result.StatusCode);
            Assert.AreEqual(StatusResponse.Success, response.status);
        }

        [Test]
        public void ShouldReturnBadRequestResponseByRequestUpdateProperty()
        {
            var result = client.PutAsJsonAsync("/Property/1", new PropertyRequest()).Result;
            Response response = JsonConvert.DeserializeObject<Response>(result.Content.ReadAsStringAsync().Result);

            Assert.AreEqual(400, (int)result.StatusCode);
            Assert.AreEqual(StatusResponse.UserError, response.status);
        }

        [Test]
        public void ShouldReturnSuccessfulRequestResponseByRequestCreateProperty()
        {
            PropertyRequest propertyRequest = new PropertyRequest()
            {
                name = "propiedad prueba",
                address = "Calle 68 # 78 - 87",
                price = 1758000,
                codeInternal = "17548",
                year = 1897
            };

            var result = client.PutAsJsonAsync("/Property/1", propertyRequest).Result;
            Response response = JsonConvert.DeserializeObject<Response>(result.Content.ReadAsStringAsync().Result);

            Assert.AreEqual(200, (int)result.StatusCode);
            Assert.AreEqual(StatusResponse.Success, response.status);
        }

        [Test]
        public void ShouldReturnBadRequestResponseByRequestUpdatePropertyPrice()
        {
            var result = client.PutAsJsonAsync("/Property/4/price", new PricePropertyRequest()).Result;
            Response response = JsonConvert.DeserializeObject<Response>(result.Content.ReadAsStringAsync().Result);

            Assert.AreEqual(400, (int)result.StatusCode);
            Assert.AreEqual(StatusResponse.UserError, response.status);
        }

        [Test]
        public void ShouldReturnSuccessfulRequestResponseByRequestUpdatePropertyPrice()
        {
            PricePropertyRequest pricePropertyRequest = new PricePropertyRequest()
            {
                price = 1850000
            };

            var result = client.PutAsJsonAsync("/Property/4/price", pricePropertyRequest).Result;
            Response response = JsonConvert.DeserializeObject<Response>(result.Content.ReadAsStringAsync().Result);

            Assert.AreEqual(200, (int)result.StatusCode);
            Assert.AreEqual(StatusResponse.Success, response.status);
        }

        [Test]
        public void ShouldReturnSuccessfulRequestResponseByGetProperties()
        {
            var result = client.GetAsync("/Property/Name/propiedad/Equal").Result;
            Assert.AreEqual(200, (int)result.StatusCode);
        }

        [Test]
        public void ShouldReturnRequestResponseByGetProperties()
        {
            var result = client.GetAsync("/Property/nombre/propiedad/igual").Result;
            Assert.AreEqual(400, (int)result.StatusCode);
        }

        [Test]
        public void ShouldReturnBadRequestResponseByNewImage()
        {
            var result = client.PutAsJsonAsync("/Property/4/image", new ImageRequest()).Result;
            Response response = JsonConvert.DeserializeObject<Response>(result.Content.ReadAsStringAsync().Result);

            Assert.AreEqual(400, (int)result.StatusCode);
            Assert.AreEqual(StatusResponse.UserError, response.status);
        }

        [Test]
        public void ShouldReturnSuccessfulRequestResponseByNewImage()
        {
            var content = new MultipartFormDataContent();
            content.Add(new ByteArrayContent(Encoding.UTF8.GetBytes("prueba")), "formFile", "test.jpeg");

            var result = client.PutAsync("/Property/4/image", content).Result;
            Response response = JsonConvert.DeserializeObject<Response>(result.Content.ReadAsStringAsync().Result);

            Assert.AreEqual(200, (int)result.StatusCode);
            Assert.AreEqual(StatusResponse.Success, response.status);
        }


    }
}

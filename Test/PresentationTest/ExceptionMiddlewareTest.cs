using Application.Dto.ResponseObject;
using Application.Helper.CustomException;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using NUnit.Framework;
using Presentation.Business;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Test.PresentationTest
{
    public class ExceptionMiddlewareTest
    {
        DefaultHttpContext defaultHttpContext;

        [SetUp]
        public void Setup()
        {
            defaultHttpContext = new DefaultHttpContext();
            defaultHttpContext.Response.Body = new MemoryStream();
            defaultHttpContext.Request.Path = "/";
        }

        [Test]
        public async Task ShouldReturnBadRequestResponseByRequestUserFailed()
        {   
            ExceptionMiddleware exceptionMiddleware = new ExceptionMiddleware(next: (innerHttpContext) =>
            {
                throw new ImageUploadFailedException();
            });

            await exceptionMiddleware.InvokeAsync(defaultHttpContext);

            defaultHttpContext.Response.Body.Seek(0, SeekOrigin.Begin);
            string bodyResponse = new StreamReader(defaultHttpContext.Response.Body).ReadToEnd();
            Response response = JsonConvert.DeserializeObject<Response>(bodyResponse);

            Assert.AreEqual(400, defaultHttpContext.Response.StatusCode);
            Assert.AreEqual(StatusResponse.UserError, response.status);
        }

        [Test]
        public async Task ShouldReturnInternarServelErrorResponseByUnhandledException()
        {
            ExceptionMiddleware exceptionMiddleware = new ExceptionMiddleware(next: (innerHttpContext) =>
            {
                throw new Exception();
            });

            await exceptionMiddleware.InvokeAsync(defaultHttpContext);

            defaultHttpContext.Response.Body.Seek(0, SeekOrigin.Begin);
            string bodyResponse = new StreamReader(defaultHttpContext.Response.Body).ReadToEnd();
            Response response = JsonConvert.DeserializeObject<Response>(bodyResponse);

            Assert.AreEqual(500, defaultHttpContext.Response.StatusCode);
            Assert.AreEqual(StatusResponse.SystemError, response.status);
        }

    }
}
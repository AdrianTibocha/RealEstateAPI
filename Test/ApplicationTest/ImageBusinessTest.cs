using Application.Business;
using Application.Helper.CustomException;
using Microsoft.AspNetCore.Http;
using Moq;
using NUnit.Framework;
using System.IO;

namespace Test.ApplicationTest
{
    public class ImageBusinessTest
    {

        [Test]
        public void ShouldThrowImageUploadFailedExceptionByFormFileNoContent()
        {
            var formFileMock = new Mock<IFormFile>();
            formFileMock.Setup(x => x.Length).Returns(0);

            ImageBusiness imageBusiness = new ImageBusiness("path");
            Assert.Throws<ImageUploadFailedException>(() => imageBusiness.GetFilePath(formFileMock.Object, 4));

        }

        [Test]
        public void ShouldReturnPathFromFileUploaded()
        {
            string rootPath = "rutaPruebas";
            string fileName = "archivoPrueba.jpg";
            int idProperty = 4;

            var formFileMock = new Mock<IFormFile>();
            formFileMock.Setup(x => x.Length).Returns(1);
            formFileMock.Setup(x => x.FileName).Returns(fileName);


            ImageBusiness imageBusiness = new ImageBusiness(rootPath);
            string pathImage = imageBusiness.GetFilePath(formFileMock.Object, idProperty);
            string pathImageExpected = $"{Directory.GetCurrentDirectory()}/{rootPath}/{idProperty}/{fileName}";

            Assert.AreEqual(pathImageExpected, pathImage);

            Directory.Delete($"{Directory.GetCurrentDirectory()}/{rootPath}",true);
        }
    }
}

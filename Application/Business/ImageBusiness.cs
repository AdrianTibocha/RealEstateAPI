using Application.Helper.CustomException;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.IO;

namespace Application.Business
{
    public class ImageBusiness
    {
        private readonly string imagePath;
        private readonly List<string> allowedExtensions;
        public ImageBusiness(string imagePath)
        {
            this.imagePath = imagePath;
            this.allowedExtensions = new List<string> { ".jpg", ".png", ".jpeg" };
        }

        public string GetFilePath(IFormFile formFile, int idProperty)
        {
            if (!(formFile.Length > 0))
            {
                throw new ImageUploadFailedException($"Archivo sin contenido");
            }

            ValidateExtension(formFile.FileName);
            string imageDirectory = $"{Directory.GetCurrentDirectory()}/{imagePath}/{idProperty}/";
            CreateImageDirectory(imageDirectory);
            string filePath = $"{imageDirectory}{formFile.FileName}";
            using (FileStream fileStream = File.Create(filePath))
            {
                formFile.CopyTo(fileStream);
                fileStream.Flush();
                return filePath;
            }

        }
        private void CreateImageDirectory(string directory)
        {
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
        }

        private void ValidateExtension(string fileName)
        {
            string extension = Path.GetExtension(fileName);
            if (!allowedExtensions.Contains(extension))
            {
                throw new ImageUploadFailedException($"Extension de imagen no valida, " +
                    $"solo se permiten {string.Join(", ", allowedExtensions)}");
            }
        }
    }
}

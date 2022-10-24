using Abp.Extensions;
using Abp.UI;
using MultilingualProject.Net.MimeTypes;
using System;
using SixLabors.ImageSharp;

using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultilingualProject
{
    public static class S3Helper
    {
        public static async Task<string> SaveImageToS3(this byte[] image, string fileName, string folder)
        {

            string[] allowedImageList = { MimeTypeNames.ImageJpeg, MimeTypeNames.ImagePng };

            using var iImage = Image.Load(image, out var format);
            await using var memoryStream = new MemoryStream();
            await iImage.SaveAsync(memoryStream, format);

            using var imageStream = System.Drawing.Image.FromStream(memoryStream);
            var imageMimeType = ImageCodecInfo.GetImageEncoders()?.FirstOrDefault(c => c.FormatID == imageStream.RawFormat.Guid)?.MimeType;

            if (!allowedImageList.Any(c => c.Equals(imageMimeType))) throw new UserFriendlyException("Not supported media type.");

            var filename = fileName.IsNullOrWhiteSpace() ? DateTime.Now.ToString("yyMMddHHmmssff") : fileName;
            
            return "slm";
        }
    }
}

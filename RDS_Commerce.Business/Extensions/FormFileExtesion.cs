using Microsoft.AspNetCore.Http;
using RDS_Commerce.Domain.Entities;

namespace RDS_Commerce.Business.Extensions;
public static class FormFileExtesion
{
    public static FileImage? BuildFileImage(this IFormFile image)
    {
        if (image is null)
            return null;

        return new FileImage
        {
            FileName = image.FileName,
            FileExtension = image.ContentType,
            FileBytes = image.ImageToByte()
        };
    }

    public static PlantImage? BuildPlantFileImage(this IFormFile image)
    {
        if (image is null)
            return null;

        return new PlantImage
        {
            FileName = image.FileName,
            FileExtension = image.ContentType,
            FileBytes = image.ImageToByte()
        };
    }

    public static byte[]? ImageToByte(this IFormFile image)
    {
        var extensionList = new List<string>()
        {
                ".jpeg",
                ".jpg",
                ".png",
                ".pdf",
                ".jfif"
        };

        var imageExtension = Path.GetExtension(image.FileName);

        if (!extensionList.Contains(imageExtension))
            return null;

        using (var stream = new MemoryStream())
        {
            image.CopyTo(stream);

            return stream.ToArray();
        }
    }
}

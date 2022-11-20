using Microsoft.AspNetCore.Http;

namespace RDS_Commerce.Business.Extensions;
public static class FormatExtension
{
    public static string FormatTo(this string message, params object[] args)
    {
        return string.Format(message, args);
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

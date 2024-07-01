namespace CardapioLugano.API.Utils;

public static class FileUtils
{
    public static byte[] GetByteFile(this IFormFile file)
    {
        byte[]? fileBytes = null;

        if(file.Length > 0)
        {
            using var ms = new MemoryStream();
            file.CopyTo(ms);

            fileBytes = ms.ToArray();
        }

        return fileBytes!;
    }

    public static bool ValidateFile(this IFormFile file)
    {
        List<string> mimeTypes = ["image/png", "image/jpg", "image/jpeg"];

        if(file is null or { ContentType : null } )
        {
            return false;
        }

        return mimeTypes.Contains(file.ContentType);
    }
}

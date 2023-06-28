namespace Domain.Helpers;

using Domain.Extensions;
using Domain.Interface.Helper;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

public class AppFileHelper : IAppFileHelper
{
    public string GetFullPath(string appFileId, IConfiguration configuration)
    {
        return Path.Combine(configuration.GetFromEnvironmentVariable("DATA_DIR"), "APP_FILE", appFileId);
    }

    public bool Exists(string filePath)
    {
        return File.Exists(filePath);
    }

    public Stream ReadContent(string filePath)
    {
        Stream output = Stream.Null;

        if (this.Exists(filePath))
        {
            output = new FileStream(path: filePath, mode: FileMode.Open, access: FileAccess.Read);
        }

        return output;
    }

    public byte[] ReadByteContent(string filePath)
    {
        byte[] output = null;

        if (this.Exists(filePath))
        {
            output = File.ReadAllBytes(filePath);
        }

        return output;
    }

    public async Task WriteContent(string directoryPath, string fileName, Stream content, CancellationToken cancellationToken = default)
    {
        await content.FlushAsync(cancellationToken);
        if (!Directory.Exists(directoryPath))
        {
            _ = Directory.CreateDirectory(directoryPath);
        }

        using FileStream fileStream = File.Create(Path.Combine(directoryPath, fileName));
        await content.CopyToAsync(fileStream, cancellationToken);
    }
}

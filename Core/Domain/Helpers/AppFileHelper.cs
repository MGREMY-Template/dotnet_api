namespace Domain.Helpers;

using Domain.Interface.Helper;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

public class AppFileHelper : IAppFileHelper
{
    public Stream ReadContent(string filePath)
    {
        var output = Stream.Null;

        if (File.Exists(filePath))
        {
            output = new FileStream(path: filePath, mode: FileMode.Open, access: FileAccess.Read);
        }

        return output;
    }

    public async Task WriteContent(string directoryPath, string fileName, Stream content, CancellationToken cancellationToken = default)
    {
        await content.FlushAsync(cancellationToken);
        if (!Directory.Exists(directoryPath))
        {
            Directory.CreateDirectory(directoryPath);
        }

        using var fileStream = File.Create(Path.Combine(directoryPath, fileName));
        await content.CopyToAsync(fileStream, cancellationToken);
    }
}

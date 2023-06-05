namespace Domain.Helpers;

using Domain.Interface.Helper;
using System.IO;
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

    public async Task WriteContent(string filePath, Stream content)
    {
        await content.FlushAsync();
        using var fileStream = File.Create(filePath);
        await content.CopyToAsync(fileStream);
    }
}

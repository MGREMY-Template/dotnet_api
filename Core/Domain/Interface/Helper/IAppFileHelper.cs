namespace Domain.Interface.Helper;

using System.IO;
using System.Threading;
using System.Threading.Tasks;

public interface IAppFileHelper
{
    public Stream ReadContent(string filePath);
    public Task WriteContent(string directoryPath, string fileName, Stream content, CancellationToken cancellationToken);
}

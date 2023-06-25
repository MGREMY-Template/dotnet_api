namespace Domain.Interface.Helper;

using Microsoft.Extensions.Configuration;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

public interface IAppFileHelper
{
    public string GetFullPath(string AppFileId, IConfiguration configuration);
    public bool Exists(string filePath);
    public Stream ReadContent(string filePath);
    public byte[] ReadByteContent(string filePath);
    public Task WriteContent(string directoryPath, string fileName, Stream content, CancellationToken cancellationToken);
}

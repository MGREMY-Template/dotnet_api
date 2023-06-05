namespace Domain.Interface.Helper;

using System.IO;
using System.Threading.Tasks;

public interface IAppFileHelper
{
    public Stream ReadContent(string filePath);
    public Task WriteContent(string filePath, Stream content);
}

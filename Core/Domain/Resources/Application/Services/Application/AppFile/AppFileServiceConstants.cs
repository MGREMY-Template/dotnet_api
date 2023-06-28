namespace Domain.Resources.Application.Services.Application.AppFile;

using Domain.Attributes;

[StringLocalizerTarget(typeof(AppFileService))]
public class AppFileServiceConstants
{
    public const string FileIsEmpty = "FileIsEmpty";
    public const string FileNotFound = "FileNotFound";
}

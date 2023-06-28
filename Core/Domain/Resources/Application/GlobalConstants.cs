namespace Domain.Resources.Application;

using Domain.Attributes;

[StringLocalizerTarget(typeof(Global))]
public class GlobalConstants
{
    public const string InternalServerError = "Internal_Server_Error";
    public const string NullValue = "Null_Value";
}

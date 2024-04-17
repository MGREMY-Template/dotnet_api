namespace Domain.Attribute;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
public class ServiceInstallerOrderAttribute(ushort order) : System.Attribute
{
    public ushort Order { get; set; } = order;
}
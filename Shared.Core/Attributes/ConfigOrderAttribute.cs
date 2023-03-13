using System;

namespace Shared.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class ConfigOrderAttribute : Attribute
    {
        private ushort _order;

        public ConfigOrderAttribute(ushort order)
        {
            _order = order;
        }

        public ushort Order
        {
            get => _order;
            set => _order = value;
        }
    }
}

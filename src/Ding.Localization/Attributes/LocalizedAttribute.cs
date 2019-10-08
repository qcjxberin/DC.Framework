using System;

namespace Ding.Localization.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class LocalizedAttribute : Attribute
    {
    }
}

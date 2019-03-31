using System;

namespace Ding.TimedJob.Schema
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class NonJobAttribute : Attribute
    {
    }
}

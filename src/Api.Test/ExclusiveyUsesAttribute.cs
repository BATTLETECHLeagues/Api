using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// ReSharper disable CheckNamespace

namespace NCrunch.Framework
{
    public abstract class ResourceUsageAttribute : Attribute
    {
        protected ResourceUsageAttribute(params string[] resourceName)
        {
            ResourceNames = resourceName;
        }

        public string[] ResourceNames { get; }
    }

    public class ExclusivelyUsesAttribute : ResourceUsageAttribute
    {
        public ExclusivelyUsesAttribute(params string[] resourceName)
            : base(resourceName) { }
    }
}

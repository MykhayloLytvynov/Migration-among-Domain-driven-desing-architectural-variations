using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Domain.Entity
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class IgnoreMemberAttribute : Attribute
    {
    }
}

using Common.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace TechnicalStation.Core.BLL.Extensions
{
    public static class TraceExtensions
    {
        public static string GetFieldValueCollection(this object element, int tabs = 0, bool excludeNulls = true)
        {
            string message = string.Empty;

            foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(element).Sort())
            {
                string name = descriptor.Name;
                object value = descriptor.GetValue(element);

                if (!(value is null))
                {
                    for (int i = 0; i < tabs; i++)
                    {
                        message += "    ";
                    }

                    if (value is ITraceable)
                    {
                        message += string.Format("[{0}] = \r\n{1}\r\n", name, ((ITraceable)value).GetTrace(tabs + 1));
                    }
                    else
                    {
                        message += string.Format("[{0}] = {1} \r\n", name, value);
                    }
                }
            }

            return message;
        }
    }
}

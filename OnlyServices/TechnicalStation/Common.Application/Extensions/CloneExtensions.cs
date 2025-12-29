using System;
using System.Collections;
using System.Reflection;

namespace Common.Application.Extensions
{
    public static class CloneExtensions
    {
        public static object CopyObject(this object input)
        {
            if (input != null)
            {
                object result = Activator.CreateInstance(input.GetType());
                foreach (FieldInfo field in input.GetType().GetFields(BindingFlags.Public | BindingFlags.NonPublic |
                         BindingFlags.Static | BindingFlags.Instance |
                         BindingFlags.DeclaredOnly))
                {
                    if (field.FieldType.GetInterface("IList", false) == null)
                    {
                        field.SetValue(result, field.GetValue(input));
                    }
                    else
                    {
                        IList listObject = (IList)field.GetValue(result);
                        if (listObject != null)
                        {
                            foreach (object item in ((IList)field.GetValue(input)))
                            {
                                listObject.Add(CopyObject(item));
                            }
                        }
                    }
                }
                return result;
            }
            else
            {
                return null;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace Common.Application.Dal.Extensions
{
    public static class DbCommandExtensionMethods
    {
        public static void AddParameter(this IDbCommand command, string name, object value, ParameterDirection parameterDirection = ParameterDirection.Input)
        {
            var parameter = command.CreateParameter();
            parameter.ParameterName = name;
            parameter.Value = value;
            parameter.Direction = parameterDirection;
            command.Parameters.Add(parameter);
        }

        public static IEnumerable<T> Select<T>(this DbDataReader reader, Func<DbDataReader, T> projection)
        {

            while (reader.Read())
            {
                yield return projection(reader);
            }
        }
    }
}

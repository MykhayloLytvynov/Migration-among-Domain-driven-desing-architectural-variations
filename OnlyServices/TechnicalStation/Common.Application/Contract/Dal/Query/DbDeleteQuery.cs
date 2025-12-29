using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Application.Contract.Dal.Query
{
    public class DbDeleteQuery
    {
        private string from;

        private List<DbQueryCondition> conditionCollection;

        public DbDeleteQuery(string from)
        {
            this.from = from;
        }

        public DbDeleteQuery(string from, List<DbQueryCondition> conditionCollection)
        {
            this.from = from;
            this.conditionCollection = conditionCollection;
        }

        public string From => from;

        public List<DbQueryCondition> ConditionCollection => conditionCollection;
    }
}

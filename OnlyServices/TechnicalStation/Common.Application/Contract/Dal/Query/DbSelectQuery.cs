namespace Common.Application.Contract.Dal.Query
{
    using System.Collections.Generic;

    public class DbSelectQuery
    {
        private int top;

        private List<string> fieldCollection;

        private List<string> fromCollection;

        private List<DbQueryCondition> conditionCollection = new List<DbQueryCondition>();

        public DbSelectQuery(string from, int top = 0)
        {
            fromCollection = new List<string>() { from };
            this.top = top;
        }



        public DbSelectQuery(List<string> fromCollection)
        {
            this.fromCollection = fromCollection;
        }

        public DbSelectQuery(List<string> fromCollection, List<string> fieldCollection, List<DbQueryCondition> conditionCollection)
        {
            this.fieldCollection = fieldCollection;
            this.fromCollection = fromCollection;
            this.conditionCollection = conditionCollection;
        }

        public List<string> FieldCollection => fieldCollection;

        public List<string> FromCollection => fromCollection;

        public List<DbQueryCondition> ConditionCollection => conditionCollection;

        public int Top => top;
    }
}

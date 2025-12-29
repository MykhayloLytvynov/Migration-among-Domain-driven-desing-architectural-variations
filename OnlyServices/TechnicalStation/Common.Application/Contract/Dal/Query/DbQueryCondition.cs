namespace Common.Application.Contract.Dal.Query
{
    public class DbQueryCondition
    {
        private string tableName;

        private string fieldName;

        private string relation;

        private string value;

        private bool and;

        public DbQueryCondition(string tableName, string fieldName, string relation, string value, bool and)
        {
            this.tableName = tableName;
            this.fieldName = fieldName;
            this.relation = relation;
            this.value = value;
            this.and = and;
        }

        public string TableName => tableName;

        public string FieldName => fieldName;

        public string Relation => relation;

        public string Value => value;

        public bool And => and;
    }
}

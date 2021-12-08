using System.Data.SqlClient;

namespace NuzlockeHelper
{
    public class SaveController
    {
        private static string _datasource { get; set; } /*@"(localdb)\MSSQLLocalDB"*/
        private static string _database { get; set; } /*SQLEXPRESS*/
        private string _username { get; set; }
        private string _password { get; set; }

        public SaveController(string datasource, string database)
        {
            _datasource = datasource;
            _database = database;
        }

        private static string connString = $@"Data Source={_datasource};Initial Catalog=SQLEXPRESS;Integrated Security=True";

        public SqlConnection conn = new(connString);
    }
}

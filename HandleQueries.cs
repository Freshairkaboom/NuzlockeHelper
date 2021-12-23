using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dapper;

namespace NuzlockeHelper
{
    class HandleQueries
    {
        public static async Task TestQueries()
        {
            string connString = @"Data Source=(localdb)\MSSQLLocalDB;
                                  Initial Catalog=LarsTest;
                                  Integrated Security=True;";

            SqlConnection conn = new(connString);

            string constructTable = @"CREATE TABLE [dbo].[Noob](
                                    [Id] [int] NOT NULL,
                                    [FirstName] [nvarchar](max) NULL,
                                    [LastName] [nvarchar](max) NULL,
                                    [BirthYear] [int] NULL)";

            string deleteTable = @"DROP TABLE [dbo].[Noob]";

            string create = @"INSERT INTO Noob (Id, FirstName, LastName, BirthYear) " +
                            "VALUES (@Id, @FirstName, @LastName, @BirthYear)";

            string readOne = @"SELECT Id, FirstName, LastName, BirthYear
                               FROM Noob
                               WHERE Id = @Id";

            string readId = @"SELECT Id
                              FROM Noob
                              WHERE Id = @Id";

            string update = @"UPDATE Noob
                              SET LastName = @LastName, FirstName = @FirstName
                              WHERE Id = @Id";

            conn.Open();

            if (conn.Database.Length != 0)
            {
                await conn.QueryAsync(deleteTable);
            };

            await conn.QueryAsync(constructTable);

            int rowsInserted = await conn.ExecuteAsync(create, new
            {
                Id = 1,
                FirstName = "Lars",
                LastName = "Strand",
                BirthYear = 1994
            });
            //string person1 = await conn.QueryFirstOrDefaultAsync(readId, new { Id = 1 });
            var person2 = await conn.QueryFirstAsync(readOne, new {Id = 1});

            conn.Close();

            Console.WriteLine(rowsInserted);
            Console.WriteLine(person2.FirstName);
        }
    }
}

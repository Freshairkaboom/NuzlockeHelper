using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using Dapper;
#pragma warning disable 4014

namespace NuzlockeHelper
{
    public class StoreData
    {
        /*New instance of CommandList should be replaced with actual data from initialized list in CloseRoute class.*/
        private SqlConnection conn { get; set; }

        private Routes Routes;

        private Rules Rules;

        private Stages Stages;

        public StoreData(string connString)
        {
            
            conn = new(connString);

        }

        public async Task SaveRoutes(Routes routes)
        {
            string updateRoutes = @"Update [dbo].[Routes]
                                    SET IsClosed = @IsClosed
                                    WHERE RouteNumber = @RouteNumber";

            for (int i = 0; i < routes.allRoutes.Length; i++)
            {
                await conn.ExecuteAsync(updateRoutes, new
                {
                    routes.allRoutes[i].RouteNumber,
                    routes.allRoutes[i].IsClosed
                });

                Console.WriteLine("Route "+ routes.allRoutes[i].RouteNumber + " overwritten.");
            }
        }

        public async Task InitialSaveRoutes(Routes routes)
        {
            string saveRoutesFirstTime = @"INSERT INTO [dbo].[Routes] (RouteNumber, IsClosed) 
                                       VALUES(@RouteNumber, @IsClosed)";

            for (int i = 0; i < routes.allRoutes.Length; i++)
            {
                await conn.ExecuteAsync(saveRoutesFirstTime, new
                {
                    routes.allRoutes[i].RouteNumber,
                    routes.allRoutes[i].IsClosed
                });

                Console.WriteLine("Route " + routes.allRoutes[i].RouteNumber + " saved.");
            }
        }

        public async Task CheckIfNoRoutesStored(Routes routes)
        {
            string countRoutes = @"SELECT COUNT (RouteNumber)
                                   FROM [dbo].[Routes]";

            var routesCount = await conn.ExecuteScalarAsync<int>(countRoutes);

            //var rowCount = RetrieveRowCount(routesCount);

            if (routesCount > 0)
            {
                Console.WriteLine("Save Game");
                await SaveRoutes(routes);
            }

            else
            {
                Console.WriteLine("Initial game save");
                await InitialSaveRoutes(routes);
            }
        }

        public async Task CheckIfNoRulesStored(List<string> rules)
        {
            string countRules = @"SELECT COUNT (RuleDescription)
                                   FROM [dbo].[Rules]";

            var rulesCount = await conn.ExecuteScalarAsync<int>(countRules);

            //var rowCount = RetrieveRowCount(routesCount);

            if (rulesCount > 0)
            {
                Console.WriteLine("Save Game");
                
            }

            else
            {
                Console.WriteLine("Initial game save");
            }
        }

        public async Task CheckIfNoStagesStored(Routes routes)
        {
            string countStages = @"SELECT COUNT (CurrentStage)
                                   FROM [dbo].[Stages]";

            var stagesCount = await conn.ExecuteScalarAsync<int>(countStages);

            //var rowCount = RetrieveRowCount(routesCount);

            if (stagesCount > 0)
            {
                Console.WriteLine("Save Game");
            }

            else
            {
                Console.WriteLine("Initial game save");
            }
        }
    }
}

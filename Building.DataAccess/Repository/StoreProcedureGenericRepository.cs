using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Building.DataAccess.Data;
using Building.DataAccess.Repository.IRepository;
using Dapper;
using Microsoft.EntityFrameworkCore;

namespace Building.DataAccess.Repository
{
    public class StoreProcedureGenericRepository : IStoreProcedureGenericRepository
    {
        private readonly ApplicationDbContext _db;

        public StoreProcedureGenericRepository(ApplicationDbContext db)
        {
            _db = db;
        }


        public async Task<IEnumerable<T>> ExecuteStoredProcedure<T>(string storedProcedureName, params object[] parameters) where T : class
        {
            try
            {
                var connection = _db.Database.GetDbConnection();
                if (connection.State == ConnectionState.Closed)
                {
                    await connection.OpenAsync(); // Ensure the connection is open
                }

                // If no parameters are passed, pass null instead of an empty array
                if (parameters == null || parameters.Length == 0)
                {
                    return await connection.QueryAsync<T>(
                        storedProcedureName,
                        commandType: CommandType.StoredProcedure
                    );
                }
                else
                {
                    return await connection.QueryAsync<T>(
                        storedProcedureName,
                        parameters,
                        commandType: CommandType.StoredProcedure
                    );
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error executing stored procedure '{storedProcedureName}': {ex.Message}", ex);
            }
        }
    }
}

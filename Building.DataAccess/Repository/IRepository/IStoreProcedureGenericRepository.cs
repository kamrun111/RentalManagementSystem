using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Building.DataAccess.Repository.IRepository
{
    public interface IStoreProcedureGenericRepository
    {
        // Execute stored procedure with parameters and return a list of T
        Task<IEnumerable<T>> ExecuteStoredProcedure<T>(string storedProcedure, params object[] parameters) where T : class;

    }
}

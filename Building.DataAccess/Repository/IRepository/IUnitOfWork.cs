using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Building.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IFloorRepository Floor{ get; }
        IFlatRepository Flat { get; }
        IFlatTypeRepository FlatType { get; }
        ILocationRepository Location { get; }
        ITenantRepository Tenant { get; }
        IStatusRepository Status { get; }
        IExpenditureRepository Expenditure { get; }
        IExpenditureDetailRepository ExpenditureDetail { get; }
        IExpenseRepository Expense { get; }

        IStoreProcedureGenericRepository StoreProcedure { get; }


        void Save();
        Task SaveAsync();
    }
}

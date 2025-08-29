using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Building.DataAccess.Data;
using Building.DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Building.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;
        public IFloorRepository Floor { get; private set; }
        public IFlatRepository Flat { get; private set; }
        public IFlatTypeRepository FlatType { get; private set; }
        public ILocationRepository Location { get; private set; }
        public ITenantRepository Tenant { get; private set; }
        public IStatusRepository Status { get; private set; }
        public IExpenditureRepository Expenditure { get; private set; }
        public IExpenditureDetailRepository ExpenditureDetail { get; private set; }
        public IExpenseRepository Expense { get; private set; }
        public IMonthEntryRepository MonthEntry { get; private set; }

        // Store procedure repository
        public IStoreProcedureGenericRepository StoreProcedure { get; private set; }
        public ITypeIdentifiereRepository TypeIdentifier { get; private set; }
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Floor = new FloorRepository(_db);
            Flat = new FlatRepository(_db);
            FlatType = new FlatTypeRepository(_db);
            Location = new LocationRepository(_db);
            Tenant = new TenantRepository(_db);
            Status = new StatusRepository(_db);
            Expenditure = new ExpenditureRepository(_db);
            ExpenditureDetail = new ExpenditureDetailRepository(_db);
            Expense = new ExpenseRepository(_db);
            MonthEntry = new MonthEntryRepository(_db);
            StoreProcedure = new StoreProcedureGenericRepository(_db);
            TypeIdentifier = new TypeIdentifiereRepository(_db);
        }


        public void Save()
        {
            _db.SaveChanges();
        }
        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}

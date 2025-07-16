using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Building.DataAccess.Data;
using Building.DataAccess.Repository.IRepository;
using Building.Models;

namespace Building.DataAccess.Repository
{
    public class ExpenseRepository : Repository<Expense>, IExpenseRepository
    {

        private ApplicationDbContext _db;
        public ExpenseRepository( ApplicationDbContext db): base(db) 
        {
            _db= db;
        }


        public void Update(Expense obj)
        {
            _db.Expenses.Update(obj);



        }
    }
}

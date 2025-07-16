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
    public class ExpenditureRepository : Repository<Expenditure>, IExpenditureRepository
    {

        private ApplicationDbContext _db;
        public ExpenditureRepository( ApplicationDbContext db): base(db) 
        {
            _db= db;
        }


        public void Update(Expenditure obj)
        {
            _db.Expenditures.Update(obj);



        }
    }
}

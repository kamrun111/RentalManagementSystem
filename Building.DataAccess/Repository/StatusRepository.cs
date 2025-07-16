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
    public class StatusRepository : Repository<Status>, IStatusRepository
    {

        private ApplicationDbContext _db;
        public StatusRepository( ApplicationDbContext db): base(db) 
        {
            _db= db;
        }


        public void Update(Status obj)
        {
            _db.Statuses.Update(obj);



        }
    }
}

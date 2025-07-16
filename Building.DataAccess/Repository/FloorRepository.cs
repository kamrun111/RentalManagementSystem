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
    public class FloorRepository : Repository<Floor>, IFloorRepository
    {

        private ApplicationDbContext _db;
        public FloorRepository( ApplicationDbContext db): base(db) 
        {
            _db= db;
        }
        //public void Save()
        //{
        //    _db.SaveChanges();
        //}

        public void Update(Floor item)
        {
            _db.Floors.Update(item);
        }
    }
}

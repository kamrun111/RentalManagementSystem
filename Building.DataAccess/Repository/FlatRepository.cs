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
    public class FlatRepository : Repository<Flat>, IFlatRepository
    {

        private ApplicationDbContext _db;
        public FlatRepository( ApplicationDbContext db): base(db) 
        {
            _db= db;
        }


        public void Update(Flat obj)
        {
            //_db.Flats.Update(item);
            var objfromDb = _db.Flats.FirstOrDefault(u => u.FlatId == obj.FlatId);
            if (objfromDb != null)
            {
                objfromDb.FlatName = obj.FlatName;
                objfromDb.FlatSize = obj.FlatSize;
                objfromDb.FlatRent = obj.FlatRent;
                objfromDb.FloorId = obj.FloorId;
                objfromDb.FlatTypeId = obj.FlatTypeId;


            }


        }
    }
}

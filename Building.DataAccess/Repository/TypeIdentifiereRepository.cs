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
    public class TypeIdentifiereRepository : Repository<TypeIdentifier>, ITypeIdentifiereRepository
    {

        private ApplicationDbContext _db;
        public TypeIdentifiereRepository( ApplicationDbContext db): base(db) 
        {
            _db= db;
        }


        public void Update(TypeIdentifier obj)
        {
            _db.TypeIdentifiers.Update(obj);



        }
    }
}

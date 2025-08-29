using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Building.Models;

namespace Building.DataAccess.Repository.IRepository
{
    public interface ITypeIdentifiereRepository : IRepository<TypeIdentifier>
    {
        void Update(TypeIdentifier item);
    }
}

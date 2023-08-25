using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using BulkyBookWeb.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.DataAccess.Repository
{
    public class CoverTypeRepository : Repository<CoverType>, ICoverTypeRepository
    {
        private AppDbContext _db;

        public CoverTypeRepository(AppDbContext db): base(db)
        {
            _db= db;
        }

        public void update(CoverType obj)
        {
             _db.CoverTypes.Update(obj);   
        }
    }
}

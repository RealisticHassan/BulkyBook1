using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using BulkyBookWeb.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.DataAccess.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private AppDbContext _db;

        public ProductRepository(AppDbContext db): base(db)
        {
            _db= db;
        }

        public void update(Product obj)
        {
            //  _db.CoverTypes.Update(obj);   

            var dbObj = _db.Products.FirstOrDefault(x => x.Id == obj.Id);
            if (dbObj != null) {

                dbObj.Title = obj.Title;
                dbObj.Author = obj.Author;
                dbObj.ISBN = obj.ISBN;
                dbObj.Description = obj.Description;    
                dbObj.Price = obj.Price;    
                dbObj.Price50 = obj.Price50;    
                dbObj.Price100 = obj.Price100;
                dbObj.CategoryId= obj.CategoryId;   
                dbObj.CoverTypeId= obj.CoverTypeId; 
                if(obj.ImageUrl != null)
                {

                    dbObj.ImageUrl = obj.ImageUrl;
                }

            

            }


        }
    }
}

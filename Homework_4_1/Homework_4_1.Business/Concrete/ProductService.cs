using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Homework_4_1.Business.Abstract;
using Homework_4_1.DataAccess;
using Homework_4_1.Entities.Concrete;

namespace Homework_4_1.Business.Concrete
{
    public class ProductService : IService<Product>
    {
        private MainDbContext mainDbContext;

        public ProductService(MainDbContext dbSetProduct)
        {
            this.mainDbContext = dbSetProduct;
        }
        public Task<IEnumerable<Product>> GetList()
        {
          var result =  mainDbContext.DbSetProduct.Get(product => true);
          return Task.FromResult(result);
        }

        Task<Product> IService<Product>.Add(Product product)
        {
           var result = mainDbContext.DbSetProduct.Add(product);
           return Task.FromResult(result);
        }


        public Task<IEnumerable<Product>> Get(Expression<Func<Product, bool>> filter)
        {
            var result = mainDbContext.DbSetProduct.GetList(filter);
            return Task.FromResult(result);
        }

        Task<bool> IService<Product>.Delete(Expression<Func<Product, bool>> filter)
        {
            var product = mainDbContext.DbSetProduct.Get(filter).ToList().FirstOrDefault();
            if (product == null)
            {
                return Task.FromResult(false);
            }

           var result = mainDbContext.DbSetProduct.Delete(product);
           return Task.FromResult(result);
        }

       
    }
}

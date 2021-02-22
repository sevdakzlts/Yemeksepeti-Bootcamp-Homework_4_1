using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Text.Json;
using Homework_4_1.Entities.Concrete;

namespace Homework_4_1.DataAccess

{
    public class DbSetProduct : IDbSet<Product> // product repository
    {
        protected List<Product> _objecList;
        protected MainDbContext.DbSetConfig _config;

        public DbSetProduct(MainDbContext.DbSetConfig config)
        {
            _config = config;
            Deserialize();
        }

        ~DbSetProduct()
        {
            Serialize();
        }


        public void Deserialize()
        {
            try
            {
                using (StreamReader file = File.OpenText(_config.JsonPath))
                {
                    _objecList = (List<Product>)JsonSerializer
                        .Deserialize(file.ReadToEnd(), typeof(List<Product>));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
               _objecList = new List<Product>();
            }
        }

        public bool Serialize ()
        {
            try
            {
                File.WriteAllText(_config.JsonPath, 
                    JsonSerializer.Serialize(_objecList));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return true;
        }
        public Product Add(Product entity)
        {
            ObjecList.OrderBy(e => e.Id);
            var newId = ObjecList.Last().Id;
            entity.Id = newId + 1;
            _objecList.Add(entity);
            Serialize();
            return entity;
        }
        public bool Delete(Product entity)
        {
           return _objecList.Remove(entity);
        }

        public List<Product> ObjecList
        {
            get => _objecList;
            set => _objecList = value;
        }

        public IEnumerable<Product> GetList(Expression<Func<Product, bool>> filter = null, bool eagerLoad = false)
        {
            return _objecList.Where(filter.Compile());
            throw new NotImplementedException();
        }

        public IEnumerable<Product> Get(Expression<Func<Product, bool>> filter, bool eagerLoad = false)
        {
            return _objecList.Where(filter.Compile());
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Homework_4_1.DataAccess;
using Homework_4_1.Entities.Concrete;

namespace Homework_4_1.DataAccess
{
    public class MainDbContext
    {
        public readonly DbSetProduct DbSetProduct;
      
        public MainDbContext(Contextconfig contextconfig)
        {
            foreach (var config in contextconfig.configs)
            {
                if (config.type == typeof(Product))
                {
                    //List<Product> products = JsonSerializer.Deserialize<List<Product>>(config.JsonPath);
                    // read json file from FileStreamReader(config.JsonPath);
                    DbSetProduct = new DbSetProduct(config); 
                    //DbSetProduct = new DbSetProduct();
                }
            }
        }

        public class DbSetConfig
        {
            public DbSetConfig(Type type, string jsonPath)
            {
                this.type = type;
                JsonPath = jsonPath;
            }
            public Type type;
            public string JsonPath;
        }
        public class Contextconfig
        {
            public List<DbSetConfig> configs;

            public Contextconfig()
            {
                configs = new List<DbSetConfig>();
            }
            public void AddConfig(DbSetConfig config)
            {
                configs.Add(config);
            }
        }
    }
}

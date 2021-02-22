using System;
using System.Collections.Generic;
using System.Text;

namespace Homework_4_1.Entities.Concrete
{
    public class Product 
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Homework_4_1.Entities.Concrete;

namespace Homework_4_1.DataAccess
{
    public interface IDbSet<T> where T : class, new()
    {
        List<T> ObjecList { get; }
        IEnumerable<Product> GetList(Expression<Func<T, bool>> filter = null, bool eagerLoad = false);

        //PaginatedObject<T> GetPaginated(string searchText, int startIndex, int length, Expression<Func<T, bool>> filter = null, bool eagerLoad = false);
        
        IEnumerable<Product> Get(Expression<Func<T, bool>> filter, bool eagerLoad = false);

        T Add(T entity);


        void Deserialize();

        bool Serialize();
        
        bool Delete(T entity);

    }
}

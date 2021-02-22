using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Homework_4_1.Entities.Concrete;

namespace Homework_4_1.Business.Abstract
{
    public interface IService<T> where T : class, new()
    {
        Task<IEnumerable<T>> GetList();
        Task<T> Add(T product);
        Task<IEnumerable<T>> Get(Expression<Func<T, bool>> filter);
        Task<bool> Delete(Expression<Func<T, bool>> filter);

    }
}

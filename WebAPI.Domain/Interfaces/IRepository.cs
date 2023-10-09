using System.Linq.Expressions;
using WebAPI.Domain.Model;

namespace WebAPI.Domain.Interfaces
{
    public interface IRepository<T> where T : Entity
    {
        int Create(T entity);
        T FindById(int id);
        List<T> FindAll();
        void Update(T entity);
        void Delete(int id);
        
    }
}

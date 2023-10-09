using WebAPI.Domain.Model;

namespace WebAPI.Domain.Interfaces
{
    public interface IExemploRepository : IRepository<Exemplo>, IDisposable
    {
    }
}

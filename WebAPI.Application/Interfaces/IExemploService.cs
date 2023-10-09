using WebAPI.Application.ViewModel;

namespace WebAPI.Application.Interfaces
{
    public interface IExemploService
    {
        List<ExemploViewModel> GetExemplos(); 
        ExemploViewModel GetExemploById(int id);
        void Create(ExemploViewModel exemplo);
        void Update(ExemploViewModel exemplo);
        void Delete(int id);    
    }
}

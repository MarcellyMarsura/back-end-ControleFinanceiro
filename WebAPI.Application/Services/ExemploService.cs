using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Application.Interfaces;
using WebAPI.Application.ViewModel;
using WebAPI.Domain.Interfaces;
using WebAPI.Domain.Model;

namespace WebAPI.Application.Services
{
    public class ExemploService : IExemploService
    {
        private readonly IExemploRepository _exemploRepository;
        private readonly IMapper _mapper;

        public ExemploService(IExemploRepository exemploRepository, IMapper mapper)
        {
            _exemploRepository = exemploRepository;
            _mapper = mapper;
        }

        public void Create(ExemploViewModel exemplo)
        {
            _exemploRepository.Create(_mapper.Map<ExemploViewModel, Exemplo>(exemplo));
        }

        public void Delete(int id)
        {
            if (GetExemploById(id) == null)
                throw new Exception("Exemplo não encontrado");

            _exemploRepository.Delete(id);
        }

        public ExemploViewModel GetExemploById(int id)
        {
            return _mapper.Map<Exemplo, ExemploViewModel>(_exemploRepository.FindById(id));
        }

        public List<ExemploViewModel> GetExemplos()
        {
            return _mapper.Map<List<Exemplo>, List<ExemploViewModel>>(_exemploRepository.FindAll());
        }

        public void Update(ExemploViewModel exemplo)
        {
            if (exemplo == null || GetExemploById(exemplo.Id) == null)
                throw new Exception("Exemplo não encontrado");

            var exemploExistente = GetExemploById(exemplo.Id);

            exemploExistente.Descricao = exemplo.Descricao;

            var exemploAtualizado = _mapper.Map<ExemploViewModel, Exemplo>(exemplo);
            _exemploRepository.Update(exemploAtualizado);
        }
    }
}

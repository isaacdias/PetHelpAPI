using PetHelpAPI.InputModel;
using PetHelpAPI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetHelpAPI.Services
{
    public interface IAbrigoService : IDisposable
    {
        Task<List<AbrigoViewModel>> Obter(int pagina, int quantidade);
        Task<AbrigoViewModel> Obter(Guid id);
        Task<AbrigoViewModel> Inserir(AbrigoInputModel abrigo);
        Task Atualizar(Guid id, AbrigoInputModel abrigo);
        Task Remover(Guid id);
    }
}

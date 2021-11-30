using PetHelpAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetHelpAPI.Repositories
{
    public interface IAbrigoRepository : IDisposable
    {
        Task<List<Abrigo>> Obter(int pagina, int quantidade);
        Task<Abrigo> Obter(Guid id);
        Task<List<Abrigo>> Obter(string nome, string produtora);
        Task Inserir(Abrigo abrigo);
        Task Atualizar(Abrigo abrigo);
        Task Remover(Guid id);
    }
}

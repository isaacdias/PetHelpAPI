using PetHelpAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetHelpAPI.Repositories
{
    public class AbrigoRepository : IAbrigoRepository
    {
        private static Dictionary<Guid, Abrigo> abrigos = new Dictionary<Guid, Abrigo>()
        {
            {Guid.Parse("0ca314a5-9282-45d8-92c3-2985f2a9fd04"), new Abrigo{ Id = Guid.Parse("0ca314a5-9282-45d8-92c3-2985f2a9fd04"), Nome = "Lar Feliz", Endereco = "Rua 01", Numero = "200", Bairro = "BV", Cidade = "Recife", Estado = "Pernambuco", Telefone = "33259089", AceitaCachorro = true, AceitaGato = true} },
            {Guid.Parse("eb909ced-1862-4789-8641-1bba36c23db3"), new Abrigo{ Id = Guid.Parse("eb909ced-1862-4789-8641-1bba36c23db3"), Nome = "Lar dos Pets", Endereco = "Rua 02", Numero = "20", Bairro = "Ipsep", Cidade = "Recife", Estado = "Pernambuco", Telefone = "33660990", AceitaCachorro = true, AceitaGato = false} },
            {Guid.Parse("5e99c84a-108b-4dfa-ab7e-d8c55957a7ec"), new Abrigo{ Id = Guid.Parse("5e99c84a-108b-4dfa-ab7e-d8c55957a7ec"), Nome = "Pet feliz", Endereco = "Rua 03", Numero = "50", Bairro = "Pina", Cidade = "Recife", Estado = "Pernambuco", Telefone = "33259089", AceitaCachorro = false, AceitaGato = true} },
            {Guid.Parse("da033439-f352-4539-879f-515759312d53"), new Abrigo{ Id = Guid.Parse("da033439-f352-4539-879f-515759312d53"), Nome = "Meu pet", Endereco = "Rua 04", Numero = "S/N", Bairro = "Ibura", Cidade = "Recife", Estado = "Pernambuco", Telefone = "33259089", AceitaCachorro = true, AceitaGato = true} },
            {Guid.Parse("92576bd2-388e-4f5d-96c1-8bfda6c5a268"), new Abrigo{ Id = Guid.Parse("92576bd2-388e-4f5d-96c1-8bfda6c5a268"), Nome = "Dog House", Endereco = "Rua 05", Numero = "73", Bairro = "Varzea", Cidade = "Recife", Estado = "Pernambuco", Telefone = "33259089", AceitaCachorro = true, AceitaGato = true} },
            {Guid.Parse("c3c9b5da-6a45-4de1-b28b-491cbf83b589"), new Abrigo{ Id = Guid.Parse("c3c9b5da-6a45-4de1-b28b-491cbf83b589"), Nome = "Intituto Pet", Endereco = "Rua 06", Numero = "15", Bairro = "Imbiribeira", Cidade = "Recife", Estado = "Pernambuco", Telefone = "33259089", AceitaCachorro = true, AceitaGato = true} },
        };

        public Task<List<Abrigo>> Obter(int pagina, int quantidade)
        {
            return Task.FromResult(abrigos.Values.Skip((pagina - 1) * quantidade).Take(quantidade).ToList());
        }

        public Task<Abrigo> Obter(Guid id)
        {
            if (!abrigos.ContainsKey(id))
                return Task.FromResult<Abrigo>(null);

            return Task.FromResult(abrigos[id]);
        }

        public Task<List<Abrigo>> Obter(string nome, string endereco)
        {
            return Task.FromResult(abrigos.Values.Where(abrigo => abrigo.Nome.Equals(nome) && abrigo.Endereco.Equals(endereco)).ToList());
        }

        public Task<List<Abrigo>> ObterSemLambda(string nome, string endereco)
        {
            var retorno = new List<Abrigo>();

            foreach (var abrigo in abrigos.Values)
            {
                if (abrigo.Nome.Equals(nome) && abrigo.Endereco.Equals(endereco))
                    retorno.Add(abrigo);
            }

            return Task.FromResult(retorno);
        }

        public Task Inserir(Abrigo abrigo)
        {
            abrigos.Add(abrigo.Id, abrigo);
            return Task.CompletedTask;
        }

        public Task Atualizar(Abrigo abrigo)
        {
            abrigos[abrigo.Id] = abrigo;
            return Task.CompletedTask;
        }

        public Task Remover(Guid id)
        {
            abrigos.Remove(id);
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            //Fechar conexão com o banco
        }
    }
}

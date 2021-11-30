using PetHelpAPI.Entities;
using PetHelpAPI.Exceptions;
using PetHelpAPI.InputModel;
using PetHelpAPI.Repositories;
using PetHelpAPI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetHelpAPI.Services
{
    public class AbrigoService : IAbrigoService
    {
        private readonly IAbrigoRepository _abrigoRepository;

        public AbrigoService(IAbrigoRepository abrigoRepository)
        {
            _abrigoRepository = abrigoRepository;
        }

        public async Task<List<AbrigoViewModel>> Obter(int pagina, int quantidade)
        {
            var abrigo = await _abrigoRepository.Obter(pagina, quantidade);

            return abrigo.Select(abrigo => new AbrigoViewModel
            {
                Id = abrigo.Id,
                Nome = abrigo.Nome,
                Endereco = abrigo.Endereco,
                Numero = abrigo.Numero,
                Bairro = abrigo.Bairro,
                Cidade = abrigo.Cidade,
                Estado = abrigo.Estado,
                Telefone = abrigo.Telefone,
                AceitaCachorro = abrigo.AceitaCachorro,
                AceitaGato = abrigo.AceitaGato
            })
            .ToList();
        }

        public async Task<AbrigoViewModel> Obter(Guid id)
        {
            var abrigo = await _abrigoRepository.Obter(id);

            if (abrigo == null)
                return null;

            return new AbrigoViewModel
            {
                Id = abrigo.Id,
                Nome = abrigo.Nome,
                Endereco = abrigo.Endereco,
                Numero = abrigo.Numero,
                Bairro = abrigo.Bairro,
                Cidade = abrigo.Cidade,
                Estado = abrigo.Estado,
                Telefone = abrigo.Telefone,
                AceitaCachorro = abrigo.AceitaCachorro,
                AceitaGato = abrigo.AceitaGato
            };
        }

        public async Task<AbrigoViewModel> Inserir(AbrigoInputModel abrigo)
        {
            var entidadeAbrigo = await _abrigoRepository.Obter(abrigo.Nome, abrigo.Endereco);

            if (entidadeAbrigo.Count > 0)
                throw new AbrigoJaCadastradoException();

            var abrigoInsert = new Abrigo
            {
                Id = Guid.NewGuid(),
                Nome = abrigo.Nome,
                Endereco = abrigo.Endereco,
                Numero = abrigo.Numero,
                Bairro = abrigo.Bairro,
                Cidade = abrigo.Cidade,
                Estado = abrigo.Estado,
                Telefone = abrigo.Telefone,
                AceitaCachorro = abrigo.AceitaCachorro,
                AceitaGato = abrigo.AceitaGato
            };

            await _abrigoRepository.Inserir(abrigoInsert);

            return new AbrigoViewModel
            {
                Id = abrigoInsert.Id,
                Nome = abrigo.Nome,
                Endereco = abrigo.Endereco,
                Numero = abrigo.Numero,
                Bairro = abrigo.Bairro,
                Cidade = abrigo.Cidade,
                Estado = abrigo.Estado,
                Telefone = abrigo.Telefone,
                AceitaCachorro = abrigo.AceitaCachorro,
                AceitaGato = abrigo.AceitaGato
            };
        }

        public async Task Atualizar(Guid id, AbrigoInputModel abrigo)
        {
            var entidadeAbrigo = await _abrigoRepository.Obter(id);

            if (entidadeAbrigo == null)
                throw new AbrigoNaoCadastradoException();

            entidadeAbrigo.Nome = abrigo.Nome;
            entidadeAbrigo.Endereco = abrigo.Endereco;
            entidadeAbrigo.Numero = abrigo.Numero;
            entidadeAbrigo.Bairro = abrigo.Bairro;
            entidadeAbrigo.Cidade = abrigo.Cidade;
            entidadeAbrigo.Estado = abrigo.Estado;
            entidadeAbrigo.Telefone = abrigo.Telefone;
            entidadeAbrigo.AceitaCachorro = abrigo.AceitaCachorro;
            entidadeAbrigo.AceitaGato = abrigo.AceitaGato;

            await _abrigoRepository.Atualizar(entidadeAbrigo);
        }

        public async Task Remover(Guid id)
        {
            var abrigo = await _abrigoRepository.Obter(id);

            if (abrigo == null)
                throw new AbrigoNaoCadastradoException();

            await _abrigoRepository.Remover(id);
        }

        public void Dispose()
        {
            _abrigoRepository?.Dispose();
        }
    }
}

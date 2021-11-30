using Microsoft.Extensions.Configuration;
using PetHelpAPI.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace PetHelpAPI.Repositories
{
    public class AbrigoSqlServerRepository : IAbrigoRepository
    {
        private readonly SqlConnection sqlConnection;

        public AbrigoSqlServerRepository(IConfiguration configuration)
        {
            sqlConnection = new SqlConnection(configuration.GetConnectionString("Default"));
        }

        public async Task<List<Abrigo>> Obter(int pagina, int quantidade)
        {
            var abrigos = new List<Abrigo>();

            var comando = $"select * from Abrigos order by id offset {((pagina - 1) * quantidade)} rows fetch next {quantidade} rows only";

            await sqlConnection.OpenAsync();
            SqlCommand sqlCommand = new SqlCommand(comando, sqlConnection);
            SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync();

            while (sqlDataReader.Read())
            {
                abrigos.Add(new Abrigo
                {
                    Id = (Guid)sqlDataReader["Id"],
                    Nome = (string)sqlDataReader["Nome"],
                    Endereco = (string)sqlDataReader["Endereco"],
                    Numero = (string)sqlDataReader["Numero"],
                    Bairro = (string)sqlDataReader["Bairro"],
                    Cidade = (string)sqlDataReader["Cidade"],
                    Estado = (string)sqlDataReader["Estado"],
                    Telefone = (string)sqlDataReader["Telefone"],
                    AceitaCachorro = (bool)sqlDataReader["AceitaCachorro"],
                    AceitaGato = (bool)sqlDataReader["AceitaGato"]
                });
            }

            await sqlConnection.CloseAsync();

            return abrigos;
        }

        public async Task<Abrigo> Obter(Guid id)
        {
            Abrigo abrigo = null;

            var comando = $"select * from Abrigos where Id = '{id}'";

            await sqlConnection.OpenAsync();
            SqlCommand sqlCommand = new SqlCommand(comando, sqlConnection);
            SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync();

            while (sqlDataReader.Read())
            {
                abrigo = new Abrigo
                {
                    Id = (Guid)sqlDataReader["Id"],
                    Nome = (string)sqlDataReader["Nome"],
                    Endereco = (string)sqlDataReader["Endereco"],
                    Numero = (string)sqlDataReader["Numero"],
                    Bairro = (string)sqlDataReader["Bairro"],
                    Cidade = (string)sqlDataReader["Cidade"],
                    Estado = (string)sqlDataReader["Estado"],
                    Telefone = (string)sqlDataReader["Telefone"],
                    AceitaCachorro = (bool)sqlDataReader["AceitaCachorro"],
                    AceitaGato = (bool)sqlDataReader["AceitaGato"]
                };
            }

            await sqlConnection.CloseAsync();

            return abrigo;
        }

        public async Task<List<Abrigo>> Obter(string nome, string endereco)
        {
            var abrigos = new List<Abrigo>();

            var comando = $"select * from Abrigos where Nome = '{nome}' and Endereco = '{endereco}'";

            await sqlConnection.OpenAsync();
            SqlCommand sqlCommand = new SqlCommand(comando, sqlConnection);
            SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync();

            while (sqlDataReader.Read())
            {
                abrigos.Add(new Abrigo
                {
                    Id = (Guid)sqlDataReader["Id"],
                    Nome = (string)sqlDataReader["Nome"],
                    Endereco = (string)sqlDataReader["Endereco"],
                    Numero = (string)sqlDataReader["Numero"],
                    Bairro = (string)sqlDataReader["Bairro"],
                    Cidade = (string)sqlDataReader["Cidade"],
                    Estado = (string)sqlDataReader["Estado"],
                    Telefone = (string)sqlDataReader["Telefone"],
                    AceitaCachorro = (bool)sqlDataReader["AceitaCachorro"],
                    AceitaGato = (bool)sqlDataReader["AceitaGato"]
                });
            }

            await sqlConnection.CloseAsync();

            return abrigos;
        }

        public async Task Inserir(Abrigo abrigo)
        {
            var comando = $"insert Abrigos (Id, Nome, Endereco, Numero, Bairro, Cidade, Estado, Telefone, AceitaCachorro, AceitaGato) values ('{abrigo.Id}', '{abrigo.Nome}', '{abrigo.Endereco}', '{abrigo.Numero}', '{abrigo.Bairro}', '{abrigo.Cidade}', '{abrigo.Estado}','{abrigo.Telefone}','{abrigo.AceitaCachorro}', {abrigo.AceitaGato.ToString().Replace(",", ".")})";

            await sqlConnection.OpenAsync();
            SqlCommand sqlCommand = new SqlCommand(comando, sqlConnection);
            sqlCommand.ExecuteNonQuery();
            await sqlConnection.CloseAsync(); 
        }

        public async Task Atualizar(Abrigo abrigo)
        {
            var comando = $"update Abrigos set Nome = '{abrigo.Nome}', Endereco = '{abrigo.Endereco}', Numero = '{abrigo.Numero}', Bairro = '{abrigo.Bairro}', Cidade = '{abrigo.Cidade}', Estado = '{abrigo.Estado}', Telefone = '{abrigo.Telefone}', AceitaCachoro = '{abrigo.AceitaCachorro}', AceitaGato = {abrigo.AceitaGato.ToString().Replace(",", ".")} where Id = '{abrigo.Id}'";

            await sqlConnection.OpenAsync();
            SqlCommand sqlCommand = new SqlCommand(comando, sqlConnection);
            sqlCommand.ExecuteNonQuery();
            await sqlConnection.CloseAsync();
        }

        public async Task Remover(Guid id)
        {
            var comando = $"delete from Abrigos where Id = '{id}'";

            await sqlConnection.OpenAsync();
            SqlCommand sqlCommand = new SqlCommand(comando, sqlConnection);
            sqlCommand.ExecuteNonQuery();
            await sqlConnection.CloseAsync();
        }

        public void Dispose()
        {
            sqlConnection?.Close();
            sqlConnection?.Dispose();
        }
    }

}

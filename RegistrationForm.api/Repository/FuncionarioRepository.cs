using Dapper;
using Microsoft.Extensions.Configuration;
using RegistrationForm.api.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xceed.Wpf.Toolkit;

namespace RegistrationForm.api.Repository
{
    public class FuncionarioRepository
    {
        private static IConfigurationRoot Configuration { get; set; }
        public string Connection()
        {
            var builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            Configuration = builder.Build();
            string _con = Configuration["ConnectionStrings:DefaultConnection"];
            return _con;
        }

        public async Task<Funcionario> ConsultarId(string id)
        {
            string conexao = Connection();
            using (var db = new SqlConnection(conexao))
            {

                await db.OpenAsync();
                var query = "Select * From Funcionarios where FuncionarioId=" + id + ";";
                var funcionarios = await db.QueryAsync<Funcionario>(query);
                return funcionarios.First();

            }
        }

        public async Task<IEnumerable<Funcionario>> ConsultarAll()
        {
            string conexao = Connection();
            using (var db = new SqlConnection(conexao))
            {

                await db.OpenAsync();
                var query = "Select * From Funcionarios";
                var funcionarios = await db.QueryAsync<Funcionario>(query);
                return funcionarios;

            }
        }

        public async void Incluir(Funcionario funcionario)
        {
            string conexao = Connection();
            using (var db = new SqlConnection(conexao))

            {
                try
                {

                    await db.OpenAsync();
                    var query = @"Insert Into Funcionarios(Nome,Sexo,Pis,Cpf,Salario,Email,DataAdmissao) Values(@Nome,@sexo,@pis,@cpf,@salario,@email,@dataadmissao)";
                    await db.ExecuteAsync(query, funcionario);

                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);

                }
            }
        }

        public async void Atualizar(Funcionario funcionario)
        {

            string conexao = Connection();
            using (var db = new SqlConnection(conexao))

            {

                try
                {

                    await db.OpenAsync();
                    var query = @"Update funcionarios Set Nome=@Nome, Sexo=@Sexo, Pis=@Pis, Cpf=@Cpf, Salario=@Salario, Email=@Email, DataAdmissao=@DataAdmissao Where FuncionarioId=@FuncionarioId";
                    await db.ExecuteAsync(query, funcionario);

                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);

                }
            }
        }

        public async Task<Funcionario> Deletar(string id)
        {

            string conexao = Connection();
            using var db = new SqlConnection(conexao);

            await db.OpenAsync();
            var query = @"Delete from funcionarios Where FuncionarioId=" + id;
            await db.ExecuteAsync(query, new { FuncionarioId = id });

        }
    }
}

using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using RegistrationForm.api.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;


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


        public async Task<Funcionario> ConsultarId(int id)
        {

            string conexao = Connection();
            using (var db = new SqlConnection(conexao))

            {

                await db.OpenAsync();
                var query = "Select * From Funcionarios where Id=@id;";
                var funcionarios = await db.QueryAsync<Funcionario>(query, new { id });
                return funcionarios.FirstOrDefault();

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

        public async Task<Funcionario> Incluir(Funcionario funcionario)
        {
            string conexao = Connection();
            using (var db = new SqlConnection(conexao))

            {

                await db.OpenAsync();
                var query =@"Insert Into Funcionarios(Nome,Sexo,Pis,Cpf,Salario,Email,DataAdmissao) Values(@nome,@sexo,@pis,@cpf,@salario,@email,@dataadmissao)";
                await db.ExecuteAsync(query, funcionario);
                return funcionario;

            }
        }

        public async Task<Funcionario> Atualizar(Funcionario funcionario)
        {

            string conexao = Connection();
            using (var db = new SqlConnection(conexao))

            {

                await db.OpenAsync();
                var query = @"Update Funcionarios Set Nome=@Nome, Sexo=@Sexo, Pis=@Pis, Cpf=@Cpf, Salario=@Salario, Email=@Email, DataAdmissao=@DataAdmissao Where Id=@Id";
                await db.ExecuteAsync(query, funcionario);
                return funcionario;

            }
        }

        public void Deletar(int id)
        {

            string conexao = Connection();
            using (var db = new SqlConnection(conexao))
            {

                db.OpenAsync();
                var query = @"Delete from Funcionarios Where Id=@id";
                var delete = db.QueryAsync<Funcionario>(query, new { id });
                db.ExecuteAsync(query);

            }
        }
    }
}


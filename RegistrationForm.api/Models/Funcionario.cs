using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegistrationForm.api.Models
{
    public class Funcionario
    {
        public Funcionario (string nome, string cpf)
        {
            Nome = nome;
            Cpf = cpf;
        }
        public Funcionario()
        {

        }
        public int FuncionarioId { get; set; }
        public string Nome { get; set; }
        public string Sexo { get; set; }
        public string Pis { get; set; }
        public string Cpf { get; set; }
        public string Salario { get; set; }
        public string Email { get; set; }
        public string DataAdmissao {get; set;}
    }
}
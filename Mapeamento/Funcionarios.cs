using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Mapeamento
{
    internal class Funcionarios
    {        
        public int _Id_Funcionarios { get; set; }
        public string _Nome { get; set; }
        public string _CPF { get; set; }
        public DateTime _DataNascimento { get; set; }
        public string _Endereco { get; set; }
        public string _Telefone { get; set; }
        public string _Sexo { get; set; }
    }
}
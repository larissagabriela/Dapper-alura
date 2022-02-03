using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dapper_alura_mais.Controllers
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTimeOffset DataCadastro { get; set; }

    }
}

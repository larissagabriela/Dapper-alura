using dapper_alura_mais.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dapper_alura_mais.Controllers
{
    interface IUsuarioRepository
    {
        public List<Usuario> Get();
        public Usuario Get(int id);
        public void Insert(Usuario usuario);
        public void Update(Usuario usuario);
        public void Delete(int id);
    }
}

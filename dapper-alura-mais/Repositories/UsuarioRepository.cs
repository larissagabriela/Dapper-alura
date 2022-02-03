using dapper_alura_mais.Controllers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;

namespace dapper_alura_mais.Controllers
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private IDbConnection _connection;
        public UsuarioRepository()
        {
            _connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=eCommerce;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        }

        public List<Usuario> Get()
        {
            return _connection.Query<Usuario>("SELECT * FROM Usuarios").ToList();

            /*
                List<Usuario> usuarios = new List<Usuario>();
                try
                {
                    SqlCommand command = new SqlCommand();
                    command.CommandText = "SELECT * FROM Usuarios";
                    command.Connection = (SqlConnection)_connection;

                    _connection.Open();

                    SqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        Usuario usuario = new Usuario();
                        usuario.Id = dataReader.GetInt32("Id");
                        usuario.Nome = dataReader.GetString("Nome");
                        usuario.DataCadastro = dataReader.GetDateTimeOffset(8);

                        usuarios.Add(usuario);
                    }
                }
                finally
                {
                    _connection.Close();
                }

                return usuarios;
             */
        }

        public Usuario Get(int id)
        {
            return _connection.QuerySingleOrDefault<Usuario>("SELECT * FROM Usuarios WHERE Id = @Id", new { Id = id });

            /*
            try
            {
                
                SqlCommand command = new SqlCommand();
                command.CommandText = $"SELECT * FROM Usuarios WHERE Id = @Id";
                command.Parameters.AddWithValue("@Id", id);
                command.Connection = (SqlConnection)_connection;

                _connection.Open();
                SqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    Usuario usuario = new Usuario();
                    usuario.Id = dataReader.GetInt32("Id");
                    usuario.Nome = dataReader.GetString("Nome");
                    usuario.DataCadastro = dataReader.GetDateTimeOffset(8);

                    return usuario;
                }
            }
            finally
            {
                _connection.Close();
            }

            return null;
             */

        }

        public void Insert(Usuario usuario)
        {
            string sql = "INSERT INTO Usuarios(Nome, DataCadastro) VALUES (@Nome, @DataCadastro); SELECT CAST(SCOPE_IDENTITY() AS INT);";

            usuario.Id = _connection.Query<int>(sql, usuario).Single();

            /*
            try
            {
                SqlCommand command = new SqlCommand();
                command.CommandText = "INSERT INTO Usuarios(Nome, DataCadastro) VALUES (@Nome, @DataCadastro);SELECT CAST(scope_identity() AS int)";
                command.Connection = (SqlConnection)_connection;

                command.Parameters.AddWithValue("@Nome", usuario.Nome);
                command.Parameters.AddWithValue("@DataCadastro", usuario.DataCadastro);

                _connection.Open();
                usuario.Id = (int)command.ExecuteScalar();
            }finally
            {
                _connection.Close();
            }
             
             */

        }

        public void Update(Usuario usuario)
        {
            string sql = "UPDATE Usuarios SET Nome = @Nome, DataCadastro = @DataCadastro WHERE Id = @Id";

            _connection.Execute(sql, usuario);

            /*
            try
            {
                SqlCommand command = new SqlCommand();
                command.CommandText = "UPDATE Usuarios SET Nome = @Nome, DataCadastro=@DataCadastro WHERE Id = @Id";
                command.Connection = (SqlConnection)_connection;

                command.Parameters.AddWithValue("@Nome", usuario.Nome);
                command.Parameters.AddWithValue("@DataCadastro", usuario.DataCadastro);

                command.Parameters.AddWithValue("@Id", usuario.Id);

                _connection.Open();
                command.ExecuteNonQuery();
            }
            finally
            {
                _connection.Close();
            }
             */
        }

        public void Delete(int id)
        {
            _connection.Execute("DELETE FROM Usuarios WHERE Id = @Id", new { Id = id });

            /*
            try
            {
                SqlCommand command = new SqlCommand();
                command.CommandText = "DELETE FROM Usuarios WHERE Id = @Id";
                command.Connection = (SqlConnection)_connection;

                command.Parameters.AddWithValue("@Id", id);

                _connection.Open();
                command.ExecuteNonQuery();
            }
            finally
            {
                _connection.Close();
            }
        }
           
      } */
        }
    }
}
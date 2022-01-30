using Dapper;
using Dapper.Contrib.Extensions;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Web.Data.Configuracao;
using Web.Data.Interface;
using Web.Models;

namespace Web.Data.MSSQL
{
    public class MSSQLUsuario : IUsuarioDb
    {
        private readonly string _conexao;
        public MSSQLUsuario(ConnectionStrings connection)
        {
            _conexao = connection.ConexaoBanco;
        }

        public Usuario BuscaUsuario(string username)
        {
            try
            {
                using var con = new SqlConnection(_conexao);


                var resultado = con.Query<Usuario>("SELECT TOP 1 username FROM Usuario WHERE UserName = @UserName", new { UserName = username }).FirstOrDefault();

                return resultado;

            }
            catch (System.Exception)
            {

                return new Usuario();
            }
        }

        public bool Delete(int id)
        {
            try
            {
                using var con = new SqlConnection(_conexao);

                con.Delete(new Usuario { Id = id });

                return true;
            }
            catch (System.Exception ex)
            {
                var teste = ex.Message;

                return false;
            }
        }

        public bool Insert(Usuario usuario)
        {
            try
            {
                using var con = new SqlConnection(_conexao);

                con.Insert(usuario);

                return true;
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine(ex.Message);

                return false;
            }

        }

        public bool Update(Usuario usuario)
        {
            try
            {
                using var con = new SqlConnection(_conexao);

                con.Update<Usuario>(usuario);

                return true;

            }
            catch (System.Exception)
            {

                return false;
            }

        }

        public Usuario Usuario(int id)
        {
            try
            {
                using var con = new SqlConnection(_conexao);

                return con.Get<Usuario>(id);
            }
            catch (System.Exception)
            {

                return new Usuario();
            }
        }

        public List<Usuario> Usuarios()
        {
            try
            {
                using var con = new SqlConnection(_conexao);


                return con.GetAll<Usuario>().ToList();

            }
            catch (System.Exception)
            {

                return new List<Usuario>();
            }

        }
    }
}

using System.Collections.Generic;
using Web.Models;

namespace Web.Data.Interface
{
    public interface IUsuarioDb
    {

        List<Usuario> Usuarios();
        Usuario Usuario(int id);
        Usuario BuscaUsuario(string username);
        bool Insert(Usuario usuario);
        bool Update(Usuario usuario);
        bool Delete(int id);

    }
}

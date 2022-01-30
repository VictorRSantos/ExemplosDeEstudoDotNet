using Microsoft.AspNetCore.Mvc;
using Web.Data.Configuracao;
using Web.Data.Interface;
using Web.Data.MSSQL;
using Web.Models;

namespace Web.Controllers
{
    public class UsuarioController : Controller
    {

        private readonly IUsuarioDb _usuarioDb;


        public UsuarioController(ConnectionStrings connection)
        {
            _usuarioDb = new MSSQLUsuario(connection);

        }

        [HttpGet]
        public IActionResult Index()
        {
            var usuario = new Usuario();

            ViewBag.Usuarios = _usuarioDb.Usuarios();

            return View(usuario);
        }


        [HttpGet]
        public IActionResult Adicionar()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Adicionar(Usuario usuario)
        {

            var resultado = _usuarioDb.Insert(usuario);
            if (resultado)
            {
                TempData["success"] = "Mensagem de sucesso!!";
                return RedirectToAction("Index");
            }

            TempData["error"] = "Mensagem de erro!!";
            ViewBag.Usuarios = _usuarioDb.Usuarios();
            return View("Index", usuario);
        }


        [HttpGet]
        public IActionResult Editar(int id)
        {

            Usuario usuario = new Usuario();
            usuario = _usuarioDb.Usuario(id);

            return View(usuario);
        }

        [HttpPost]
        public IActionResult Editar(Usuario usuario)
        {
            var resultado = _usuarioDb.Update(usuario);

            if (resultado)
            {
                TempData["success"] = "Mensagem de sucesso!!";
                return RedirectToAction("Index");
            }

            TempData["error"] = "Mensagem de erro!!";
            ViewBag.Usuarios = _usuarioDb.Usuarios();
            return View("Index", usuario);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Usuario usuario = new Usuario();
            usuario = _usuarioDb.Usuario(id);

            return View(usuario);

        }


        [HttpPost]
        public IActionResult ConfirmarDelete(int id)
        {
             _usuarioDb.Delete(id);

            TempData["success"] = "Mensagem de sucesso!!";

            return RedirectToAction("Index");

        }


        [HttpGet]
        public IActionResult Detalhes(int id)
        {
            Usuario usuario = new Usuario();
            usuario = _usuarioDb.Usuario(id);

            return View(usuario);

        }

    }
}

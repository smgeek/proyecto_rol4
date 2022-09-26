using Microsoft.AspNetCore.Mvc;
using PROYECTO_ROL4.Data;
using PROYECTO_ROL4.Models;

using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;

namespace PROYECTO_ROL4.Controllers
{
    public class AccesoController : Controller
    {
        public IActionResult Index()//Permiti simular formulario de inicio de sesión
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(Usuario _usuario)
        {
            DA_Logica _da_usuario = new DA_Logica();
            var usuario = _da_usuario.validarUsuario(_usuario.Correo, _usuario.Clave);

            if( usuario != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, usuario.Nombre),
                    new Claim("Correo", usuario.Correo)
                };
                

                foreach (string rol in usuario.Roles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, rol));
                }

                var ClaimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(ClaimsIdentity));

                return RedirectToAction("Index", "Home"); // redirecciona a la vista de home
            }
            else
            {
                return View();
            }
                
        }

        public async Task<IActionResult> Salir()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Acceso");
        }
    }
}

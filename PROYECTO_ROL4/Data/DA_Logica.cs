using PROYECTO_ROL4.Models;

namespace PROYECTO_ROL4.Data
{
    public class DA_Logica
    {
        public List<Usuario> listaUsuario() //Nos devuelve los usuarios creados
        {
            return new List<Usuario>()
            //Agergar uno a uno todos los usuarios
            {
                new Usuario{Nombre="Santiago",Apellido="Meléndez",Correo="administrador@gmail.com",Clave="12345",Roles = new string[]{"Administrador"}},
                new Usuario{Nombre="Eliana",Apellido="Barreto",Correo="supervisora@gmail.com",Clave="123456",Roles = new string[]{"Supervisor"}},
                new Usuario{Nombre="Juan",Apellido="García",Correo="empleado@gmail.com",Clave="123",Roles = new string[]{"Empleado"}},
                new Usuario{Nombre="Oscar",Apellido="Perez",Correo="superempleado@gmail.com",Clave="122",Roles = new string[]{"Supervisor","Empleado"}}
            };
        }

        // Metodo para validar el ingreso del usuario, corroboran las credenciales

        public Usuario validarUsuario (string _correo, string _clave)
        {
            return listaUsuario().Where(item => item.Correo == _correo && item.Clave == _clave).FirstOrDefault();
        }



    }
}

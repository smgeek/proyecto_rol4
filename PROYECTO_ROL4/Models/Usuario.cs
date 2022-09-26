namespace PROYECTO_ROL4.Models
{
    public class Usuario
    {
        

        // Definimos la entidad Usuario
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Correo { get; set; }
        public string Clave { get; set; }

        public string[] Roles { get; set; }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Parking.Core.Negocio;
using Parking.Core.Model;

namespace Parking.Console
{
    public class Program
    {
        

        static void Main(string[] args)
        {
            System.Console.WriteLine("Hola");

            //Administracion administracion = new Administracion();

            //List<Usuario> usuarios = administracion.GetUsuarios();


            //for (int i = 0; i < usuarios.Count(); i++)
            //{
            //    System.Console.WriteLine($"{usuarios.ElementAt(i).Nombres}");
            //}

            Program p = new Program();

            p.CrearUsuario(3,"Ana","Maria no me gustan los lunes","1033800438", "ana@gmail.com", "1234");

            System.Console.ReadKey();
        }


        public void CrearUsuario(int id, string nombres, string apellidos, string identificación, string email, string contrasena)
        {
            Administracion administracion = new Administracion();

            Usuario usuario = new Usuario()
            {
                Nombres = nombres,
                Apellidos = apellidos,
                Identificacion = identificación,
                Email = email,
                Contrasena = contrasena
            };

            administracion.SaveUsuario(usuario);
        }
    }
}

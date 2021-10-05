using Parking.Core.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Parking.Core.Model;
namespace Parking.Core.Negocio
{
    public class ModuloUsuarios : Maestro
    {

        /// <summary>
        /// Constructor vacio
        /// </summary>
        public ModuloUsuarios() : base()
        {
        }

        /// <summary>
        /// Constructor con repositorio
        /// </summary>
        /// <param name="repositorio"></param>
        public ModuloUsuarios(ParkingRepositorio repositorio) : base(repositorio)
        {

        }

        /// <summary>
        /// Consulta todos los usuarios del sistema
        /// </summary>
        /// <returns></returns>
        public List<Usuario> GetUsuarios()
        {
            //return this.Repositorio.GetAll<Usuario>().ToList();
           return this.Repositorio.GetAll<Usuario>().Where(mod => mod.Eliminado == null).ToList();
        }

        /// <summary>
        /// Consulta un usuario por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Usuario GetUsuario(int id)
        {
            //Consulta el usuarios
            Usuario usuario = this.Repositorio.GetAll<Usuario>().Where(mod => mod.IdUsuario == id && mod.Eliminado == null).ToList().FirstOrDefault();

            return usuario;
        }


        /// <summary>
        /// Crea un usuario 
        /// </summary>
        /// <param name="usuario"></param>
        public void CrearUsuario(Usuario usuario) 
        {
            this.Repositorio.Insert(usuario);

            this.Repositorio.Commit();
        }


        /// <summary>
        /// Actualiza un usuario existente
        /// </summary>
        /// <param name="id"></param>
        /// <param name="usuario"></param>
        public void ActualizarUsuario(int id, Usuario usuario)
        {
            Usuario consultado = this.GetUsuario(id);

            if (consultado != null)
            {
                //Campo por campo 
                consultado.Apellidos = usuario.Apellidos;
                consultado.Contrasena = usuario.Nombres;
                consultado.Email = usuario.Email;
                

                this.Repositorio.Update(consultado);
                this.Repositorio.Commit();

            }
            else
                throw new Exception($"No se encontró el usuario con id{id}");
        }

        /// <summary>
        /// Elimina un usuario especifico
        /// </summary>
        /// <param name="id"></param>
        public void EliminarUsuario(int id)
        {
             Usuario consultado = this.GetUsuario(id);
             consultado.Eliminado = DateTime.Now;
            foreach (var c in consultado.Calibracions)
            {
                c.Eliminado = DateTime.Now;
                foreach (var ed in c.EspacioDelimitadoes)
                {
                    ed.Eliminado = DateTime.Now;
                }
            }
            //this.Repositorio.Delete<Usuario>(id);
            this.Repositorio.Commit();
            
        }

    }
}

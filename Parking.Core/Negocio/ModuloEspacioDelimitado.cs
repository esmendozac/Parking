using Parking.Core.Model;
using Parking.Core.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking.Core.Negocio
{
    public class ModuloEspacioDelimitado: Maestro
    {
        public ModuloEspacioDelimitado() : base()
        {
        }

        /// <summary>
        /// Constructor con repositorio
        /// </summary>
        /// <param name="repositorio"></param>
        public ModuloEspacioDelimitado(ParkingRepositorio repositorio) : base(repositorio)
        {

        }

        /// <summary>
        /// Consulta lista del sistema
        /// </summary>
        /// <returns></returns>
        public List<EspacioDelimitado> GetEspacioDelimitados()
        {
            //return this.Repositorio.GetAll<EspacioDelimitado>().ToList();
            return this.Repositorio.GetAll<EspacioDelimitado>().Where(mod => mod.Eliminado == null).ToList();
        }

        /// <summary>
        /// Consulta por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public EspacioDelimitado GetEspacioDelimitado(int id)
        {
            //Consulta el usuarios
            EspacioDelimitado espaciodelimitado = this.Repositorio.GetAll<EspacioDelimitado>().Where(mod => mod.IdEspacioDelimitado == id && mod.Eliminado == null).ToList().FirstOrDefault();

            return espaciodelimitado;
        }


        /// <summary>
        /// Crea un item de la lista 
        /// </summary>
        /// <param name="espaciodelimitado"></param>
        public void CrearEspacioDelimitado(EspacioDelimitado espaciodelimitado)
        {
            this.Repositorio.Insert(espaciodelimitado);

            this.Repositorio.Commit();
        }


        /// <summary>
        /// Actualiza un items existente
        /// </summary>
        /// <param name="id"></param>
        /// <param name="espaciodelimitado"></param>
        public void ActualizarEspacioDelimitado(int id, EspacioDelimitado espaciodelimitado)
        {
            EspacioDelimitado consultado = this.GetEspacioDelimitado(id);

            if (consultado != null)
            {
                //Campo por campo 
                consultado.Coord1 = espaciodelimitado.Coord1;
                consultado.Coord2 = espaciodelimitado.Coord2;
                consultado.Coord3 = espaciodelimitado.Coord3;
                consultado.Coord4 = espaciodelimitado.Coord4;


                this.Repositorio.Update(consultado);
                this.Repositorio.Commit();

            }
            else
                throw new Exception($"No se encontró el usuario con id{id}");
        }

        /// <summary>
        /// Elimina un item especifico
        /// </summary>
        /// <param name="id"></param>
        public void EliminarEspacioDelimitado(int id)
        {
            EspacioDelimitado consultado = this.GetEspacioDelimitado(id);
            consultado.Eliminado = DateTime.Now;
            //this.Repositorio.Delete<EspacioDelimitado>(id);
            this.Repositorio.Commit();
        }

    }
}
 
using Parking.Core.Model;
using Parking.Core.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking.Core.Negocio
{
    public class ModuloCalibracion : Maestro
    {
        public ModuloCalibracion() : base()
        {
        }

        /// <summary>
        /// Constructor con repositorio
        /// </summary>
        /// <param name="repositorio"></param>
        public ModuloCalibracion(ParkingRepositorio repositorio) : base(repositorio)
        {

        }

        /// <summary>
        /// Consulta lista del sistema
        /// </summary>
        /// <returns></returns>
        public List<Calibracion> GetCalibracions()
        {
            return this.Repositorio.GetAll<Calibracion>().Where(mod => mod.Eliminado == null).ToList();
            //return this.Repositorio.GetAll<Calibracion>().ToList();
        }

        /// <summary>
        /// Consulta por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Calibracion GetCalibracion(int id)
        {
            //Consulta el usuarios
            Calibracion calibracion = this.Repositorio.GetAll<Calibracion>().Where(mod => mod.IdCalibracion == id && mod.Eliminado == null).ToList().FirstOrDefault();

            return calibracion;
        }


        /// <summary>
        /// Crea un item de la lista 
        /// </summary>
        /// <param name="calibracion"></param>
        public void CrearCalibracion(Calibracion calibracion)
        {
            this.Repositorio.Insert(calibracion);

            this.Repositorio.Commit();
        }


        /// <summary>
        /// Actualiza un items existente
        /// </summary>
        /// <param name="id"></param>
        /// <param name="calibracion"></param>
        public void ActualizarCalibracion(int id, Calibracion calibracion)
        {
            Calibracion consultado = this.GetCalibracion(id);

            if (consultado != null)
            {
                //Campo por campo 
                consultado.Habilitada= calibracion.Habilitada;
           


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
        public void EliminarCalibracion(int id)
        {
            Calibracion consultado = this.GetCalibracion(id);
            consultado.Eliminado = DateTime.Now;
            //this.Repositorio.Delete<Calibracion>(id);
            this.Repositorio.Commit();
        }

    }
}

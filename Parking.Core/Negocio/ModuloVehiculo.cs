using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Parking.Core.Repositorio;
using Parking.Core.Dto;
using Parking.Core.Model;

namespace Parking.Core.Negocio
{
    public class ModuloVehiculo : Maestro
    {

        /// <summary>
        /// Constructor vacio
        /// </summary>
        public ModuloVehiculo() : base()
        {
        }

        /// <summary>
        /// Constructor con repositorio
        /// </summary>
        /// <param name="repositorio"></param>
        public ModuloVehiculo(ParkingRepositorioLite repositorio) : base(repositorio)
        {

        }

        /// <summary>
        /// Valida si la información mejoró para actualizarla 
        /// </summary>
        /// <param name="campo1">Dto</param>
        /// <param name="campo2">Almacenada</param>
        public string ValidarCampo(string campo1, string campo2)
        {
            if (string.IsNullOrWhiteSpace(campo2) && !string.IsNullOrWhiteSpace(campo1))
                campo2 = campo1;

            return campo2;
        }

        /// <summary>
        /// Registra una transacción y un vehiculo especifico asociado a la misma
        /// </summary>
        /// <param name="vtDto"></param>
        public int RegistrarTransaccion(Dto.VehiculoTransaccion vtDto)
        {
            this.Repositorio.LazyLoading = false;

            Model.Vehiculo veh = this.Repositorio.GetAll<Vehiculo>().Where(v => v.Placa == vtDto.Placa).FirstOrDefault();

            //Verifica si la placa existe:
            if (veh == null)
            {
                //Crea el vehiculo a partir del DTO
                veh = new Vehiculo()
                {
                    Placa = vtDto.Placa,
                    Clase = vtDto.Clase,
                    Linea = vtDto.Linea,
                    Marca = vtDto.Marca,
                    Modelo = vtDto.Modelo,
                    NumeroMotor = vtDto.NumeroMotor,
                    Vin = vtDto.Vin,
                    FechaActualizacion = DateTime.Now,
                    FechaCreacion = DateTime.Now
                };

                //Inserta el vehiculo
                this.Repositorio.Insert<Vehiculo>(veh);                

            }
            //Actualiza los campos nuevos que vengan 
            else
            {
                veh.Placa = ValidarCampo(vtDto.Placa, veh.Placa);
                veh.Clase = ValidarCampo(vtDto.Clase, veh.Clase);
                veh.Linea = ValidarCampo(vtDto.Linea, veh.Linea);
                veh.Marca = ValidarCampo(vtDto.Marca, veh.Marca);
                veh.Modelo = ValidarCampo(vtDto.Modelo, veh.Modelo);
                veh.NumeroMotor = ValidarCampo(vtDto.NumeroMotor, veh.NumeroMotor);
                veh.Vin = ValidarCampo(vtDto.Vin, veh.Vin);
                veh.FechaActualizacion = DateTime.Now;
            }

            

            //Crea la transación 
            Model.VehiculoTransaccion vt = new Model.VehiculoTransaccion()
            {
                Placa = veh.Placa,
                Eliminado = null,
                Fecha = DateTime.Now,
                IdLote = vtDto.IdLote,
                TipoTransaccion = vtDto.TipoTransaccion                
            };

            veh.VehiculoTransaccions.Add(vt);

            //this.Repositorio.Insert<Model.VehiculoTransaccion>(vt);
            this.Repositorio.Commit();

            return vt.IdTransaccion;
        }
    }
}

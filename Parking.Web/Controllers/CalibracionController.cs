using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Parking.Core.Model;
using Parking.Core.Negocio;


namespace Parking.Web.Controllers
{
    public class CalibracionsController : ApiController
    {

        private ModuloCalibracion modulo = null;

        public CalibracionsController()
        {
            this.modulo = new ModuloCalibracion();
        }

        /// <summary>
        /// Consulta LISTAS del sistema 
        /// </summary>
        /// <returns></returns>
        [Route("api/calibracion")]
        public IHttpActionResult GetCalibracions()
        {
            try
            {
                return Ok(this.modulo.GetCalibracions());
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar los usuarios", ex);
            }
        }

        [Route("api/calibracion/{id}")]
        [ResponseType(typeof(Calibracion))]
        public IHttpActionResult GetCalibracion(int id)
        {
            Calibracion calibracion = this.modulo.GetCalibracion(id);

            if (calibracion == null)
            {
                return NotFound();
            }

            return Ok(calibracion);
        }

        [Route("api/calibracion/{id}")]
        public IHttpActionResult PutCalibracion(int id, Calibracion calibracion)
        {
            try
            {
                this.modulo.ActualizarCalibracion(id, calibracion);

                return StatusCode(HttpStatusCode.NoContent);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost()]
        [Route("api/calibracion")]
        [ResponseType(typeof(Calibracion))]
        public IHttpActionResult PostCalibracion(Calibracion calibracion)
        {
            this.modulo.CrearCalibracion(calibracion);

            return Ok(calibracion);
        }

        [Route("api/calibracion/{id}")]
        [HttpDelete()]
        [ResponseType(typeof(Calibracion))]
        public IHttpActionResult DeleteCalibracion(int id)
        {
            this.modulo.EliminarCalibracion(id);
            return Ok(id);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                modulo.Dispose();
            }
            base.Dispose(disposing);
        }


    }
}
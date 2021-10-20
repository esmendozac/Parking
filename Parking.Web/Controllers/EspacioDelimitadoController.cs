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
    public class EspacioDelimitadosController : ApiController
    {

        private ModuloEspacioDelimitado modulo = null;

        public EspacioDelimitadosController()
        {
            this.modulo = new ModuloEspacioDelimitado();
        }

        /// <summary>
        /// Consulta todos los usuarios del sistema 
        /// </summary>
        /// <returns></returns>
        [Route("api/espaciodelimitado")]
        public IHttpActionResult GetEspacioDelimitados()
        {
            try
            {
                return Ok(this.modulo.GetEspacioDelimitados());
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar los usuarios", ex);
            }
        }

        [Route("api/espaciodelimitado/{id}")]
        [ResponseType(typeof(EspacioDelimitado))]
        public IHttpActionResult GetEspacioDelimitado(int id)
        {
            EspacioDelimitado espaciodelimitado = this.modulo.GetEspacioDelimitado(id);

            if (espaciodelimitado == null)
            {
                return NotFound();
            }

            return Ok(espaciodelimitado);
        }

        [Route("api/espaciodelimitado/{id}")]
        public IHttpActionResult PutEspacioDelimitado(int id, EspacioDelimitado espaciodelimitado)
        {
            try
            {
                this.modulo.ActualizarEspacioDelimitado(id, espaciodelimitado);

                return StatusCode(HttpStatusCode.NoContent);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost()]
        [Route("api/espaciodelimitado")]
        [ResponseType(typeof(EspacioDelimitado))]
        public IHttpActionResult PostEspacioDelimitado(EspacioDelimitado espaciodelimitado)
        {
            try
            {
                this.modulo.CrearEspacioDelimitado(espaciodelimitado);

                return Ok(espaciodelimitado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [Route("api/espaciodelimitado/{id}")]
        [HttpDelete()]
        [ResponseType(typeof(EspacioDelimitado))]
        public IHttpActionResult DeleteEspacioDelimitado(int id)
        {
            this.modulo.EliminarEspacioDelimitado(id);
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
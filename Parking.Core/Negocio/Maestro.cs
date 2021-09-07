using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Parking.Core.Model;
using Parking.Core.Repositorio;

namespace Parking.Core.Negocio
{
    public class Maestro : IDisposable
    {

        ParkingRepositorio repositorio;
        private bool dispose = false;

        public Maestro()
        {
            this.repositorio = null;
        }

        public Maestro(ParkingRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }

        internal ParkingRepositorio Repositorio
        {
            get
            {
                if (this.repositorio == null)
                {
                    this.repositorio = new ParkingRepositorio();
                    dispose = true;
                }

                return repositorio;
            }
            set
            {
                this.repositorio = value;
            }
        }

        public virtual void Dispose()
        {
            if (dispose && this.repositorio != null)
                this.repositorio.Dispose();

            this.repositorio = null;           
        }
    }
}

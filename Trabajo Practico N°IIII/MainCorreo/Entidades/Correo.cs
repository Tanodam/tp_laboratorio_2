using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Entidades
{
    public class Correo : IMostrar<Paquete>
    {
        private List<Thread> mockPaquetes;
        private List<Paquete> paquetes;

        #region Propiedades
        public List<Paquete> Paquetes
        {
            get
            {
                return this.paquetes;
            }
        }
        #endregion
        #region Metodos
        /// <summary>
        /// Constructor de clase
        /// </summary>
        public Correo()
        {
            this.paquetes = new List<Paquete>();
        }
        /// <summary>
        /// Metodo FinEntrega
        /// </summary>
        public void FinEntrega()
        {

        }

        public string MostrarDatos(IMostrar<Paquete> elemento)
        {
            string datos = "";
            foreach (Paquete paquete in this.Paquetes)
            {
                datos += String.Format("{0} para {1} ({2})\n", paquete.TrackingID, paquete.DireccionEntrega,
                                                               paquete.Estado.ToString());
            }
            return datos;
        }

        /// <summary>
        /// Sobrecarga operador +
        /// </summary>
        /// <param name="correo"></param>
        /// <param name="paquete"></param>
        /// <returns></returns>
        public static Correo operator +(Correo correo, Paquete paquete)
        {
            if((correo.paquetes.Contains(paquete)))
            {
                throw new TrackingIdRepetidoException("El paquete ya se encuentra en la lista");
            }
            else
            {
                correo.paquetes.Add(paquete);
            }
            return correo;
        }
        
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Entidades
{
    public class Paquete : IMostrar<Paquete>
    {
        public enum EEstado
        {
            Ingresado, EnViaje, Entregado
        };
        private string direccionEntrega;
        private EEstado estado;
        private string trackingID;

        #region Propiedades
        public string DireccionEntrega
        {
            get
            {
                return this.direccionEntrega;
            }
            set
            {
                this.direccionEntrega = value;
            }
        }
        public EEstado Estado
        {
            get
            {
                return this.estado;
            }
            set
            {
                this.estado = value;
            }
        }
        public string TrackingID
        {
            get
            {
                return this.trackingID;
            }
            set
            {
                this.trackingID = value;
            }
        }
        #endregion
        #region Metodos
        public Paquete(string direccionEntrega, string trackingID)
        {
            this.DireccionEntrega = direccionEntrega;
            this.TrackingID = trackingID;
        }
        /// <summary>
        /// MockCicloDeVida hará que el paquete cambie de estado de la siguiente forma:
        ///a.Colocar una demora de 4 segundos.
        ///b.Pasar al siguiente estado.
        ///c.Informar el estado a través de InformarEstado. EventArgs no tendrá ningún dato extra.
        ///d.Repetir las acciones desde el punto A hasta que el estado sea Entregado.
        ///e.Finalmente guardar los datos del paquete en la base de datos
        /// </summary>
        public void MockCicloDeVida()
        {
            int contadorEstados = -1;
            //this.Estado = EEstado.Ingresado;
            do
            {
                Thread.Sleep(500);
                contadorEstados = (int)this.Estado + 1;
                this.Estado = (EEstado)contadorEstados;
                this.InformaEstado(this, null);
            } while ((int)this.Estado < 2);
            PaqueteDAO.Insertar(this);
        }

        public static bool operator ==(Paquete paqueteUno, Paquete paqueteDos)
        {
            return (paqueteUno.TrackingID == paqueteDos.TrackingID);
        }
        public static bool operator !=(Paquete paqueteUno, Paquete paqueteDos)
        {
            return !(paqueteUno == paqueteDos);
        }
        public override string ToString()
        {
            return MostrarDatos(this);
        }
        public string MostrarDatos(IMostrar<Paquete> elemento)
        {
            return String.Format("{0} para {1}", ((Paquete)elemento).TrackingID, ((Paquete)elemento).DireccionEntrega);
        }
        #endregion
        #region Delegados / Eventos

        public delegate void DelegadoEstado(object paquete, EventArgs e);

        public event DelegadoEstado InformaEstado;

        #endregion


    }
}

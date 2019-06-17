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
        #region Delegados / Eventos

        public delegate void DelegadoEstado(object paquete, EventArgs e);
        public event DelegadoEstado InformaEstado;

        public delegate void DelegadoEstadoException(object paquete, Exception exception);
        public event DelegadoEstadoException InformaException;

        #endregion

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
        /// <summary>
        /// Contructor de paquete, instancia los atributos con los variables recibidas por parametro.
        /// </summary>
        /// <param name="direccionEntrega"></param>
        /// <param name="trackingID"></param>
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
            do
            {
                Thread.Sleep(4000);
                this.Estado += 1;
                this.InformaEstado(this, null);
            } while(this.Estado != EEstado.Entregado);
            try
            {
               PaqueteDAO.Insertar(this);
            }
            catch(Exception exception)
            {
                //En caso de error de conexion a la base se lanza un nuevo evento que envie la excepcion al form.
                this.InformaException(this, exception);
            }
        }
        /// <summary>
        /// Sobrecarga == entre Paquetes, seran iguales solo cuando su numero de tracking sea el mismo.
        /// </summary>
        /// <param name="paqueteUno"></param>
        /// <param name="paqueteDos"></param>
        /// <returns></returns>
        public static bool operator ==(Paquete paqueteUno, Paquete paqueteDos)
        {
            return (paqueteUno.TrackingID == paqueteDos.TrackingID);
        }
        /// <summary>
        /// Sobrecarga == entre Paquetes, seran distintos solo cuando su numero de tracking no sea el mismo.
        /// </summary>
        /// <param name="paqueteUno"></param>
        /// <param name="paqueteDos"></param>
        /// <returns></returns>
        public static bool operator !=(Paquete paqueteUno, Paquete paqueteDos)
        {
            return !(paqueteUno == paqueteDos);
        }
        /// <summary>
        /// MostrarDatos utilizará string.Format con el siguiente formato 
        /// "{0} para {1}", p.trackingID, p.direccionEntrega para compilar la información del paquete.
        /// </summary>
        /// <param name="elemento"></param>
        /// <returns></returns>
        public string MostrarDatos(IMostrar<Paquete> elemento)
        {
            return String.Format("{0} para {1}", ((Paquete)elemento).TrackingID, ((Paquete)elemento).DireccionEntrega);
        }
        /// <summary>
        /// sobrecarga del método ToString retornará la información del paquete.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return MostrarDatos(this);
        }
        #endregion



    }
}

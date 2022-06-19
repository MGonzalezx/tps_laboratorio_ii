using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static System.Environment;

namespace Entidades
{
    public class Cliente : IMostrar<Cliente> 
    {
        #region Enumerados,Delegados y Eventos

       
        public delegate void DelegadoEstado(object sender, EventArgs args);

        public enum EEstado
        {
            Ingresado,
            Resgistrado
        }

        public event DelegadoEstado InformaEstado;
    #endregion

        #region Atributos
        private string nombre;
        private string apellido;
        private int numeroAfiliado;
        private string requerimiento;
        private EEstado estado;
        #endregion



        #region Propiedades
        /// <summary>
        ///  Establece o devuelve el nombre del cliente
        /// </summary>
        public string Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                this.nombre = value;
            }
        }

        /// <summary>
        ///  Establece o devuelve el apellido del cliente
        /// </summary>
        public string Apellido
        {
            get
            {
                return this.apellido;
            }
            set
            {
                this.apellido = value;
            }
        }

        /// <summary>
        ///  Establece o devuelve el numero de afiliado del cliente
        /// </summary>
        public int NumeroAfiliado
        {
            get
            {
                return this.numeroAfiliado;
            }
            set
            {
                this.numeroAfiliado = value;
            }
        }

        /// <summary>
        ///  Establece o devuelve el requerimiento del cliente
        /// </summary>
        public string Requerimiento
        {
            get
            {
                return this.requerimiento;
            }
            set
            {
                this.requerimiento = value;
            }
        }

        /// <summary>
        /// Establece o devuelve el valor del estado del cliente
        /// </summary>
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


        #endregion



        #region Constructores

        /// <summary>
        /// Contructor vacio y privado del Cliente. Necesario para la serialización para XML
        /// </summary>
        private Cliente()
        {

        }

        /// <summary>
        /// Constructor de Cliente
        /// </summary>
        /// <param name="nombre">Nombre del cliente</param>
        /// <param name="apellido">Apeliido del cliente</param>
        /// <param name="requerimiento">Requerimiento del cliente</param>
        /// <param name="numeroAfiliado">Numero de afiliado del cliente</param>
        public Cliente(string nombre, string apellido, string requerimiento, int numeroAfiliado)
        {
            
            this.nombre = nombre;
            this.apellido = apellido;
            this.requerimiento = requerimiento;
            this.numeroAfiliado = numeroAfiliado;
        }
        #endregion


        #region Métodos

        /// <summary>
        /// Devuelve los datos del elemento recibido
        /// </summary>
        /// <param name="elemento"></param>
        /// <returns>Los datos</returns>
        public string MostrarDatos(Cliente elemento)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Nombre: {this.nombre} - Apellido: {this.apellido} ");
            sb.AppendLine($" Numero de Afiliado: {this.numeroAfiliado} ");
            sb.AppendLine($" Requerimiento: {this.requerimiento}");
            return sb.ToString();
        }

        
        public override string ToString()
        {
            return this.MostrarDatos(this);
        }


        /// <summary>
        /// Demora, cambia de estado, lo informa.
        /// Demora 4 segundos para luego modificar el estado del cliente de Ingresado a Resgistrado.
        /// Luego informa con el evento InformaEstado su estado.
        /// </summary>
        public void MockCicloDeVida()
        {
            while (this.estado != EEstado.Resgistrado)
            {
                System.Threading.Thread.Sleep(4000);
                int numeroDeEstado = (int)this.estado;
                numeroDeEstado++ ;
                this.estado = (EEstado)(numeroDeEstado);
               this.InformaEstado(this.estado, new EventArgs());
            }
            
        }


        #endregion

        #region Sobrecargas


        /// <summary>
        /// Compara dos clientes segun numero de afiliado
        /// </summary>
        /// <param name="c1">Cliente a comparar</param>
        /// <param name="c2">Segundo cliente a comparar</param>
        /// <returns>TRUE si los numeros son iguales, FALSE en el resto de los casos</returns>
        public static bool operator ==(Cliente c1, Cliente c2)
        {
            if (!Object.Equals(c1, null) && !Object.Equals(c2, null))
            {
                if (c1.numeroAfiliado == c2.numeroAfiliado)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Compara dos clientes segun dni
        /// </summary>
        /// <param name="c1">Cliente a comparar</param>
        /// <param name="c2">Segundo cliente a comparar</param>
        /// <returns>FALSE si los numeros son iguales, TRUE en el resto de los casos</returns>
        public static bool operator !=(Cliente c1, Cliente c2)
        {
            return !(c1 == c2);
        }

        #endregion
    }
}

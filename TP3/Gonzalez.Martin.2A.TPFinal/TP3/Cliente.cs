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
        #region Atributos
        private string nombre;
        private string apellido;
        private string numeroAfiliado;
        private string requerimiento;
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
        public string NumeroAfiliado
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
        /// <param name="requerimiento">Numero de afiliado del cliente</param>
        /// <param name="numeroAfiliado">Dni del cliente</param>
        public Cliente(string nombre, string apellido, string requerimiento, string numeroAfiliado)
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

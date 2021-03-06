using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{

   

    /// <summary>
    /// La clase Vehiculo no deberá permitir que se instancien elementos de este tipo.
    /// </summary>
    public abstract class Vehiculo
    {
        #region Enumerados

        public enum EMarca
        {
            Chevrolet,
            Ford,
            Renault,
            Toyota,
            BMW,
            Honda,
            HarleyDavidson
        }
        public enum ETamanio
        {
            Chico,
            Mediano,
            Grande
        }
        #endregion


        #region Atributos
        private EMarca marca;
        private string chasis;
        private ConsoleColor color;
        #endregion

        #region Propiedades
        /// <summary>
        /// ReadOnly: Retornará el tamaño
        /// </summary>
        protected abstract ETamanio Tamanio { get; }
        #endregion

        #region Constructor

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="chasis"> Chasis del Vehiculo</param>
        /// <param name="marca">Marca del Vehiculo</param>
        /// <param name="color">Color del Vehiculo</param>
        public Vehiculo(string chasis, EMarca marca, ConsoleColor color)
        {
            this.chasis = chasis;
            this.marca = marca;
            this.color = color;
        }

        #endregion

        #region Métodos
        /// <summary>
        /// Publica todos los datos del Vehiculo.
        /// </summary>
        /// <returns></returns>
        public virtual string Mostrar()
        {
            return (string)this;
        }


        /// <summary>
        /// Retornara todos los atributos de la clase Vehiculo en forma de string
        /// </summary>
        /// <param name="p">Vehiculo de donde se van a sacar los datos</param>
        public static explicit operator string(Vehiculo p)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("CHASIS: {0}\r\n", p.chasis);
            sb.AppendFormat("MARCA : {0}\r\n", p.marca.ToString());
            sb.AppendFormat("COLOR : {0}\r\n", p.color.ToString());
            sb.AppendLine("---------------------");

            return sb.ToString();
        }


        #endregion

        #region Sobrecargas

        /// <summary>
        /// Dos vehiculos son iguales si comparten el mismo chasis
        /// </summary>
        /// <param name="v1">Primer Vehiculo que vamos a comparar</param>
        /// <param name="v2">Segundo Vehiculo que vamos a comparar</param>
        /// <returns></returns>
        public static bool operator ==(Vehiculo v1, Vehiculo v2)
        {
            return (v1.chasis == v2.chasis);
        }
        /// <summary>
        /// Dos vehiculos son distintos si su chasis es distinto
        /// </summary>
        /// <param name="v1">Primer Vehiculo que vamos a comparar</param>
        /// <param name="v2">Segundo Vehiculo que vamos a comparar</param>
        /// <returns></returns>
        public static bool operator !=(Vehiculo v1, Vehiculo v2)
        {
            return !(v1 == v2);
        }
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace Entidades
{

    


    public class Sedan : Vehiculo
    {

        #region Enumerados
        public enum ETipo
        {
            CuatroPuertas,
            CincoPuertas
        }
        #endregion

        #region Atributos
        ETipo tipo;
        #endregion


        #region Propiedades
        /// <summary>
        /// Sedan son 'Mediano'
        /// </summary>
        protected override ETamanio Tamanio
        {
            get
            {
                return ETamanio.Mediano;
            }
        }
        #endregion


        #region Constructor
        /// <summary>
        /// Por defecto, TIPO será CuatroPuertas
        /// </summary>
        /// <param name="marca">Marca del vehiculo</param>
        /// <param name="chasis">Chasis del ehiculo</param>
        /// <param name="color">Color del vehiculo</param>

        public Sedan(EMarca marca, string chasis, ConsoleColor color) : base(chasis, marca, color)
        {
            this.tipo = ETipo.CuatroPuertas;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="marca">Marca del vehiculo</param>
        /// <param name="chasis">Chasis del ehiculo</param>
        /// <param name="color">Color del vehiculo</param>
        /// <param name="tipo">Color del vehiculo</param>
        public Sedan(EMarca marca, string chasis, ConsoleColor color, ETipo tipo): this(marca, chasis, color)
        {
            this.tipo = tipo;
        }

        #endregion

        #region Métodos
        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("SEDAN");
            sb.AppendLine(base.Mostrar());
            sb.AppendFormat("TAMAÑO : {0}", this.Tamanio);
            sb.AppendLine("TIPO : " + this.tipo);
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
        #endregion

    }
}

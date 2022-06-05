using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class NrmAfiliadoRepetidoException : Exception
    {
        /// <summary>
        /// Constructor de la exepcion en caso de numero de afiliado repetido
        /// </summary>
        /// <param name="mensaje">Mensaje</param>
        public NrmAfiliadoRepetidoException(string mensaje) : base(mensaje)
        { }

        /// <summary>
        /// Constructor de la excepcion en caso de numero de afiliado repetido
        /// </summary>
        /// <param name="mensaje">Mensaje</param>
        /// <param name="inner">Excepcion interna</param>
        public NrmAfiliadoRepetidoException(string mensaje, Exception inner) : base(mensaje, inner)
        { }


        
    }
}

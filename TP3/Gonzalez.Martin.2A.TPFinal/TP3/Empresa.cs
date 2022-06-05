using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Entidades
{
    public class Empresa : IMostrar<List<Cliente>>
    {
        #region Atributos

        private List<Cliente> clientes;
        #endregion

        #region Propiedades


        /// <summary>
        /// Establece o devuelve el valor de la lista de clientes
        /// </summary>
        public List<Cliente> Clientes
        {
            get
            {
                return this.clientes;
            }
            set
            {
                this.clientes = value;
            }
        }
        #endregion


        #region Constructor

        /// <summary>
        /// Constructor de Empresa en donde se inicializa la lista
        /// </summary>
        public Empresa()
        {
            
            this.clientes = new List<Cliente>();
        }
        #endregion


        #region Métodos


        /// <summary>
        /// Devuelve los datos del elemento recibido
        /// </summary>
        /// <param name="elemento">Elemento</param>
        /// <returns>Datos segun formato</returns>
        public string MostrarDatos(List<Cliente> elemento)
        {

            StringBuilder sb = new StringBuilder();

            foreach (Cliente item in this.clientes)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString();
        }
        

       
        /// <summary>
        /// Agrega un Cliente a la empresa si este no esta incluido. Se comparan sus numero de afiliados
        /// </summary>
        /// <param name="e">Empresa</param>
        /// <param name="c">Cliente</param>
        /// <returns>La empresa si el cliente esta agregado o no. O una excepcion si ya existe el numero de afiliado</returns>
        public static Empresa operator +(Empresa e, Cliente c)
        {
            List<Cliente> miLista = new List<Cliente>();

            foreach (Cliente cliente in e.Clientes.ToList())
            {
               

                if (cliente != c)
                {
                    //e.clientes.Add(c);
                    e.clientes.RemoveAll(c => miLista.Contains(c));
                    

                }
                else
                {
                    throw new NrmAfiliadoRepetidoException("Ya existe un cliente con el mismo numero de afiliado");
                }
                
            }
             
            return e;
        }
        #endregion
    }
}

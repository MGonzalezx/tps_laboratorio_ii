using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml.Serialization;
using Entidades;
using System.Xml;

namespace MainEmpresa
{
    public partial class FrmEmpresa : Form
    {
        #region Atributos

        private static string rutaArchivo;
        private static string rutaArchivoXml;
        private Empresa empresa;
        private Archivos archivos;

        private OpenFileDialog openFileDialog;
        private SaveFileDialog saveFileDialog;
        #endregion

        #region Propiedades

        /// <summary>
        /// Establece o devuelve el valor de la ruta del archivo
        /// </summary>
        private string RutaArchivo
        {
            get
            {
                return rutaArchivo;
            }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    rutaArchivo = value;
                }
            }
        }

        /// <summary>
        /// Establece o devuelve el valor de la ruta del archivo XML
        /// </summary>
        private string RutaArchivoXml
        {
            get
            {
                return rutaArchivoXml;
            }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    rutaArchivoXml = value;
                }
            }
        }
        #endregion

        #region Constructores

        /// <summary>
        /// Constructor estático del formulario en donde se va a inicializar la ruta del archivo XML
        /// Su ruta default será AppDomain.CurrentDomain.BaseDirectory;
        /// C:\.....\Gonzalez.Martin.2A.TPFinal\MainEmpresa\bin\Debug\net5.0-windows
        /// </summary>
        static FrmEmpresa()
        {
            
            string rutaBaseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            const string nombreArchivoXml = "listaEmpresa.xml";
            rutaArchivoXml = Path.Combine(rutaBaseDirectory, nombreArchivoXml);
            



        }

        /// <summary>
        /// Constructor del formulario en donde se inicializarán:
        /// La empresa para trabajar en este form.
        /// Los OpenFileDialog y SaveFileDialog.
        /// El filtro para guardar en XML los archivos.
        /// El Evento que trabaja con los errores que puedan ocurrir en la base de datos.
        /// </summary>
        public FrmEmpresa()
        {
            InitializeComponent();
            this.empresa = new Empresa();
            this.archivos = new Archivos();
            openFileDialog = new OpenFileDialog();
            saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Archivo XML|*.xml";
            ClienteDAO.ErrorBaseDeDatos += new EventHandler(this.ErrorBaseDeDatos);
           
            
        }
        #endregion

        #region Métodos

       
        private void FrmEmpresa_Load(object sender, EventArgs e)
        {
           
            CargarListaAlmacenada();
            RefrescarLista();
            
        }


        /// <summary>
        /// Refrescará la listbox (ltbClientes) con los datos más recientes
        /// </summary>
        private void RefrescarLista()
        {
            ltbClientes.DataSource = null;
            ltbClientes.DataSource = empresa.Clientes;
        }


 

        /// <summary>
        /// Permitirá elegir el archivo a abrir. Preferiblemente XML
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                archivos.LeerArchivoXML(rutaArchivoXml, empresa.Clientes);
                
            }
        }

        
        /// <summary>
        /// Permitirá guardar el archivo xml, si este no existe, permitirá al usuario elegir una ruta.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!File.Exists(RutaArchivoXml))
            {
                RutaArchivoXml = SeleccionarUbicacionGuardado();
            }

            archivos.GuardarArchivoXML(RutaArchivoXml, empresa.Clientes);
        }

        /// <summary>
        /// Permitirá elegir al usuario una ruta para guardar el archivo
        /// </summary>
        /// <returns>Retorna la ruta si el resultado es OK, no retornar nada si se cancela</returns>
        private string SeleccionarUbicacionGuardado()
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                return saveFileDialog.FileName;
            }

            return string.Empty;
        }

       
       


        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AgregarElemento();
        }

        /// <summary>
        /// Agrega el elemento con sus datos cargadaos (desde FrmAltaModificacion) a la lista clientes de la empresa y
        /// a la base de datos.
        /// Los datos luego serán almacenados y la listbox (ltbClientes) refrescada con los datos más recientes
        /// Se informará el nuevo estado del cliente.
        /// </summary>
        private void AgregarElemento()
        {
            FrmAltaModificacion frmAltaModificacion = new FrmAltaModificacion("Agregar Cliente", string.Empty, string.Empty, string.Empty, string.Empty, "Agregar");
            
            frmAltaModificacion.ShowDialog();
            
            if (frmAltaModificacion.DialogResult == DialogResult.OK)
            {
                Cliente miCliente = new Cliente(frmAltaModificacion.Nombre, frmAltaModificacion.Apellido, frmAltaModificacion.Requerimiento, Convert.ToInt32( frmAltaModificacion.NroAfiliado));

                try
                {


                    empresa += miCliente;

                    empresa.Clientes.Add(miCliente);

                    ClienteDAO.Guardar(miCliente);

                }
                catch (Exception ex)
                {

                    MostrarMensajeDeError(ex);
                }
                miCliente.InformaEstado += new Cliente.DelegadoEstado(this.cliente_InformaEstado);
                AlmacenarCambios();
                RefrescarLista();
            }
        }

        /// <summary>
        /// Almacena los datos que se van efectuando
        /// 
        /// </summary>
        private void AlmacenarCambios()
        {
            using (StreamWriter streamWriter = new StreamWriter(rutaArchivoXml))
            {
                try
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(empresa.Clientes.GetType());
                    xmlSerializer.Serialize(streamWriter, empresa.Clientes);
                }
                catch (Exception ex)
                {
                    MostrarMensajeDeError(ex);
                }
            }

            

        }

        /// <summary>
        /// Carga la lista (si es que exixte) y se usará la función para aplicarla en el load del formulario y poder seguir trabajando con el ultimo 
        /// archivo abierto, aun si se cerró la aplicación.
        /// </summary>
        private void CargarListaAlmacenada()
        {
            if (File.Exists(rutaArchivoXml))
            {
                using (StreamReader streamReader = new StreamReader(rutaArchivoXml))
                {
                    try
                    {
                        XmlSerializer xmlSerializer = new XmlSerializer(empresa.Clientes.GetType());
                        empresa.Clientes = xmlSerializer.Deserialize(streamReader) as List<Cliente>;
                    }
                    catch (Exception ex)
                    {
                        MostrarMensajeDeError(ex);
                    }
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            EliminarElemento();
        }

        /// <summary>
        /// Se eliminará el elemento seleccionado de la listbox (ltbClientes)
        /// Si no se selecciona ningun elemento, aparecerá una alerta
        /// </summary>
        private void EliminarElemento()
        {
            Cliente objetoSeleccionado = ltbClientes.SelectedItem as Cliente;

            if (objetoSeleccionado is not null)
            {
                empresa.Clientes.Remove(objetoSeleccionado);
                ClienteDAO.Eliminar(objetoSeleccionado.NumeroAfiliado);
                AlmacenarCambios();
                RefrescarLista();
            }
            else
            {
                MessageBox.Show("Debe seleccionar un elemento de la lista.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

       

        /// <summary>
        /// Si el usuario no quiere trabajar en la ruta default del XML, puede usar el "Guardar Como..."
        /// para cambiar la ruta del archivo en el que está trabajando
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void guardarComoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                 
                RutaArchivoXml = SeleccionarUbicacionGuardado();
                

                archivos.GuardarArchivoXML(RutaArchivoXml, empresa.Clientes);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            ModificarElemento();
        }

        /// <summary>
        /// Se modificará el elemento seleccionado de la listbox (ltbClientes).
        /// Tambien se modificará dentro de la base de datos.
        /// Si no se selecciona ningun elemento, aparecerá una alerta
        /// </summary>
        private void ModificarElemento()
        {
            Cliente clienteSeleccionado = ltbClientes.SelectedItem as Cliente;


            if (clienteSeleccionado is not null)
            {
                FrmAltaModificacion frmAltaModificacion = new FrmAltaModificacion("Modificar Cliente", clienteSeleccionado, "Aceptar");
                frmAltaModificacion.ShowDialog();

                if (frmAltaModificacion.DialogResult == DialogResult.OK)
                {
                    int indice = empresa.Clientes.IndexOf(clienteSeleccionado);

                   

                    empresa.Clientes[indice].Nombre = frmAltaModificacion.Nombre;
                    empresa.Clientes[indice].Apellido = frmAltaModificacion.Apellido;
                    empresa.Clientes[indice].NumeroAfiliado = Convert.ToInt32(frmAltaModificacion.NroAfiliado);
                    empresa.Clientes[indice].Requerimiento = frmAltaModificacion.Requerimiento;

                    ClienteDAO.Modificar(empresa.Clientes[indice], empresa.Clientes[indice].NumeroAfiliado);

                    AlmacenarCambios();
                    RefrescarLista();
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un cliente de la lista.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }



        }

        /// <summary>
        /// Permitirá al usuario exportar (guardar) su lista en formato txt
        /// en la ruta que el usuario elija
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExportar_Click(object sender, EventArgs e)
        {
            if (!File.Exists(RutaArchivo))
            {
                saveFileDialog.Filter = "Archivo de texto| *.txt";
                RutaArchivo = SeleccionarUbicacionGuardado();
            }

            foreach (Object item in ltbClientes.Items)
            {
                archivos.GuardarArchivo(RutaArchivo,item.ToString());
            }
            
        }

      

        /// <summary>
        /// Método para mostrar en un MessageBox.Show los errores que puedan ocurrir al momento de utilizar la aplicación
        /// </summary>
        /// <param name="ex"></param>
        private void MostrarMensajeDeError(Exception ex)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(ex.Message);
            stringBuilder.AppendLine();
            //stringBuilder.AppendLine(ex.StackTrace);

            MessageBox.Show(stringBuilder.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Muestra la informacion al producirse un error en la base de datos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ErrorBaseDeDatos(object sender, EventArgs e)
        {
            MessageBox.Show(sender.ToString(), "ERROR CON LA BASE DE DATOS");
        }

        private void btnModoSQL_Click(object sender, EventArgs e)
        {
            FrnEmpresaDAO frnEmpresaDAO = new FrnEmpresaDAO();
            frnEmpresaDAO.ShowDialog();
        }



        /// <summary>
        /// Manejador del informe de estados de paquete
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cliente_InformaEstado(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                Cliente.DelegadoEstado d = new Cliente.DelegadoEstado(cliente_InformaEstado);
                this.Invoke(d, new object[] { sender, e });
            }
            else
            {
                this.ActualizarEstados();
            }

        }


        /// <summary>
        /// Actualiza los list box para reflejar el estado del cliente ingresado.
        /// </summary>
        private void ActualizarEstados()
        {
            
            this.ltbClientesRegistrados.Items.Clear();
            foreach (Cliente cliente in this.empresa.Clientes)
            {

                if (cliente.Estado == Cliente.EEstado.Resgistrado)
                {
                    
                    this.ltbClientesRegistrados.Items.Add(cliente);
                }
                
            }
        }


        #endregion
    }
}

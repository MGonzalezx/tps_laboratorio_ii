using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MainEmpresa
{
    public partial class FrmAltaModificacion : Form
    {

        #region Propiedades

        /// <summary>
        /// Devuelve el valor del txtNombre
        /// </summary>
        public string Nombre
        {
            get
            {
                return txtNombre.Text;
            }
        }

        /// <summary>
        /// Devuelve el valor del txtApellido
        /// </summary>
        public string Apellido
        {
            get
            {
                return txtApellido.Text;
            }
        }

        /// <summary>
        /// Devuelve el valor del txtNrmAfiliado
        /// </summary>
        public string NroAfiliado
        {
            get
            {
                return txtNrmAfiliado.Text;
            }
        }

        /// <summary>
        /// Devuelve el valor del txtRequerimiento
        /// </summary>
        public string Requerimiento
        {
            get
            {
                return txtRequerimiento.Text;
            }
        }
        #endregion

        #region Constructores

        /// <summary>
        /// Constructor de FrmAltaModificacion.
        /// Se va a poder escribir dentro de txtNrmAfiliado SOLO si se agregar un cliente.
        /// Si se modifica un cliente, el constructor se va a encargar de que no podamos modificar el numero de afiliado.
        /// </summary>
        /// <param name="titulo">Titulo del form</param>
        /// <param name="txtNombreObtenido">Nombre del cliente</param>
        /// <param name="txtApellidoObtenido">Apellido del cliente</param>
        /// <param name="txtNrmAfiliadoObtenido">Numero afiliado del cliente</param>
        /// <param name="txtRequerimientoObtenido">El requerimiento del cliente</param>
        /// <param name="btnConfirmarText">Texto del boton para confirmar</param>
        public FrmAltaModificacion(string titulo, string txtNombreObtenido, string txtApellidoObtenido, string txtNrmAfiliadoObtenido, string txtRequerimientoObtenido, string btnConfirmarText)
        {
            

            InitializeComponent();
            if (titulo != "Modificar Cliente")
            {
                txtNrmAfiliado.ReadOnly = false;
            }
            else
            {
                txtNrmAfiliado.ReadOnly = true;
            }
            Text = titulo;
            txtNombre.Text = txtNombreObtenido;
            txtApellido.Text = txtApellidoObtenido;
            txtNrmAfiliado.Text = txtNrmAfiliadoObtenido;
            txtRequerimiento.Text = txtRequerimientoObtenido;
            btnConfirmar.Text = btnConfirmarText;
        }

        /// <summary>
        /// Contructor de FrmAltaModificacion
        /// </summary>
        /// <param name="titulo">Titulo del form</param>
        /// <param name="itemAEditar">Parámetro Cliente</param>
        /// <param name="btnConfirmarText">Texto del boton para confirmar</param>
        public FrmAltaModificacion(string titulo, Cliente itemAEditar, string btnConfirmarText) : this(titulo, itemAEditar.Nombre, itemAEditar.Apellido, itemAEditar.NumeroAfiliado.ToString(), itemAEditar.Requerimiento, btnConfirmarText)
        {
            
        }
        #endregion

        #region Métodos

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            Confirmar();
        }

        /// <summary>
        /// Validará que los 4 textboxs (txtNombre, txtApellido, txtNrmAfiliado y txtRequerimiento) no estén vacios.
        /// Si lo estan, aparecerá un alerta alertando al usuario.
        /// Si todos los textbox estan llenos y el DialogResult va a estar OK y se cerrará el formulario
        /// </summary>
        private void Confirmar()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtApellido.Text) || string.IsNullOrWhiteSpace(txtNrmAfiliado.Text) || string.IsNullOrWhiteSpace(txtRequerimiento.Text))
            {
                MessageBox.Show("Ninguno de los 4 textos pueden estar vacíos", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Cancelar();
        }

        /// <summary>
        /// Se cancelará la suba / modificación de datos y se cerrará el form
        /// </summary>
        private void Cancelar()
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        /// <summary>
        /// Validara que en txtNombre no se puedan escribir numeros
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("Este cuadro de texto solo acepta letras");
            }
        }

       

        /// <summary>
        /// Validara que en txtApellido no se puedan escribir numeros
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("Este cuadro de texto solo acepta letras");
            }
        }

        /// <summary>
        /// Validara que en txtRequerimiento no se puedan escribir numeros
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtRequerimiento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("Este cuadro de texto solo acepta letras");
            }
        }
        #endregion


        /// <summary>
        /// Validara que en txtNrmAfiliado no se puedan escribir letras
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtNrmAfiliado_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("Este cuadro de texto solo acepta numeros");
            }
        }
    }
}

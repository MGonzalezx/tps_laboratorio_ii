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
    public partial class FrnEmpresaDAO : Form
    {
        public FrnEmpresaDAO()
        {
            InitializeComponent();
        }


        
        private void FrnEmpresaDAO_Load(object sender, EventArgs e)
        {
            RefrescarDataGrid();
        }

        /// <summary>
        /// Refrescará el datagrid con los datos más recientes
        /// </summary>
        private void RefrescarDataGrid()
        {
            dtgvListaClientes.DataSource = ClienteDAO.Leer();
            dtgvListaClientes.Refresh();
            dtgvListaClientes.Update();
        }

        

       
    }
}

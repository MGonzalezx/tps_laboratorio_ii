using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Windows.Forms;

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            InitializeComponent();
            cmbOperador.Items.Add(" ");
            cmbOperador.Items.Add("+");
            cmbOperador.Items.Add("-");
            cmbOperador.Items.Add("*");
            cmbOperador.Items.Add("/");
            cmbOperador.SelectedIndex= cmbOperador.FindString(" ");
            txtNumero1.Text = "0";
            txtNumero2.Text = "0";


        }

        private void FormCalculadora_Load(object sender, EventArgs e)
        {
            this.Limpiar();
        }

        private void Limpiar()
        {
            txtNumero1.Text = string.Empty;
            txtNumero2.Text = string.Empty;
            cmbOperador.Text = string.Empty;
            lblResultado.Text = string.Empty;
            lstOperaciones.Text = string.Empty;
        }

        private static double Operar(string numero1, string numero2, string operador)
        {
            
            Operando numeroUno = new Operando(numero1);
            Operando numeroDos = new Operando(numero2);
            char miOperador = Convert.ToChar(operador);
            double resultado = Calculadora.Operar(numeroUno, numeroDos, miOperador);
            return resultado;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {

          
            this.Close();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            double calcular = FormCalculadora.Operar(txtNumero1.Text, txtNumero2.Text, cmbOperador.Text);
            lblResultado.Text = calcular.ToString();

           

            lstOperaciones.Items.Add($"{this.txtNumero1.Text} {this.cmbOperador.Text} {this.txtNumero2.Text} = {this.lblResultado.Text}");
            this.Controls.Add(lstOperaciones);
            //lstOperaciones.Text = $"{this.txtNumero1.Text}, {this.cmbOperador.Text}, {this.txtNumero2.Text}";
        }

        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {

            Operando miOperando = new Operando(lblResultado.Text);

            lblResultado.Text = miOperando.DecimalBinario(lblResultado.Text);

            


        }

        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {

            Operando miOperando = new Operando(lblResultado.Text);

            lblResultado.Text = miOperando.BinarioDecimal(lblResultado.Text);

            
        }

        private void FormCalculadora_FormClosing(object sender, FormClosingEventArgs e)
        {

            if(e.CloseReason == CloseReason.UserClosing)
            {
               DialogResult resultado = MessageBox.Show("¿Está seguro de querer salir?", "Salir", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (resultado != DialogResult.Yes)
                {
                    e.Cancel = true;
                }

                
            }

            
        }
    }
}

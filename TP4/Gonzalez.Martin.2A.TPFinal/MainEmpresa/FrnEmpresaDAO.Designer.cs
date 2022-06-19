
namespace MainEmpresa
{
    partial class FrnEmpresaDAO
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dtgvListaClientes = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvListaClientes)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgvListaClientes
            // 
            this.dtgvListaClientes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgvListaClientes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgvListaClientes.BackgroundColor = System.Drawing.SystemColors.AppWorkspace;
            this.dtgvListaClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvListaClientes.Location = new System.Drawing.Point(42, 12);
            this.dtgvListaClientes.Name = "dtgvListaClientes";
            this.dtgvListaClientes.RowTemplate.Height = 25;
            this.dtgvListaClientes.Size = new System.Drawing.Size(860, 403);
            this.dtgvListaClientes.TabIndex = 0;
            // 
            // FrnEmpresaDAO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(954, 435);
            this.Controls.Add(this.dtgvListaClientes);
            this.Name = "FrnEmpresaDAO";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrnEmpresaDAO";
            this.Load += new System.EventHandler(this.FrnEmpresaDAO_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvListaClientes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgvListaClientes;
    }
}
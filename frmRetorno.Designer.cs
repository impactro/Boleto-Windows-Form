namespace BoletoForm2
{
    partial class frmRetorno
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
            this.txtRetorno = new System.Windows.Forms.TextBox();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnRetorno = new System.Windows.Forms.Button();
            this.gvREG = new System.Windows.Forms.DataGridView();
            this.ofd = new System.Windows.Forms.OpenFileDialog();
            this.gvTB = new System.Windows.Forms.DataGridView();
            this.txtOut = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.gvREG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTB)).BeginInit();
            this.SuspendLayout();
            // 
            // txtRetorno
            // 
            this.txtRetorno.AcceptsReturn = true;
            this.txtRetorno.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRetorno.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRetorno.Location = new System.Drawing.Point(12, 53);
            this.txtRetorno.Multiline = true;
            this.txtRetorno.Name = "txtRetorno";
            this.txtRetorno.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtRetorno.Size = new System.Drawing.Size(720, 123);
            this.txtRetorno.TabIndex = 5;
            this.txtRetorno.Text = "Clique em \"Carregar\" para ler um arquivo de RETORNO CNAB,\r\ne depois clique em \"Pr" +
    "ecessar Retorno\" para ver os dados do arquivo\r\n";
            this.txtRetorno.WordWrap = false;
            // 
            // btnLoad
            // 
            this.btnLoad.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoad.Location = new System.Drawing.Point(12, 12);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(149, 35);
            this.btnLoad.TabIndex = 6;
            this.btnLoad.Text = "Carregar";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnRetorno
            // 
            this.btnRetorno.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRetorno.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRetorno.Location = new System.Drawing.Point(567, 12);
            this.btnRetorno.Name = "btnRetorno";
            this.btnRetorno.Size = new System.Drawing.Size(163, 35);
            this.btnRetorno.TabIndex = 6;
            this.btnRetorno.Text = "Processar Retorno";
            this.btnRetorno.UseVisualStyleBackColor = true;
            this.btnRetorno.Click += new System.EventHandler(this.btnRetorno_Click);
            // 
            // gvREG
            // 
            this.gvREG.AllowUserToAddRows = false;
            this.gvREG.AllowUserToDeleteRows = false;
            this.gvREG.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gvREG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvREG.Location = new System.Drawing.Point(12, 285);
            this.gvREG.Name = "gvREG";
            this.gvREG.ReadOnly = true;
            this.gvREG.Size = new System.Drawing.Size(718, 113);
            this.gvREG.TabIndex = 7;
            // 
            // gvTB
            // 
            this.gvTB.AllowUserToAddRows = false;
            this.gvTB.AllowUserToDeleteRows = false;
            this.gvTB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gvTB.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvTB.Location = new System.Drawing.Point(12, 404);
            this.gvTB.Name = "gvTB";
            this.gvTB.ReadOnly = true;
            this.gvTB.Size = new System.Drawing.Size(718, 103);
            this.gvTB.TabIndex = 9;
            // 
            // txtOut
            // 
            this.txtOut.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOut.Location = new System.Drawing.Point(12, 179);
            this.txtOut.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtOut.Multiline = true;
            this.txtOut.Name = "txtOut";
            this.txtOut.ReadOnly = true;
            this.txtOut.Size = new System.Drawing.Size(720, 104);
            this.txtOut.TabIndex = 10;
            // 
            // frmRetorno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(681, 450);
            this.Controls.Add(this.txtOut);
            this.Controls.Add(this.gvTB);
            this.Controls.Add(this.gvREG);
            this.Controls.Add(this.btnRetorno);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.txtRetorno);
            this.MinimumSize = new System.Drawing.Size(495, 284);
            this.Name = "frmRetorno";
            this.Text = "frmRetorno";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.gvREG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTB)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtRetorno;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnRetorno;
        private System.Windows.Forms.DataGridView gvREG;
        private System.Windows.Forms.OpenFileDialog ofd;
        private System.Windows.Forms.DataGridView gvTB;
        private System.Windows.Forms.TextBox txtOut;
    }
}
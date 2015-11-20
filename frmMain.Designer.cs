namespace BoletoForm2
{
    partial class frmMain
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
            this.btnBasico = new System.Windows.Forms.Button();
            this.btnCustom = new System.Windows.Forms.Button();
            this.btnCarne = new System.Windows.Forms.Button();
            this.btnRemessa = new System.Windows.Forms.Button();
            this.btnRetorno = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnBasico
            // 
            this.btnBasico.Location = new System.Drawing.Point(12, 12);
            this.btnBasico.Name = "btnBasico";
            this.btnBasico.Size = new System.Drawing.Size(253, 23);
            this.btnBasico.TabIndex = 0;
            this.btnBasico.Text = "Exemplo Basico / Serie de Boletos";
            this.btnBasico.UseVisualStyleBackColor = true;
            this.btnBasico.Click += new System.EventHandler(this.btnBasico_Click);
            // 
            // btnCustom
            // 
            this.btnCustom.Location = new System.Drawing.Point(12, 41);
            this.btnCustom.Name = "btnCustom";
            this.btnCustom.Size = new System.Drawing.Size(253, 23);
            this.btnCustom.TabIndex = 0;
            this.btnCustom.Text = "Exemplo de Customização";
            this.btnCustom.UseVisualStyleBackColor = true;
            this.btnCustom.Click += new System.EventHandler(this.btnCustom_Click);
            // 
            // btnCarne
            // 
            this.btnCarne.Location = new System.Drawing.Point(12, 70);
            this.btnCarne.Name = "btnCarne";
            this.btnCarne.Size = new System.Drawing.Size(253, 23);
            this.btnCarne.TabIndex = 0;
            this.btnCarne.Text = "Exemplo de Customização em formato Carnet";
            this.btnCarne.UseVisualStyleBackColor = true;
            this.btnCarne.Click += new System.EventHandler(this.btnCarne_Click);
            // 
            // btnRemessa
            // 
            this.btnRemessa.Location = new System.Drawing.Point(12, 99);
            this.btnRemessa.Name = "btnRemessa";
            this.btnRemessa.Size = new System.Drawing.Size(253, 23);
            this.btnRemessa.TabIndex = 1;
            this.btnRemessa.Text = "Exemplo de Remessa CNAB";
            this.btnRemessa.UseVisualStyleBackColor = true;
            this.btnRemessa.Click += new System.EventHandler(this.btnRemessa_Click);
            // 
            // btnRetorno
            // 
            this.btnRetorno.Location = new System.Drawing.Point(12, 128);
            this.btnRetorno.Name = "btnRetorno";
            this.btnRetorno.Size = new System.Drawing.Size(253, 23);
            this.btnRetorno.TabIndex = 2;
            this.btnRetorno.Text = "Exemplo de Retorno CNAB";
            this.btnRetorno.UseVisualStyleBackColor = true;
            this.btnRetorno.Click += new System.EventHandler(this.btnRetorno_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(277, 162);
            this.Controls.Add(this.btnRetorno);
            this.Controls.Add(this.btnRemessa);
            this.Controls.Add(this.btnCarne);
            this.Controls.Add(this.btnCustom);
            this.Controls.Add(this.btnBasico);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Exemplo de Geração de Boletos .Net 2.0 C#";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnBasico;
        private System.Windows.Forms.Button btnCustom;
        private System.Windows.Forms.Button btnCarne;
        private System.Windows.Forms.Button btnRemessa;
        private System.Windows.Forms.Button btnRetorno;
    }
}
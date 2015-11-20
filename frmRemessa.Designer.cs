namespace BoletoForm2
{
    partial class frmRemessa
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
            this.txtRemessa = new System.Windows.Forms.TextBox();
            this.btnGerar = new System.Windows.Forms.Button();
            this.txtQTD = new System.Windows.Forms.NumericUpDown();
            this.txtVencimento = new System.Windows.Forms.MaskedTextBox();
            this.txtNossoNumero = new System.Windows.Forms.NumericUpDown();
            this.txtValor = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.chkDump = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtLote = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.txtQTD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNossoNumero)).BeginInit();
            this.SuspendLayout();
            // 
            // txtRemessa
            // 
            this.txtRemessa.AcceptsReturn = true;
            this.txtRemessa.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRemessa.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRemessa.Location = new System.Drawing.Point(24, 98);
            this.txtRemessa.Margin = new System.Windows.Forms.Padding(6);
            this.txtRemessa.Multiline = true;
            this.txtRemessa.Name = "txtRemessa";
            this.txtRemessa.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtRemessa.Size = new System.Drawing.Size(1436, 483);
            this.txtRemessa.TabIndex = 4;
            this.txtRemessa.Text = "Informe os parametros acima e clique em \"Gerar Remessa\"";
            this.txtRemessa.WordWrap = false;
            // 
            // btnGerar
            // 
            this.btnGerar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGerar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGerar.Location = new System.Drawing.Point(1184, 19);
            this.btnGerar.Margin = new System.Windows.Forms.Padding(6);
            this.btnGerar.Name = "btnGerar";
            this.btnGerar.Size = new System.Drawing.Size(280, 67);
            this.btnGerar.TabIndex = 5;
            this.btnGerar.Text = "Gerar Remessa";
            this.btnGerar.UseVisualStyleBackColor = true;
            this.btnGerar.Click += new System.EventHandler(this.btnGerar_Click);
            // 
            // txtQTD
            // 
            this.txtQTD.Location = new System.Drawing.Point(636, 48);
            this.txtQTD.Margin = new System.Windows.Forms.Padding(6);
            this.txtQTD.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.txtQTD.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtQTD.Name = "txtQTD";
            this.txtQTD.Size = new System.Drawing.Size(84, 31);
            this.txtQTD.TabIndex = 6;
            this.txtQTD.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // txtVencimento
            // 
            this.txtVencimento.Location = new System.Drawing.Point(324, 48);
            this.txtVencimento.Margin = new System.Windows.Forms.Padding(6);
            this.txtVencimento.Mask = "00/00/0000";
            this.txtVencimento.Name = "txtVencimento";
            this.txtVencimento.Size = new System.Drawing.Size(154, 31);
            this.txtVencimento.TabIndex = 7;
            this.txtVencimento.Text = "10122015";
            this.txtVencimento.ValidatingType = typeof(System.DateTime);
            // 
            // txtNossoNumero
            // 
            this.txtNossoNumero.Location = new System.Drawing.Point(152, 48);
            this.txtNossoNumero.Margin = new System.Windows.Forms.Padding(6);
            this.txtNossoNumero.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.txtNossoNumero.Name = "txtNossoNumero";
            this.txtNossoNumero.Size = new System.Drawing.Size(154, 31);
            this.txtNossoNumero.TabIndex = 9;
            this.txtNossoNumero.Value = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            // 
            // txtValor
            // 
            this.txtValor.Location = new System.Drawing.Point(494, 48);
            this.txtValor.Margin = new System.Windows.Forms.Padding(6);
            this.txtValor.Name = "txtValor";
            this.txtValor.Size = new System.Drawing.Size(126, 31);
            this.txtValor.TabIndex = 10;
            this.txtValor.Text = "987,65";
            this.txtValor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(146, 17);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 25);
            this.label1.TabIndex = 11;
            this.label1.Text = "Nosso Numero:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(630, 17);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(141, 25);
            this.label2.TabIndex = 12;
            this.label2.Text = "Qtd Exemplo:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(488, 17);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 25);
            this.label3.TabIndex = 13;
            this.label3.Text = "Valor:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(318, 17);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(131, 25);
            this.label4.TabIndex = 14;
            this.label4.Text = "Vencimento:";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(24, 590);
            this.label5.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(1440, 88);
            this.label5.TabIndex = 15;
            this.label5.Text = "Exemplo configurado para Bradesco\r\nEdite o código fonte caso queira usar outro Ba" +
    "nco";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chkDump
            // 
            this.chkDump.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkDump.AutoSize = true;
            this.chkDump.ForeColor = System.Drawing.Color.Blue;
            this.chkDump.Location = new System.Drawing.Point(1012, 54);
            this.chkDump.Margin = new System.Windows.Forms.Padding(6);
            this.chkDump.Name = "chkDump";
            this.chkDump.Size = new System.Drawing.Size(160, 29);
            this.chkDump.TabIndex = 16;
            this.chkDump.Text = "Exibir Dump";
            this.chkDump.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(24, 17);
            this.label6.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 25);
            this.label6.TabIndex = 18;
            this.label6.Text = "Lote:";
            // 
            // txtLote
            // 
            this.txtLote.Location = new System.Drawing.Point(30, 46);
            this.txtLote.Margin = new System.Windows.Forms.Padding(6);
            this.txtLote.Name = "txtLote";
            this.txtLote.Size = new System.Drawing.Size(106, 31);
            this.txtLote.TabIndex = 17;
            this.txtLote.Text = "333444";
            this.txtLote.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // frmRemessa
            // 
            this.AcceptButton = this.btnGerar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1488, 696);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtLote);
            this.Controls.Add(this.chkDump);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtValor);
            this.Controls.Add(this.txtNossoNumero);
            this.Controls.Add(this.txtVencimento);
            this.Controls.Add(this.txtQTD);
            this.Controls.Add(this.btnGerar);
            this.Controls.Add(this.txtRemessa);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MinimumSize = new System.Drawing.Size(974, 511);
            this.Name = "frmRemessa";
            this.Text = "Geração de Remessa CNAB";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.txtQTD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNossoNumero)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtRemessa;
        private System.Windows.Forms.Button btnGerar;
        private System.Windows.Forms.NumericUpDown txtQTD;
        private System.Windows.Forms.MaskedTextBox txtVencimento;
        private System.Windows.Forms.NumericUpDown txtNossoNumero;
        private System.Windows.Forms.TextBox txtValor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chkDump;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtLote;
    }
}
namespace BoletoForm2
{
    partial class frmCustromizado
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
            this.btnImprimir = new System.Windows.Forms.Button();
            this.lblIPTE = new System.Windows.Forms.Label();
            this.lblValor = new System.Windows.Forms.Label();
            this.lblVencimento = new System.Windows.Forms.Label();
            this.picCodBaras = new System.Windows.Forms.PictureBox();
            this.lblNossoNumero = new System.Windows.Forms.Label();
            this.picFundo = new System.Windows.Forms.PictureBox();
            this.lblAvalista = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picCodBaras)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFundo)).BeginInit();
            this.SuspendLayout();
            // 
            // btnImprimir
            // 
            this.btnImprimir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImprimir.Location = new System.Drawing.Point(481, 383);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(150, 40);
            this.btnImprimir.TabIndex = 4;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // lblIPTE
            // 
            this.lblIPTE.BackColor = System.Drawing.Color.White;
            this.lblIPTE.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIPTE.Location = new System.Drawing.Point(232, 11);
            this.lblIPTE.Name = "lblIPTE";
            this.lblIPTE.Size = new System.Drawing.Size(399, 27);
            this.lblIPTE.TabIndex = 5;
            this.lblIPTE.Text = "IPTE";
            this.lblIPTE.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblValor
            // 
            this.lblValor.BackColor = System.Drawing.Color.Silver;
            this.lblValor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValor.Location = new System.Drawing.Point(513, 138);
            this.lblValor.Name = "lblValor";
            this.lblValor.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblValor.Size = new System.Drawing.Size(118, 13);
            this.lblValor.TabIndex = 6;
            this.lblValor.Text = "Valor";
            this.lblValor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblVencimento
            // 
            this.lblVencimento.BackColor = System.Drawing.Color.Silver;
            this.lblVencimento.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVencimento.Location = new System.Drawing.Point(513, 53);
            this.lblVencimento.Name = "lblVencimento";
            this.lblVencimento.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblVencimento.Size = new System.Drawing.Size(118, 14);
            this.lblVencimento.TabIndex = 7;
            this.lblVencimento.Text = "Vencimento";
            this.lblVencimento.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // picCodBaras
            // 
            this.picCodBaras.Location = new System.Drawing.Point(1, 384);
            this.picCodBaras.Name = "picCodBaras";
            this.picCodBaras.Size = new System.Drawing.Size(397, 50);
            this.picCodBaras.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picCodBaras.TabIndex = 8;
            this.picCodBaras.TabStop = false;
            // 
            // lblNossoNumero
            // 
            this.lblNossoNumero.BackColor = System.Drawing.Color.White;
            this.lblNossoNumero.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNossoNumero.Location = new System.Drawing.Point(513, 108);
            this.lblNossoNumero.Name = "lblNossoNumero";
            this.lblNossoNumero.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblNossoNumero.Size = new System.Drawing.Size(118, 15);
            this.lblNossoNumero.TabIndex = 6;
            this.lblNossoNumero.Text = "NossoNumero";
            this.lblNossoNumero.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // picFundo
            // 
            this.picFundo.Image = global::BoletoForm2.Properties.Resources.BoletoCustomizado;
            this.picFundo.Location = new System.Drawing.Point(1, 1);
            this.picFundo.Name = "picFundo";
            this.picFundo.Size = new System.Drawing.Size(641, 433);
            this.picFundo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picFundo.TabIndex = 9;
            this.picFundo.TabStop = false;
            // 
            // lblAvalista
            // 
            this.lblAvalista.BackColor = System.Drawing.Color.White;
            this.lblAvalista.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAvalista.Location = new System.Drawing.Point(252, 340);
            this.lblAvalista.Name = "lblAvalista";
            this.lblAvalista.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblAvalista.Size = new System.Drawing.Size(379, 18);
            this.lblAvalista.TabIndex = 10;
            this.lblAvalista.Text = "Avalista";
            this.lblAvalista.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmCustromizado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(643, 435);
            this.Controls.Add(this.lblAvalista);
            this.Controls.Add(this.picCodBaras);
            this.Controls.Add(this.lblVencimento);
            this.Controls.Add(this.lblNossoNumero);
            this.Controls.Add(this.lblValor);
            this.Controls.Add(this.lblIPTE);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.picFundo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmCustromizado";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Boleto Customizado por Imagem";
            this.Load += new System.EventHandler(this.frmCustromizado_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picCodBaras)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFundo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Label lblIPTE;
        private System.Windows.Forms.Label lblValor;
        private System.Windows.Forms.Label lblVencimento;
        private System.Windows.Forms.PictureBox picCodBaras;
        private System.Windows.Forms.Label lblNossoNumero;
        private System.Windows.Forms.PictureBox picFundo;
        private System.Windows.Forms.Label lblAvalista;
    }
}
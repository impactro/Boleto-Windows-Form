using Impactro.Cobranca;
using Impactro.WindowsControls;

namespace BoletoForm2
{
    partial class frmBasico
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
            this.btnPrintTabela = new System.Windows.Forms.Button();
            this.chkPreview = new System.Windows.Forms.CheckBox();
            this.chkCarne = new System.Windows.Forms.CheckBox();
            this.chkRecibo = new System.Windows.Forms.CheckBox();
            this.chkExtra = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkLogo = new System.Windows.Forms.CheckBox();
            this.nmEscala = new System.Windows.Forms.NumericUpDown();
            this.chkEscala = new System.Windows.Forms.CheckBox();
            this.chkMaisEspaco = new System.Windows.Forms.CheckBox();
            this.bltFrm = new Impactro.WindowsControls.BoletoForm();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmEscala)).BeginInit();
            this.SuspendLayout();
            // 
            // btnImprimir
            // 
            this.btnImprimir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImprimir.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImprimir.Location = new System.Drawing.Point(408, 25);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(157, 29);
            this.btnImprimir.TabIndex = 3;
            this.btnImprimir.Text = "Imprimir Único";
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // btnPrintTabela
            // 
            this.btnPrintTabela.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrintTabela.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrintTabela.Location = new System.Drawing.Point(571, 25);
            this.btnPrintTabela.Name = "btnPrintTabela";
            this.btnPrintTabela.Size = new System.Drawing.Size(157, 29);
            this.btnPrintTabela.TabIndex = 3;
            this.btnPrintTabela.Text = "Imprimir Tabelas";
            this.btnPrintTabela.UseVisualStyleBackColor = true;
            this.btnPrintTabela.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // chkPreview
            // 
            this.chkPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkPreview.AutoSize = true;
            this.chkPreview.BackColor = System.Drawing.SystemColors.Control;
            this.chkPreview.Checked = true;
            this.chkPreview.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPreview.Location = new System.Drawing.Point(513, 7);
            this.chkPreview.Name = "chkPreview";
            this.chkPreview.Size = new System.Drawing.Size(140, 17);
            this.chkPreview.TabIndex = 4;
            this.chkPreview.Text = "Pre-Visualizar Impressão";
            this.chkPreview.UseVisualStyleBackColor = false;
            // 
            // chkCarne
            // 
            this.chkCarne.AutoSize = true;
            this.chkCarne.Location = new System.Drawing.Point(143, 5);
            this.chkCarne.Margin = new System.Windows.Forms.Padding(2);
            this.chkCarne.Name = "chkCarne";
            this.chkCarne.Size = new System.Drawing.Size(95, 17);
            this.chkCarne.TabIndex = 5;
            this.chkCarne.Text = "Formato Carnê";
            this.chkCarne.UseVisualStyleBackColor = true;
            this.chkCarne.CheckedChanged += new System.EventHandler(this.chk_ChangeLayout);
            // 
            // chkRecibo
            // 
            this.chkRecibo.AutoSize = true;
            this.chkRecibo.Checked = true;
            this.chkRecibo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRecibo.Location = new System.Drawing.Point(17, 22);
            this.chkRecibo.Margin = new System.Windows.Forms.Padding(2);
            this.chkRecibo.Name = "chkRecibo";
            this.chkRecibo.Size = new System.Drawing.Size(89, 17);
            this.chkRecibo.TabIndex = 6;
            this.chkRecibo.Text = "Exibe Recibo";
            this.chkRecibo.UseVisualStyleBackColor = true;
            this.chkRecibo.CheckedChanged += new System.EventHandler(this.chk_ChangeLayout);
            // 
            // chkExtra
            // 
            this.chkExtra.AutoSize = true;
            this.chkExtra.BackColor = System.Drawing.SystemColors.Control;
            this.chkExtra.Location = new System.Drawing.Point(17, 39);
            this.chkExtra.Name = "chkExtra";
            this.chkExtra.Size = new System.Drawing.Size(113, 17);
            this.chkExtra.TabIndex = 8;
            this.chkExtra.Text = "Exibir Layout Extra";
            this.chkExtra.UseVisualStyleBackColor = false;
            this.chkExtra.CheckedChanged += new System.EventHandler(this.chk_ChangeLayout);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.bltFrm);
            this.groupBox1.Location = new System.Drawing.Point(12, 60);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox1.Size = new System.Drawing.Size(716, 355);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Pre-Visualização";
            // 
            // chkLogo
            // 
            this.chkLogo.AutoSize = true;
            this.chkLogo.Checked = true;
            this.chkLogo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkLogo.Location = new System.Drawing.Point(17, 5);
            this.chkLogo.Margin = new System.Windows.Forms.Padding(2);
            this.chkLogo.Name = "chkLogo";
            this.chkLogo.Size = new System.Drawing.Size(122, 17);
            this.chkLogo.TabIndex = 10;
            this.chkLogo.Text = "Exibe Logo Cedente";
            this.chkLogo.UseVisualStyleBackColor = true;
            this.chkLogo.CheckedChanged += new System.EventHandler(this.chk_ChangeLayout);
            // 
            // nmEscala
            // 
            this.nmEscala.Location = new System.Drawing.Point(207, 39);
            this.nmEscala.Name = "nmEscala";
            this.nmEscala.Size = new System.Drawing.Size(44, 20);
            this.nmEscala.TabIndex = 11;
            this.nmEscala.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.nmEscala.ValueChanged += new System.EventHandler(this.chk_ChangeLayout);
            // 
            // chkEscala
            // 
            this.chkEscala.AutoSize = true;
            this.chkEscala.Location = new System.Drawing.Point(143, 39);
            this.chkEscala.Name = "chkEscala";
            this.chkEscala.Size = new System.Drawing.Size(58, 17);
            this.chkEscala.TabIndex = 13;
            this.chkEscala.Text = "Escala";
            this.chkEscala.UseVisualStyleBackColor = true;
            this.chkEscala.CheckedChanged += new System.EventHandler(this.chk_ChangeLayout);
            // 
            // chkMaisEspaco
            // 
            this.chkMaisEspaco.AutoSize = true;
            this.chkMaisEspaco.Location = new System.Drawing.Point(143, 22);
            this.chkMaisEspaco.Name = "chkMaisEspaco";
            this.chkMaisEspaco.Size = new System.Drawing.Size(197, 17);
            this.chkMaisEspaco.TabIndex = 14;
            this.chkMaisEspaco.Text = "Aumentar Demostrativo e Instruções";
            this.chkMaisEspaco.UseVisualStyleBackColor = true;
            this.chkMaisEspaco.CheckedChanged += new System.EventHandler(this.chk_ChangeLayout);
            // 
            // bltFrm
            // 
            this.bltFrm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bltFrm.Location = new System.Drawing.Point(5, 18);
            this.bltFrm.Name = "bltFrm";
            this.bltFrm.Size = new System.Drawing.Size(706, 332);
            this.bltFrm.TabIndex = 8;
            // 
            // frmBasico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(740, 427);
            this.Controls.Add(this.chkMaisEspaco);
            this.Controls.Add(this.chkEscala);
            this.Controls.Add(this.nmEscala);
            this.Controls.Add(this.chkLogo);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.chkExtra);
            this.Controls.Add(this.chkRecibo);
            this.Controls.Add(this.chkCarne);
            this.Controls.Add(this.chkPreview);
            this.Controls.Add(this.btnPrintTabela);
            this.Controls.Add(this.btnImprimir);
            this.Name = "frmBasico";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Boleto Básico (Componente Padrão)";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmBasico_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nmEscala)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Button btnPrintTabela;
        private System.Windows.Forms.CheckBox chkPreview;
        private System.Windows.Forms.CheckBox chkCarne;
        private System.Windows.Forms.CheckBox chkRecibo;
        private System.Windows.Forms.CheckBox chkExtra;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkLogo;
        private System.Windows.Forms.NumericUpDown nmEscala;
        private System.Windows.Forms.CheckBox chkEscala;
        private System.Windows.Forms.CheckBox chkMaisEspaco;
        private BoletoForm bltFrm;

    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;
using Impactro.Cobranca;

// Existe v�rias forma de se customizar um boleto
// a Mas facil,� gerar uma imagem do jeito que se deseja o boleto
// e nesta imagem j� deixar pre-impresso os campos fixos que n�o mudam
// e colocar LABELS nos demais campos e uma imagem de c�digo de barras

namespace BoletoForm2
{
    public partial class frmCustromizado : Form
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmCustromizado());
        }

        public frmCustromizado()
        {
            InitializeComponent();
        }

        private void frmCustromizado_Load(object sender, EventArgs e)
        {
            // Defini��o dos dados do cedente
            CedenteInfo Cedente = new CedenteInfo();
            Cedente.Cedente = "Impactro Inform�tica (teste)";
            Cedente.Banco = "001";
            Cedente.Agencia = "999-7";
            Cedente.Conta = "999999-7";
            Cedente.Carteira = "18";
            Cedente.Modalidade = "19";
            Cedente.Convenio = "123456";    // ATEN��O: Alguns Bancos usam um c�digo de convenio para remapear a conta do clientes
            Cedente.CodCedente = "123456";  // outros bancos chama isto de Codigo do Cedente ou C�digo do Cliente
                                            // outros usam os 2 campos para controles distintos!
                                            // Veja com aten��o qual � o seu caso e qual destas vari�veis deve ser usadas!
                                            // Olhe sempre os exemplos em ASP.Net se tiver d�vidas, pois l� h� um exemplo para cada banco
                                            // Defini��o dos dados do sacado

            SacadoInfo Sacado = new SacadoInfo();
            Sacado.Sacado = "Fabio Ferreira (Teste)";
            Sacado.Documento = "123.456.789-99";
            Sacado.Endereco = "Av. Paulista, 1234";
            Sacado.Cidade = "S�o Paulo";
            Sacado.Bairro = "Centro";
            Sacado.Cep = "12345-123";
            Sacado.UF = "SP";
            Sacado.Avalista = "Nome Avalista / Documento";

            // Defini��o das Vari�veis do boleto
            BoletoInfo Boleto = new BoletoInfo();
            Boleto.NossoNumero = "12345";
            Boleto.NumeroDocumento = "12345";
            Boleto.ValorDocumento = 160.0;
            Boleto.DataDocumento = DateTime.Now;
            Boleto.DataVencimento = DateTime.Now;
            Boleto.Instrucoes = "Todas as informa��es deste bloqueto s�o de exclusiva responsabilidade do cedente";

            // Cria um objeto que calcula as informa��es do boleto
            Boleto blt = new Boleto();
            blt.MakeBoleto(Cedente, Sacado, Boleto);

            // antes de come�ar a pedir as informa��es para o objeto, 
            // � nescess�rio pedir que sejam calculado os dados (como se fosse um DataBind)
            blt.CalculaBoleto();

            // Coloca no TextBox o valor da linha digit�vel
            lblIPTE.Text = blt.LinhaDigitavel;

            // O nosso numero exibi��o � o numero EFETIVAMENTE que deve ser exibido
            // em v�rios casos os bancos exeigem formata��o especial para a exibi��o 
            // deste campo e tamb�m o calculo de digitos verificadores, assim nesta
            // vari�vel j� existe todas estas exigencias prontas
            lblNossoNumero.Text = blt.NossoNumeroExibicao;

            // N�o � nescess�rio formatar com {0:C} pois a 'Especie' (moeda) geralmente
            // � indicada em um campo a parte
            lblValor.Text = string.Format("{0:#,###,##0.00}", blt.ValorDocumento);

            // Formata a data sempre exibindo 2 digitos para dia e mes, e 4 para ano
            lblVencimento.Text = string.Format("{0:dd/MM/yyyy}", blt.DataVencimento);

            // Obtem a imagem do c�digo de barras
            picCodBaras.Image = CobUtil.BarCodeImage(blt.CodigoBarras);
            // A classe UTIL, contem as rotinas de gera��o de codigo de barras,
            // pois o codigo de barras, n�o � usado somente em boletos, mas em diversas aplica��es
            // desta forma � possivel gerar etiquetas de produtos, identifica��es de usu�rio, etc...

            // apenas coloca o nome do avalista na tela - opcional
            lblAvalista.Text = "Avalista: " + Sacado.Avalista;

        }

        // Um para imprimir aqui estou usando o sistema de impress�o basico do .Net
        private void btnImprimir_Click(object sender, EventArgs e)
        {
            // criando um documento de impress�o
            // para que eu mande os objeto serem renderizados neste.
            PrintDocument pDoc = new PrintDocument();
            PrintPreviewDialog ppw = new PrintPreviewDialog();
            pDoc.PrintPage += new PrintPageEventHandler(pDoc_PrintPage);
            ppw.Document = pDoc;
            ppw.MdiParent = this.MdiParent;
            ppw.WindowState = FormWindowState.Maximized;
            ppw.Show();
        }

        void pDoc_PrintPage(object sender, PrintPageEventArgs e)
        {
            try
            {
                // O objeto "e" possui um ponteiro grafico para o dispositivo de saida de impress�o
                // Vale lembrar que a resolu��o da impressora � quase sempre maior que a resolu��o do computador,
                // portanto de acordo as coordenadas s�o diferente. se for usado a escada: GraphicsUnit.Document
                // e.Graphics.PageUnit = GraphicsUnit.Document;

                // Define o ponto (0,0) para centralizar o boleto na p�gina
                e.Graphics.TranslateTransform(50,50);

                // Desenha o fundo
                e.Graphics.DrawImage(picFundo.Image, Fat(1),Fat(1));

                //Define a regi�o de impress�o dos textos, sempre alinhando para a direita (a regi�o do ipte � maior)
                StringFormat StringRight = new StringFormat();
                StringRight.Alignment = StringAlignment.Far;

                //Imprime os textos, nas mesmas posi��es 

                // uma pequena margem de corre��o de posicionamento
                int nMargemX = 30; 
                int nMargemY = 5; 

                // Define a fonte para o IPTE (linha digit�vel)
                Font fnt = new Font("Arial", 10, FontStyle.Bold, GraphicsUnit.Point);
                e.Graphics.DrawString(lblIPTE.Text, fnt, Brushes.Black, Fat(nMargemX + lblIPTE.Left + lblIPTE.Width), Fat(nMargemY+lblIPTE.Top), StringRight);

                // Define a fonte para textos comuns
                fnt = new Font("Arial", 8, FontStyle.Bold, GraphicsUnit.Point);
                e.Graphics.DrawString(lblVencimento.Text, fnt, Brushes.Black, Fat(nMargemX + lblVencimento.Left + lblVencimento.Width), Fat(nMargemY + lblVencimento.Top), StringRight);
                e.Graphics.DrawString(lblNossoNumero.Text, fnt, Brushes.Black, Fat(nMargemX + lblNossoNumero.Left + lblNossoNumero.Width), Fat(nMargemY + lblNossoNumero.Top), StringRight);
                e.Graphics.DrawString(lblValor.Text, fnt, Brushes.Black, Fat(nMargemX + lblValor.Left + lblValor.Width), Fat(nMargemY + lblValor.Top), StringRight);

                // desenha o c�digo de barras
                e.Graphics.DrawImage(picCodBaras.Image, Fat(picCodBaras.Left), Fat(picCodBaras.Top + nMargemY+5));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // esta rela��o permite-se converter pixel convertido em milimetros
        // double _fat = 300d / 25.4d; => 300 dpi / 25.4 cm
        double _fat = 1d; // escala normal (pixel)
        private int Fat(int n)
        {
            return (int)(_fat * n);
        }

    }
}
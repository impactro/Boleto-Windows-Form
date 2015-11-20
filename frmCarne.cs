using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing; //não esqueça de adicionar esta referencia para impressão
using Impactro.Cobranca;

namespace BoletoForm2
{
    public partial class frmCarne : Form
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmCarne());
        }

        #region "Formulário (Form: Init, Paint)"

        public frmCarne()
        {
            InitializeComponent();
            // a rotina Seta Valores é a que efetivamente processa as informações do boleto
            // neste exemplo estou definindo todos os dados na inicialização do formulário
            // em programas de impressão de vários boletos, ele deverá ser chamada para cada
            // novo boleto a ser impresso, veja a rotina de impressão (btnImprimir_Click)
            SetValores();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            fat = 72f / 25.4f;
            DrawBoleto(e.Graphics);
        }


        #endregion

        #region "Formulário Impressão"

        PrinterSettings pSettings = null;

        private void btnConfig_Click(object sender, EventArgs e)
        {
            PrintDialog pDialog = new PrintDialog();
            if (pDialog.ShowDialog() == DialogResult.OK)
                pSettings = pDialog.PrinterSettings;
        }

        // Um para imprimir aqui estou usando o sistema de impressão basico do .Net
        private void btnImprimir_Click(object sender, EventArgs e)
        {
            // criando um documento de impressão
            // para que eu mande os objeto serem renderizados neste.
            PrintDocument pDoc = new PrintDocument();
            PrintPreviewDialog ppw = new PrintPreviewDialog();
            // configura a página default para "paisagem"
            PageSettings ps = new PageSettings();
            ps.Landscape = true;

            // Se a impressão ftiver sido configurada
            if (pSettings != null)
                pDoc.PrinterSettings = pSettings;

            pDoc.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(pDoc_PrintPage);
            pDoc.DefaultPageSettings = ps;
            ppw.Document = pDoc;
            ppw.MdiParent = this.MdiParent;
            ppw.WindowState = FormWindowState.Maximized;
            ppw.PrintPreviewControl.Zoom = 1; // define o modo de zoom atual
            ppw.ShowDialog(this);
        }

        private void pDoc_PrintPage(object sender, PrintPageEventArgs e)
        {
            try
            {
                // O objeto "e" possui um ponteiro grafico para o dispositivo de saida de impressão
                // Vale lembrar que a resolução da impressora é quase sempre maior que a resolução do computador,
                // portanto de acordo as coordenadas são diferente. se for usado a escada: GraphicsUnit.Document
                // e.Graphics.PageUnit = GraphicsUnit.Document;

                // neste exemplo vetorial as fontes de titulo estão muito pequena para 75 dpi
                // portanto é escolhida a escala de 300 DPI
                e.Graphics.PageUnit = GraphicsUnit.Document;
                fat = 300f / 25.4f;

                // Define o ponto (0,0) para centralizar o boleto na página
                e.Graphics.TranslateTransform(Fat(5), Fat(1));
                DrawBoleto(e.Graphics);

                Pen pRecorte = new Pen(Color.Black, 2);
                pRecorte.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                e.Graphics.DrawLine(pRecorte, 0, Fat(99), Fat(275), Fat(99));

                // a transformação é acumulativa (relatia a anterior)
                e.Graphics.TranslateTransform(0, Fat(102));
                // manda calcular os dados do segundo boleto
                SetValores();
                DrawBoleto(e.Graphics);

                // a rotina seta valores está mudando automaticamente apenas o nosso numero
                // mas esta poderia estar pegando todos os dados de um banco de dados, etc..

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region "Coordenadas"

        // Todas medidas em milimetros
        private int[] Linhas =
        {
            // Parte 1

            // Linhas
            0,7,51,7,
            0,15,45,15,
            0,21,45,21,
            0,28,45,28,
            0,34,45,34,
            0,41,45,41,
            0,47,45,47,
            0,53,45,53,
            0,59,45,59,
            0,65,45,65,
            0,71,45,71,
            0,79,51,79,
            0,92,51,92,

            // Colunas
            30,0,30,7,
            40,0,40,7,
            19,7,19,15,
            12,21,12,28,

            // Parte 2

            // Linhas
            59,7,223,7,
            59,15,223,15,
            59,21,223,21,
            59,28,223,28,
            59,34,223,34,
            184,41,223,41,
            184,47,223,47,
            184,53,223,53,
            184,59,223,59,
            59,65,223,65,
            59,79,223,79,

            // Colunas
            89,0,89,7,
            107,0,107,7,
            184,7,184,65,
            87,21,87,34,
            102,28,102,34,
            116,21,116,34,
            137,21,137,28,
            156,21,156,34,

            // Parte 3

            // Linhas
            233,7,275,7,
            233,15,275,15,
            233,21,275,21,
            233,28,275,28,
            233,34,275,34,
            233,41,275,41,
            233,47,275,47,
            233,53,275,53,
            233,59,275,59,
            233,65,275,65,
            233,71,275,71,
            233,79,275,79,
            233,92,275,92,
            
            // Colunas
            263,0,263,7,
            271,0,271,7,
            252,7,252,15,
            246,21,246,28

        };


        private strTextos[] Textos = 
        {
            // Parte 1
            new strTextos(0,7,"Parcela/Plano"),
            new strTextos(20,7,"Vencimento"),
            new strTextos(0,15,BoletoTextos.CedenteConta),
            new strTextos(0,21,"Espécie"),
            new strTextos(13,21,"Quantidade"),
            new strTextos(0,28,"Valor do Documento"),
            new strTextos(0,34,"(-) Desconto/Abatimento"),
            new strTextos(0,47,"(+) Mora/Multa"),
            new strTextos(0,59,"(=) Valor Cobrado"),
            new strTextos(0,65,"Nosso Número"),
            new strTextos(0,71,"Num. do Documento"),
            new strTextos(0,79,BoletoTextos.Sacado ),

            // Parte 2
            new strTextos(59,7,"Local de Pagamento"),
            new strTextos(185,7,"Vencimento"),
            new strTextos(59,15,BoletoTextos.Cedente),
            new strTextos(185,15,BoletoTextos.CedenteConta),
            new strTextos(59,21,"Data do Documento"),
            new strTextos(88,21,"Nº do Documento"),
            new strTextos(117,21,BoletoTextos.EspecieDoc),
            new strTextos(138,21,"Aceite"),
            new strTextos(157,21,"Data Processamento"),
            new strTextos(185,21,"Nosso Número"),
            new strTextos(59,28,"Uso do Banco"),
            new strTextos(88,28,"Carteira"),
            new strTextos(103,28,"Espécie"),
            new strTextos(117,28,"Quantidade"),
            new strTextos(157,28,"Valor"),
            new strTextos(185,28,"(=) Valor do Documento"),
            new strTextos(59,34,BoletoTextos.Instrucoes ),
            new strTextos(185,34,"(-) Desconto/Abatimento"),
            new strTextos(185,47,"(+) Mora/Multa"),
            new strTextos(185,59,"(=) Valor Cobrado"),
            new strTextos(59,65,BoletoTextos.Sacado ),
            new strTextos(59,76,BoletoTextos.Avalista ),
            new strTextos(204,76,"Código de Baixa"),
            new strTextos(168,79,"Autenticação Mecânica - Ficha de Compensação"),

            // Parte 3
            new strTextos(233,7,"Parcela/Plano"),
            new strTextos(253,7,"Vencimento"),
            new strTextos(233,15,BoletoTextos.CedenteConta),
            new strTextos(233,21,"Espécie"),
            new strTextos(247,21,"Quantidade"),
            new strTextos(233,28,"Valor do Documento"),
            new strTextos(233,34,"(-) Desconto/Abatimento"),
            new strTextos(233,47,"(+) Mora/Multa"),
            new strTextos(233,59,"(=) Valor Cobrado"),
            new strTextos(233,65,"Nosso Número"),
            new strTextos(233,71,"Num. do Documento"),
            new strTextos(233,79,BoletoTextos.Sacado),
         
        };

        #endregion

        #region "Renderização"

        private SortedList<ValoresCampos, strTextos> Valores;
        Image imgBanco;
        Image imgCodBar;
        private int NossoNumero = 12345;

        private void SetValores()
        {
            // Exemplo abaixo baseado no boleto customizado...

            // Definição dos dados do cedente
            CedenteInfo Cedente = new CedenteInfo();
            Cedente.Cedente = "Impactro Informática (teste)";
            Cedente.Banco = "001";
            Cedente.Agencia = "999-7";
            Cedente.Conta = "999999-7";
            Cedente.Carteira = "18";
            Cedente.Modalidade = "19";
            Cedente.Convenio = "123456";    // ATENÇÃO: Alguns Bancos usam um código de convenio para remapear a conta do clientes
            Cedente.CodCedente = "123456";  // outros bancos chama isto de Codigo do Cedente ou Código do Cliente
            // outros usam os 2 campos para controles distintos!
            // Veja com atenção qual é o seu caso e qual destas variáveis deve ser usadas!
            // Olhe sempre os exemplos em ASP.Net se tiver dúvidas, pois lá há um exemplo para cada banco

            // Definição dos dados do sacado
            SacadoInfo Sacado = new SacadoInfo();
            Sacado.Sacado = "Fabio Ferreira (Teste)";
            Sacado.Documento = "123.456.789-99";
            Sacado.Endereco = "Av. Paulista, 1234";
            Sacado.Cidade = "São Paulo";
            Sacado.Bairro = "Centro";
            Sacado.Cep = "12345-123";
            Sacado.UF = "SP";
            Sacado.Avalista = "Impactro Informática - CNPJ: 123.456.789/00001-23";

            // Definição das Variáveis do boleto
            BoletoInfo Boleto = new BoletoInfo();
            Boleto.NossoNumero = NossoNumero.ToString();
            Boleto.NumeroDocumento = NossoNumero.ToString();
            Boleto.ValorDocumento = 160.0;
            Boleto.DataDocumento = DateTime.Now;
            Boleto.DataVencimento = DateTime.Now;
            Boleto.Instrucoes = "Todas as informações deste bloqueto são de exclusiva responsabilidade do cedente";

            // incrementa o nosso numero para outro boleto
            NossoNumero++;

            // Cria um objeto que calcula as informações do boleto
            Boleto blt = new Boleto();
            blt.MakeBoleto(Cedente, Sacado, Boleto);

            // antes de começar a pedir as informações para o objeto, 
            // é nescessário pedir que sejam calculado os dados (como se fosse um DataBind)
            blt.CalculaBoleto();

            Valores = new SortedList<ValoresCampos, strTextos>();

            // parte 1,2,3
            Valores.Add(ValoresCampos.ParcelaPlano, new strTextos(10, 15, 0, 0, 243, 15, " ", false, StringAlignment.Center));
            Valores.Add(ValoresCampos.Vencimento, new strTextos(45, 15, 223, 15, 275, 15, string.Format("{0:dd/MM/yyyy}", blt.DataVencimento), true, StringAlignment.Far));
            Valores.Add(ValoresCampos.AgenciaCedente, new strTextos(45, 21, 223, 21, 275, 21, blt.AgenciaConta, false, StringAlignment.Far));
            Valores.Add(ValoresCampos.Especie, new strTextos(5, 28, 108, 34, 238, 28, "R$", false, StringAlignment.Center));
            Valores.Add(ValoresCampos.Quantidade, new strTextos(45, 28, 138, 34, 275, 28, (blt.Quantidade == 0) ? "" : blt.Quantidade.ToString(), false, StringAlignment.Far));
            Valores.Add(ValoresCampos.ValorDocumento, new strTextos(45, 34, 223, 34, 275, 34, string.Format("{0:#,###,##0.00}", blt.ValorDocumento), true, StringAlignment.Far));
            Valores.Add(ValoresCampos.DescontoAbatimento, new strTextos(45, 41, 223, 41, 275, 41, " ", false, StringAlignment.Far));
            Valores.Add(ValoresCampos.MoraMulta, new strTextos(45, 53, 223, 53, 275, 53, "  ", false, StringAlignment.Far));
            Valores.Add(ValoresCampos.ValorCobrado, new strTextos(45, 65, 223, 65, 275, 65, " ", false, StringAlignment.Far));
            Valores.Add(ValoresCampos.NossoNumero, new strTextos(45, 71, 223, 28, 275, 71, blt.NossoNumeroExibicao, false, StringAlignment.Far));
            Valores.Add(ValoresCampos.NumeroDocumento, new strTextos(20, 79, 100, 28, 255, 79, blt.NumeroDocumento, false, StringAlignment.Center));
            Valores.Add(ValoresCampos.SacadoResumido, new strTextos(2, 85, 0, 0, 235, 85, blt.Sacado + "\n" + blt.SacadoDocumento, false, StringAlignment.Near));
            Valores.Add(ValoresCampos.Sacado, new strTextos(0, 0, 70, 69, 0, 0, blt.Sacado + " - " + blt.SacadoDocumento + "\n" + blt.SacadoEndereco + "\n" + blt.Cidade + " - " + blt.Bairro + " " + blt.UF + " CEP: " + blt.Cep, false, StringAlignment.Near));
            Valores.Add(ValoresCampos.Avalista, new strTextos(0, 0, 70, 79, 0, 0, blt.Avalista, false, StringAlignment.Near));
            Valores.Add(ValoresCampos.LocalPagamento, new strTextos(0, 0, 59, 15, 0, 0, "ATÉ O VENCIMENTO PAGUAVEL EM QUALQUER BANCO", false, StringAlignment.Near));
            Valores.Add(ValoresCampos.Cedente, new strTextos(0, 0, 59, 21, 0, 0, blt.Cedente, false, StringAlignment.Near));
            Valores.Add(ValoresCampos.DataDocumento, new strTextos(0, 0, 72, 28, 0, 0, string.Format("{0:dd/MM/yyyy}", blt.DataDocumento), false, StringAlignment.Center));
            Valores.Add(ValoresCampos.EspecieDoc, new strTextos(0, 0, 126, 28, 0, 0, "RC", false, StringAlignment.Center));
            Valores.Add(ValoresCampos.Aceite, new strTextos(0, 0, 146, 28, 0, 0, "N", false, StringAlignment.Center));
            Valores.Add(ValoresCampos.DataProcessamento, new strTextos(0, 0, 170, 28, 0, 0, string.Format("{0:dd/MM/yyyy}", blt.DataProcessamento), false, StringAlignment.Center));
            Valores.Add(ValoresCampos.UsodoBanco, new strTextos(0, 0, 70, 34, 0, 0, " ", false, StringAlignment.Center));
            Valores.Add(ValoresCampos.Carteira, new strTextos(0, 0, 94, 34, 0, 0, blt.Carteira, false, StringAlignment.Center));
            Valores.Add(ValoresCampos.Valor, new strTextos(0, 0, 168, 34, 0, 0, (blt.ValorDocumento == 0) ? "" : string.Format("{0:0.00}", blt.ValorDocumento), false, StringAlignment.Center));
            Valores.Add(ValoresCampos.Instrucoes, new strTextos(0, 0, 62, 45, 0, 0, blt.Instrucoes, false, StringAlignment.Near));

            // Campos Especiais (Banco e IPTE)
            Valores.Add(ValoresCampos.Banco, new strTextos(0, 0, 98, 7, 0, 0, blt.BancoCodigo, true, StringAlignment.Center));
            Valores.Add(ValoresCampos.IPTE, new strTextos(0, 0, 223, 6, 0, 0, blt.LinhaDigitavel, true, StringAlignment.Far));

            imgBanco = (Image)CobUtil.ResLoadImage(String.Format("{0:000}.gif", blt.BancoNumero));
            imgCodBar = CobUtil.BarCodeImage(blt.CodigoBarras);

        }

        private void DrawBoleto(Graphics g)
        {
            int n;

            // Ddesenha-se os logos dos bancos (com isso se garante que as linhas ficarão por cima
            g.DrawImage(imgBanco, Fat(0), Fat(0), Fat(30), Fat(7));
            g.DrawImage(imgBanco, Fat(59), Fat(0), Fat(30), Fat(7));
            g.DrawImage(imgBanco, Fat(233), Fat(0), Fat(30), Fat(7));

            // Imprime o código de barras
            g.DrawImage(imgCodBar, Fat(59), Fat(81));

            // Desenha as linhas
            for (n = 0; n < Linhas.Length; n += 4)
            {
                g.DrawLine(Pens.Black, Fat(Linhas[n]), Fat(Linhas[n + 1]), Fat(Linhas[n + 2]), Fat(Linhas[n + 3]));
            }

            // Escreve os Títulos dos Campos
            System.Drawing.Font fnt = new Font("Arial", (float)(2.5 * fat), FontStyle.Regular, GraphicsUnit.Pixel);
            for (n = 0; n < Textos.Length; n++)
            {
                g.DrawString(Textos[n].Texto, fnt, Brushes.Black, Fat(Textos[n].x1), Fat(Textos[n].y1));
            }

            // Escreve os valores dos campos
            StringFormat StringAlign = new StringFormat();
            ValoresCampos v;
            strTextos str;
            float t = 0;
            for (n = 0; n < Valores.Count; n++)
            {
                v = (ValoresCampos)n;
                str = Valores[v];

                if (str.Bold)
                {
                    if (v == ValoresCampos.Banco)
                        fnt = new Font("Arial", Fat(t = 6f), FontStyle.Bold, GraphicsUnit.Pixel);
                    else if (v == ValoresCampos.IPTE)
                        fnt = new Font("Arial", Fat(t = 4f), FontStyle.Bold, GraphicsUnit.Pixel);
                    else
                        fnt = new Font("Arial", Fat(t = 3f), FontStyle.Bold, GraphicsUnit.Pixel);
                }
                else
                    fnt = new Font("Arial", Fat(t = 3f), FontStyle.Regular, GraphicsUnit.Pixel);

                t += 0.5f;
                StringAlign.Alignment = str.Align;

                if (str.x1 > 0)
                    g.DrawString(str.Texto, fnt, Brushes.Black, Fat(str.x1), Fat(str.y1 - t), StringAlign);
                if (str.x2 > 0)
                    g.DrawString(str.Texto, fnt, Brushes.Black, Fat(str.x2), Fat(str.y2 - t), StringAlign);
                if (str.x3 > 0)
                    g.DrawString(str.Texto, fnt, Brushes.Black, Fat(str.x3), Fat(str.y3 - t), StringAlign);
            }

            // Escreve alguns outros textos diversos de cabeçalho

            // Legenda do Banco
            StringAlign.Alignment = StringAlignment.Center;
            fnt = new Font("Arial", Fat(2f), FontStyle.Bold, GraphicsUnit.Pixel);
            g.DrawString("Banco", fnt, Brushes.Black, Fat(35), Fat(0), StringAlign);
            g.DrawString("Banco", fnt, Brushes.Black, Fat(267), Fat(0), StringAlign);

            // Numero do banco
            string cBancoNumero = Valores[ValoresCampos.Banco].Texto.Split('-')[0];
            fnt = new Font("Arial", Fat(4f), FontStyle.Bold, GraphicsUnit.Pixel);
            g.DrawString(cBancoNumero, fnt, Brushes.Black, Fat(35), Fat(2), StringAlign);
            g.DrawString(cBancoNumero, fnt, Brushes.Black, Fat(267), Fat(2), StringAlign);

            // Infomações de vias (Recibo/Compensação)
            fnt = new Font("Arial", Fat(3f), FontStyle.Bold, GraphicsUnit.Pixel);
            g.DrawString("Recibo", fnt, Brushes.Black, Fat(40), Fat(0));
            g.DrawString("F\nC", fnt, Brushes.Black, Fat(272), Fat(0));


        }

        private float fat; // esta variável precisa ser inicializada para definir a resolução de calculo
        private float Fat(float n)
        {
            return (fat * n);
        }

        #endregion

    }

    #region "Estururas auxiliares"

    public enum ValoresCampos
    {
        NossoNumero,
        Vencimento,
        ParcelaPlano,
        AgenciaCedente,
        Especie,
        Quantidade,
        ValorDocumento,
        DescontoAbatimento,
        MoraMulta,
        ValorCobrado,
        NumeroDocumento,
        SacadoResumido,
        Sacado,
        Avalista,
        IPTE,
        Banco,
        LocalPagamento,
        Cedente,
        DataDocumento,
        EspecieDoc,
        Aceite,
        DataProcessamento,
        UsodoBanco,
        Carteira,
        Valor,
        Instrucoes
    }

    public struct strTextos
    {
        public int x1, y1;
        public int x2, y2;
        public int x3, y3;
        public string Texto;
        public StringAlignment Align;
        public bool Bold;

        public strTextos(int xi, int yi, string cTexto)
        {
            this.x1 = xi;
            this.y1 = yi;
            this.x2 = 0;
            this.y2 = 0;
            this.x3 = 0;
            this.y3 = 0;
            this.Texto = cTexto;
            this.Bold = false;
            this.Align = StringAlignment.Far;
        }

        public strTextos(int xi1, int yi1, int xi2, int yi2, int xi3, int yi3, string cTexto, bool lBold, StringAlignment sAlign)
        {
            this.x1 = xi1;
            this.y1 = yi1;
            this.x2 = xi2;
            this.y2 = yi2;
            this.x3 = xi3;
            this.y3 = yi3;
            this.Texto = cTexto;
            this.Bold = lBold;
            this.Align = sAlign;
        }
    }

    #endregion
}
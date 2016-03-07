using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;
using Impactro.Cobranca;
using Impactro.WindowsControls;

namespace BoletoForm2
{
    public partial class frmBasico : Form
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmBasico());
        }

        public frmBasico()
        {
            InitializeComponent();
        }

        private void frmBasico_Load(object sender, EventArgs e)
        {
            // Defini��o dos dados do cedente
            CedenteInfo Cedente = new CedenteInfo();
            Cedente.Cedente = "Impactro Inform�tica (teste)";
            Cedente.Endereco = "Endere�o xxx";
            Cedente.CNPJ = "05.343.346/0001-12";
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
            Cedente.UsoBanco = "123";
            Cedente.CIP = "456";

            // Defini��o dos dados do sacado
            SacadoInfo Sacado = new SacadoInfo();
            Sacado.Sacado = "Fabio Ferreira (Teste)";
            Sacado.Documento = "123.456.789-99";
            Sacado.Endereco = "Av. Paulista, 1234";
            Sacado.Cidade = "S�o Paulo";
            Sacado.Bairro = "Centro";
            Sacado.Cep = "12345-123";
            Sacado.UF = "SP";
            Sacado.Avalista = "Banco XPTO - CNPJ: 123.456.789/00001-23";

            // Defini��o das Vari�veis do boleto
            BoletoInfo Boleto = new BoletoInfo();
            Boleto.NossoNumero = "12345";
            Boleto.NumeroDocumento = "12345";
            Boleto.ParcelaNumero = 2;
            Boleto.ParcelaTotal = 6;
            Boleto.Quantidade = 5;
            Boleto.ValorUnitario = 20;
            Boleto.ValorDocumento = Boleto.Quantidade * Boleto.ValorUnitario;
            Boleto.DataDocumento = DateTime.Now;
            Boleto.DataVencimento = DateTime.Now.AddDays(-30);
            Boleto.Especie = Especies.RC;
            Boleto.DataDocumento = DateTime.Now.AddDays(-2);     // Por padr�o �  a data atual, geralmente � a data em que foi feita a compra/pedido, antes de ser gerado o boleto para pagamento
            Boleto.DataProcessamento = DateTime.Now.AddDays(-1); // Por padr�o � a data atual, pode ser usado como a data em que foi impresso o boleto
            
            // http://calculoexato.com.br/parprima.aspx?codMenu=DividBoletoVencido
            // Se for especificado o valor da mora, este ser� usado da forma mais simples
            //Boleto.ValorMora = 0.03;
            Boleto.PercentualMulta = 0.02; // 2.0% no m�s
            Boleto.PercentualMora = 0.001; // 0.1% valor percentual ao dia...
            // Valor original: R$100,00
            // Valor da multa de 2%: R$2,00
            // Valor com multa: R$102,00
            // Valor da 0.1% ao dia por 60 dias (6,00%): R$6,12
            // Valor com mora: R$108,12
            // Valor a ser pago: R$108,12
            // veja tamb�m a mesma conta em: http://exame.abril.com.br/seu-dinheiro/ferramentas/boleto-vencido.shtml
            // No valor do percentual Mora pode ser usado um valor mensal do tipo:
            // Boleto.PercentualMora = 0.03 / 30d; // 3% ao m�s

            // Se for especificado a data de pagamento esta ser� usada como base para o calculo do numero de dias em que ser� pago
            Boleto.DataPagamento = Boleto.DataVencimento.AddDays(60);    
            
            // Ativa o calculo de Juros+Mora
            Boleto.CalculaMultaMora = true;

            // Outros valores opcionais
            //Boleto.ValorDesconto = 10;
            //Boleto.DataDesconto = DateTime.Now.AddDays(-10);
            //Boleto.ValorAcrescimo = 3;
            //Boleto.ValorOutras = 12.34;
            Boleto.Instrucoes = "Todas as informa��es deste bloqueto s�o de exclusiva responsabilidade do cedente";

            //BoletoInfo Boleto = new BoletoInfo();
            // O tipo de documento pode ser selecionado para cada boleto, o padr�o � DM
            Boleto.Especie = Especies.DS;

            // Personaliza o boleto com seu logo
            bltFrm.Boleto.CedenteLogo = BoletoForm2.Properties.Resources.SeuLogo;

            // monta o boleto com os dados espec�ficos nas classes
            bltFrm.MakeBoleto(Cedente, Sacado, Boleto);

            // � possivel tamb�m customizar a linha referente o local de pagamento:
            bltFrm.Boleto.LocalPagamento = "Pague Preferencialmente no BANCO NOSSA CAIXA S.A. ou na rede banc�ria at� o vencimento";

            // Configura campos especiais extras no boleto
            PrintRecibo(bltFrm);
        }

        // Ser� usada para imprimir series de boletos diretamente
        DataTable tbDados;
        int nReg; // ser� usado para posicionar os registros

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            PrintDocument pDoc = new PrintDocument();
            Button btn = (Button)sender;
            if (btn.Name == "btnImprimir")
                pDoc.PrintPage += new PrintPageEventHandler(pDoc_PrintPageUnico);
            else
            {
                // Para imprimir dados vindo de uma tabela de um banco de dados
                // � preciso definir conex�es ao banco, com senhas, executar SELECTs.
                // Neste exemplo abaixo estou criando 5 registros em memoria e 
                // recalculando o boleto para cada p�gina impressa
                // Customize de acordo com suas necessidades, pois este � apenas um exemplo 
                // basico por isso ser�o utilizados apenas poucos campos.

                tbDados = new DataTable(); // Cria  atabela em memoria

                // Cria as colunas nos respectivos tipos
                tbDados.Columns.Add("Nome", typeof(string));
                tbDados.Columns.Add("Vencimento", typeof(DateTime));
                tbDados.Columns.Add("Valor", typeof(double));
                tbDados.Columns.Add("NossoNumero", typeof(int));

                // insere os dados
                tbDados.Rows.Add("Fabio", new DateTime(2008, 12, 30), 123.45, 345678);
                tbDados.Rows.Add("�rika", new DateTime(2008, 7, 25), 60, 12332);
                tbDados.Rows.Add("Milena", new DateTime(2008, 10, 20), 10.30, 234);
                tbDados.Rows.Add("Cliente", DateTime.MinValue, 200.55, 456445);
                tbDados.Rows.Add("qualquer um", new DateTime(2008, 2, 12), 7890.5, 56756);

                // posiciona o registro atual
                pDoc.PrintPage += new PrintPageEventHandler(pDoc_PrintPageTabela);
            }

            nReg = 0;
            pDoc.DefaultPageSettings.Landscape = chkCarne.Checked;

            if (chkPreview.Checked)
            {
                PrintDialog dlgPrinter = new PrintDialog();
                PrintPreviewDialog ppw = new PrintPreviewDialog();
                ppw.Document = pDoc;
                ppw.MdiParent = this.MdiParent;
                ppw.WindowState = FormWindowState.Maximized;
                ppw.Show();
            }
            else
                pDoc.Print();
        }

        // Para imprimir um unico boleto
        void pDoc_PrintPageUnico(object sender, PrintPageEventArgs e)
        {
            try
            {
                bltFrm.PrintType = PrintTypes.Documet;
                PrintRecibo(bltFrm);
                bltFrm.Print(e.Graphics);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Para imprimir uma serie de boletos onde os dados est�o vindo de um datatable
        void pDoc_PrintPageTabela(object sender, PrintPageEventArgs e)
        {
            try
            {
                // Defini��o dos dados do cedente
                CedenteInfo Cedente = new CedenteInfo();
                Cedente.Cedente = "outro cedente de outro banco!";
                Cedente.Banco = "237";
                Cedente.Agencia = "1234-5";
                Cedente.Conta = "123456-7";
                Cedente.Carteira = "06";
                Cedente.Modalidade = "11";

                // Defini��o dos dados do sacado
                SacadoInfo Sacado = new SacadoInfo();
                Sacado.Sacado = (string)tbDados.Rows[nReg]["Nome"];

                // Defini��o das Vari�veis do boleto
                BoletoInfo Boleto = new BoletoInfo();
                Boleto.DataVencimento = (DateTime)tbDados.Rows[nReg]["Vencimento"];
                Boleto.ValorDocumento = (double)tbDados.Rows[nReg]["Valor"];
                Boleto.NossoNumero = tbDados.Rows[nReg]["NossoNumero"].ToString();
                Boleto.NumeroDocumento = Boleto.NossoNumero;

                // Cria uma nova instancia totalmente idependente
                BoletoForm bol = new BoletoForm();
                // monta o boleto com os dados espec�ficos nas classes
                bol.MakeBoleto(Cedente, Sacado, Boleto);
                bol.PrintType = PrintTypes.Documet;
                // A defini��o do tipo carne ou normal j� define o RenderBoleto
                bol.Boleto.Carne = chkCarne.Checked;
                // bol.Boleto.RenderBoleto=new BoletoCarne(); // Na pratica definir como carne � a mesma coisa que instanciar a classe de carne no RenderBoleto
                PrintRecibo(bol);
                bol.Print(e.Graphics);

                nReg++;
                e.HasMorePages = nReg < tbDados.Rows.Count;
                if (!e.HasMorePages)
                    nReg = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void chk_ChangeLayout(object sender, EventArgs e)
        {
            // uma op��o � criar um layour customizado
            // mas neste exemplo estou usando o metodo PrintRecibo antes de imprimir o boleto na tela

            bltFrm.Boleto.Carne = chkCarne.Checked; // Limpa todos os campos (nova instancia)
            bltFrm.Boleto.ExibeReciboSacado = chkRecibo.Checked;
            bltFrm.Boleto.CedenteLogo = chkLogo.Checked ? BoletoForm2.Properties.Resources.SeuLogo : null;
            if (chkEscala.Checked)
            {
                // Com escala customizada � necess�rio redefinir os tamanhos dos fontes se necess�rio

                // Tamanho dos titulos dos campos
                FieldDraw.FontCampoName = "Verdana";
                FieldDraw.FontCampoSize = (float)(5 * nmEscala.Value / 3);
                FieldDraw.FontCampoStyle = FontStyle.Regular;

                // Tamanho dos valores dos campos
                FieldDraw.FontValorName = "Arial";
                FieldDraw.FontValorSize = (float)(7 * nmEscala.Value / 3);
                FieldDraw.FontValorStyle = FontStyle.Bold;

                // Tamanho da linha digit�vel
                FieldDraw.FontLinhaSize = (float)(9 * nmEscala.Value / 3);
                FieldDraw.FontLinhaName = "Arial";
                FieldDraw.FontLinhaStyle = FontStyle.Bold;

                // Recria as instancias dos fontes
                FieldDraw.Reset();

                bltFrm.Boleto.Escala = (double)nmEscala.Value;
            }
            else
            {
                // Com escala customizada � necess�rio redefinir os tamanhos dos fontes se necess�rio
                FieldDraw.FontCampoSize = 7;
                FieldDraw.FontValorSize = 9;
                FieldDraw.FontLinhaSize = 11;
                FieldDraw.FontCampoName = FieldDraw.FontValorName = FieldDraw.FontLinhaName = "Arial";
                FieldDraw.FontCampoStyle = FontStyle.Regular;
                FieldDraw.FontValorStyle = FieldDraw.FontLinhaStyle = FontStyle.Bold;
                FieldDraw.Reset();
                bltFrm.Boleto.Escala = 640 / 170d; // Escala padr�o 640 pixel em 170mm
            }

            PrintRecibo(bltFrm);
            bltFrm.Invalidate();
        }

        void PrintRecibo(BoletoForm oBoletoForm)
        {
            Boleto blt = oBoletoForm.Boleto;

            // Aqui n�o pode conter o clear por causa da impress�o que chama o PreRender() antes
            if (chkExtra.Checked)
            {
                int nTop = !blt.Carne && blt.ExibeReciboSacado ? (chkLogo.Checked ? 120 : 110) + 60 : 105;
                //int nWidth = blt.Carne ? 169 + 50 : 169;
                blt.CalculaBoleto();
                int nWidth = blt.RenderBoleto.Width;

                //if (chkMaisEspaco.Checked && blt.ExibeReciboSacado)
                //    nTop += 100;
                //else if (chkMaisEspaco.Checked)
                //    nTop += 50;

                // As 2 linhas abaix�o, dentro desta logica n��o � necess�rio pois quando se define se ser� carne ou n�o � criado o layout devido
                //if (blt.RenderBoleto == null)
                //    blt.RenderBoleto = new BoletoNormal();

                // Verifica se os campos j� foram criados
                // Por padr�o s�o criados por ultimo, dentro do render, mas para customizar precisam ser criados antes
                // Usando as fun��es internas direta do boleto n�o � necess�rio usar
                //if (blt.RenderBoleto.Count == -1)
                //    blt.RenderBoleto.MakeFields(blt);

                // Este metodo j� checa se existe um objeto de renderiza��o, chamando CalculaBoleto(), e renderizando os campos baiscos
                // Isso retorna uma instancia de FieldDraw, onde no maximo � possivel definir apenas uma propriedade na mesma linha
                FieldDraw f;
                // Linha 1
                f=blt.AddFieldDraw(0, 0 + nTop, null, "COMPROVANTE DE ENTREGA DE BOLETO", nWidth - 40, 7);
                f.Align=StringAlignment.Center;
                f.Destaque = true;
                blt.AddFieldDraw(nWidth - 40, 0 + nTop, "Nota Fiscal", "1234").Destaque = true; // Outra forma mais simples de adicionar elementos

                // Linha 2
                // � possivel adicionar linhas diretamente dentro do render Boleto, desde que se tenha feita as checagens anteriores
                blt.RenderBoleto.Add(new FieldDraw(0, 7 + nTop, "Cliente (Raz�o social)", blt.Sacado, nWidth, 7, StringAlignment.Near));
                // Na pratica a primeira informa��o adicionar � sempre bom fazer usando o AddFieldDraw, e depois voc�s faz como quiser

                // Linha 3
                blt.RenderBoleto.Add(new FieldDraw(0, 14 + nTop, "Nosso N�mero", blt.NossoNumeroExibicao, nWidth - 80, 7, StringAlignment.Near));
                blt.RenderBoleto.Add(new FieldDraw(nWidth - 80, 14 + nTop, "Data de Vencimento", blt.DataVencimento.ToString("dd/MM/yyyy"), 40, 7, StringAlignment.Center));
                blt.RenderBoleto.Add(new FieldDraw(nWidth - 40, 14 + nTop, "Valor do Documento", blt.ValorDocumento.ToString("C")));

                // Linha 4 - Usando a inclus�o direta, s� para definir as principais propriedades
                blt.AddFieldDraw(0, 22 + nTop, "Identifica��o e assinatura do recebedor", "", nWidth - 80, 10);
                blt.AddFieldDraw(nWidth - 80, 22 + nTop, "Documento de Identidade", "", 40, 10);
                blt.AddFieldDraw(nWidth - 40, 22 + nTop, "Data Recebimento", "", 40, 10);
            }

            // Depois de tudo 'desenhado' pode-se alterar algo que foi feito
            // pois na verdade n�o foi ainda desenhado, e sim montado um array com o que ser� desenhado
            if (chkMaisEspaco.Checked)
            {
                // Desde que esteja de fato tudo definido
                blt.CalculaBoleto();

                int nSize = blt.RenderBoleto.Count;
                bool lAchou=false;
                for(int n=0; n<nSize; n++)
                {
                    // Acha o campo Demostrativo que ocupa 100% do layout
                    if(blt.RenderBoleto.Get(n).Campo=="Demonstrativo")
                    {
                        lAchou = true;
                        blt.RenderBoleto.Get(n).Campo="Demonstrativo da Cobran�a"; // Personaliza o texto
                        blt.RenderBoleto.Get(n).Height+=50;
                    }
                    else if(lAchou)
                        // Desloca tudo adiante em 50 pixel para baixo
                        blt.RenderBoleto.Get(n).Y += 50;
                }

                // A logica para aumentar o campo de isntru��o � quase a mesma
                lAchou = false;
                bool lAchouFim = false;
                for (int n = 0; n < nSize; n++)
                {
                    // O que muda � que o campo n�o tem todo o tamnho do layout ent�o os campos laterais n�o podem ser empurrados para baixo
                    if (blt.RenderBoleto.Get(n).Campo == BoletoTextos.Instrucoes)
                    {
                        lAchou = true;
                        blt.RenderBoleto.Get(n).Campo = "Instru��es para Pagamento"; // Personaliza o texto
                        blt.RenderBoleto.Get(n).Height += 50;
                    }
                    else if (lAchouFim)
                        // Desloca tudo adiante em 50 pixel para baixo
                        blt.RenderBoleto.Get(n).Y += 50;
                    else if(lAchou)
                    {
                        // os campos s�o inserido em ordem sequencial
                        // ent�o depois de adicionar os elementos laterais, o restante tem que ser deslocado
                        lAchouFim = blt.RenderBoleto.Get(n).X == 0;
                        if (lAchouFim)
                        {
                            blt.RenderBoleto.Get(n).Y += 50; 
                            blt.RenderBoleto.Get(n-1).Height += 50; // Aumenta o taamnho do campo anterior
                        }
                    }
                }
            }
        }
    }
}
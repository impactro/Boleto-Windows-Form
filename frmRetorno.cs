using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Impactro.Layout;
using Impactro.Cobranca;

namespace BoletoForm2
{
    public partial class frmRetorno : Form
    {
        public frmRetorno()
        {
            InitializeComponent();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            if (ofd.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                using (StreamReader str = new StreamReader(ofd.FileName))
                {
                    txtRetorno.Text = str.ReadToEnd();
                    str.Close();
                }
            }
        }

        private void btnRetorno_Click(object sender, EventArgs e)
        {
            try
            {
                // Tipo de estrutura a ser decodificada (enumerador de layout)

                /* Exemplo de registros de retorno bradesco
10205491613000192000000900462012390740000000000000000000000004000000000000000000530000000000000000000000000903190515000000000500000000000000000053040615000000001547823703152  000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000                          0800000000                                                                  000006
10205491613000192000000900462012390740000000000000000000000005000000000000000000610000000000000000000000000903190515000000000600000000000000000061050615000000001557823703152  000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000                          0800000000                                                                  000007
102054916130001920000009004620123907400000000000000000000000060000000000000000007P000000000000000000000000090319051500000000070000000000000000007P060615000000001567823703152  000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000                          0800000000                                                                  000008
10205491613000192000000900462012390740000000000000000000000007000000000000000000880000000000000000000000000903190515000000000800000000000000000088070615000000001577823703152  000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000                          0800000000                                                                  000009
                 */
                // A classe Layout tem diversos metodos genericos para fazer qualquer codificação e decodificação de textos de acordo com os tipos de enumeradores passados em seu contrutor
                //Layout lay = new Layout(typeof(CNAB400Retorno1Bradesco));
                //Layout lay = new Layout(typeof(CNAB240CobrancaRetorno));
                //Layout lay = new Layout(typeof(CNAB400Retorno1Bradesco));
                //Layout lay = new Layout(typeof(CNAB240SegmentoTCaixa));
                //Layout lay = new Layout(typeof(CNAB400Retorno1Itau));

                // Coloca o texto em questão para ser interpretado
                //lay.Conteudo = txtRetorno.Text;

                // Internamente a classe de Layour armazena todos os dados e por gerar outros objetos como um DataTable com uma das estruturas
                //gv.DataSource = lay.Table(lay.GetLayoutType(0));

                LayoutBancos r = new LayoutBancos(); // classe genérica para qualquer banco, compatível até com ActiveX
                r.Init(new CedenteInfo { Banco = "341", Layout = LayoutTipo.Auto });
                r.Boletos.AddErroType = BoletoDuplicado.Ignore;
                Layout ret = r.Retorno(txtRetorno.Text);
                gvREG.DataSource = ret.Table(ret.GetLayoutType(0));

                DataTable tb = new DataTable();
                tb.Columns.Add("NossoNumero", typeof(string));
                tb.Columns.Add("NumeroDocumento", typeof(string));
                tb.Columns.Add("DataDocumento", typeof(DateTime));
                tb.Columns.Add("DataVencimento", typeof(DateTime));
                tb.Columns.Add("DataPagamento", typeof(DateTime));
                tb.Columns.Add("ValorDocumento", typeof(double));
                tb.Columns.Add("ValorPago", typeof(double));
                foreach (string nn in r.Boletos.NossoNumeros)
                {
                    // é possivel le os dados de cada boleto
                    BoletoInfo Boleto = r.Boletos[nn];
                    tb.Rows.Add(
                        Boleto.NossoNumero,
                        Boleto.NumeroDocumento,
                        Boleto.DataDocumento,
                        Boleto.DataVencimento,
                        Boleto.DataPagamento,
                        Boleto.ValorDocumento,
                        Boleto.ValorPago);
                }
                gvTB.DataSource = tb;

                if (string.IsNullOrEmpty(r.ErroLinhas))
                    txtOut.Text = "OK";
                else
                    txtOut.Text = "Arquivo processado mas as linhas abaixo estão parcialmente duplicadas\r\n" + r.ErroLinhas;
                    // Isso ocorre quando o banco toma alguma ação, ou algum sistema errou, trate essa linha a parte manualmente, ou algum euristica.
                    // em: r.Boletos.Duplicados há a relação destes boletos
            }
            catch (Exception ex)
            {
                txtOut.Text = "";
                while (ex != null)
                {
                    txtOut.Text += ex.Message + "\r\n" + ex.StackTrace;
                    ex = ex.InnerException;
                }
            }
        }
    }
}

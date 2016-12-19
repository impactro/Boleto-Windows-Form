using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Impactro.Cobranca;
using Impactro.Layout;

namespace BoletoForm2
{
    public partial class frmRemessa : Form
    {
        public frmRemessa()
        {
            InitializeComponent();
        }

        private void btnGerar_Click(object sender, EventArgs e)
        {
            // Definição dos dados do cedente - QUEM RECEBE / EMITE o boleto
            CedenteInfo Cedente = new CedenteInfo();
            Cedente.Cedente = "TESTE QUALQUER LTDA";
            Cedente.CNPJ = "12123123/0001-01";
            Cedente.Layout = LayoutTipo.Auto;

            // ABAIXO DESCOMENTE o bloco de dados do banco que pretende usar

            // SANTANDER
            //Cedente.Banco = "033";
            //Cedente.Agencia = "1234-1";
            //Cedente.Conta = "001234567-8";
            //Cedente.CodCedente = "1231230";
            //Cedente.CarteiraTipo = "5";
            //Cedente.Carteira = "101";
            //Cedente.CedenteCOD = "33333334892001304444"; // 20 digitos (note que o final, é o numero da conta, sem os ultios 2 digitos)
            //Cedente.Convenio = "0000000000000000002222220"; // 25 digitos
            //Cedente.useSantander = true; //importante para gerar o código de barras correto (por questão de compatibilidade o padrão é false)

            // BRADESCO
            Cedente.Banco = "237-2";
            Cedente.Agencia = "1510";
            Cedente.Conta = "001466-4";
            Cedente.Carteira = "09";
            Cedente.CedenteCOD = "00000000000001111111"; // 20 digitos

            // ITAU
            //Cedente.CedenteCOD = "514432001";
            //Cedente.Banco = "341-1";
            //Cedente.Agencia = "6260";
            //Cedente.Conta = "01607-3";
            //Cedente.Carteira = "109";

            // Banco do Brasil
            //Cedente.Banco = "001-9";
            //Cedente.Agencia = "294-1";
            //Cedente.Conta = "004570-6";
            //Cedente.Carteira = "18";
            //Cedente.Modalidade = "21";
            //Cedente.Convenio = "859120";

            // CAIXA 
            //Cedente.Banco = "104";
            //Cedente.Agencia = "123-4";
            //Cedente.Conta = "5678-9";
            //Cedente.Carteira = "2";          // Código da Carteira
            //Cedente.Convenio = "02";         // CNPJ do PV da conta do cliente
            //Cedente.CodCedente = "455932";   // Código do Cliente(cedente)
            //Cedente.Modalidade = "14";       // G069 - CC = 14 (título Registrado emissão Cedente)
            //Cedente.Endereco = "Rua Sei la aonde";
            //Cedente.Informacoes =
            //    "SAC CAIXA: 0800 726 0101 (informações, reclamações, sugestões e elogios)<br/>" +
            //    "Para pessoas com deficiência auditiva ou de fala: 0800 726 2492<br/>" +
            //    "Ouvidoria: 0800 725 7474 (reclamações não solucionadas e denúncias)<br/>" +
            //    "<a href='http://caixa.gov.br' target='_blank'>caixa.gov.br</a>";
            //BoletoTextos.LocalPagamento = "PREFERENCIALMENTE NAS CASAS LOTÉRICAS ATÉ O VALOR LIMITE";

            // SICRED
            //Cedente.Banco = "748-2";
            //Cedente.Agencia = "1234-5";
            //Cedente.Conta = "98765-1";
            //Cedente.CodCedente = "12345";
            //Cedente.Modalidade = "04";

            // UNICRED
            //Cedente.Banco = "091-4";
            //Cedente.Agencia = "1234-5";
            //Cedente.Conta = "98765-1";
            //Cedente.CodCedente = "12345";

            //Definição dos dados do sacado
            SacadoInfo Sacado = new SacadoInfo();
            Sacado.Sacado = "Fábio F S";
            Sacado.Documento = "192.211.498-70";
            Sacado.Endereco = "Rua 21 de Abril 1001 ap 21";
            Sacado.Cidade = "São Paulo";
            Sacado.Bairro = "Brás";
            Sacado.Cep = "03047-000";
            Sacado.UF = "SP";
            Sacado.Email = "fabio@impactro.com.br";
            Sacado.Avalista = "Avalista";

            LayoutBancos r = new LayoutBancos();
            r.Init(Cedente);
            r.Lote = CobUtil.GetInt(txtLote.Text);
            r.ShowDumpLine = chkDump.Checked;
            //r.onRegBoleto = r_onRegBoleto; // Para personalizar as linhas com os campos adicionais

            for (int n = 0; n < Int32.Parse(txtQTD.Text); n++)
            {
                //Definição das Variáveis do boleto
                BoletoInfo Boleto = new BoletoInfo();
                Boleto.BoletoID = n;
                Boleto.NossoNumero = (Int32.Parse(txtNossoNumero.Text) + n).ToString();
                Boleto.NumeroDocumento = Boleto.NossoNumero;
                Boleto.ValorDocumento = double.Parse(txtValor.Text) + n;
                Boleto.DataDocumento = DateTime.Now;
                Boleto.DataVencimento = DateTime.Parse(txtVencimento.Text).AddDays(n);
                Boleto.Instrucoes = "Todas as informações deste bloqueto são de exclusiva responsabilidade do cedente";

                // outros campos opcionais
                Boleto.ValorMora = Boleto.ValorDocumento * 0.2 / 30; // Vale lembrar que o juros pode ser tão pequeno que as vezes pode sair como isento
                Boleto.PercentualMulta = 0.03;
                Boleto.ValorDesconto = n;
                Boleto.DataDesconto = DateTime.Now;
                Boleto.ValorOutras = -n; // abatimentos 

                /* Exemplo de uso valido apenas para o Bradesco (Página 21 do arquivo: layout_cobranca_port_BRADESCO.pdf)
                 * Cada banco usa estes campos da forma que eles querem
                
                157 a 160 - 1ª / 2ª Instrução
                Campo destinado para pré-determinar o protesto do Título ou a baixa por decurso de prazo, quando do registro.
                Não havendo interesse, preencher com Zeros.
                Porém, caso a Empresa deseje se utilizar da instrução automática de protesto ou da baixa por decurso de prazo, abaixo os procedimentos:
                
                Protesto:
                - posição 157 a 158 = Indicar o código “06” - (Protestar).
                - posição 159 a 160 = Indicar o número de dias a protestar (mínimo 5 dias).
                
                Protesto Falimentar:
                - posição 157 a 158 = Indicar o código “05” – (Protesto Falimentar)
                - posição 159 a 160 = Indicar o número de dias a protestar (mínimo 5 dias).
                
                Decurso de Prazo:
                - posição 157 a 158 = Indicar o código “18” – (Decurso de prazo).
                - posição 159 a 160 = Indicar o número de dias para baixa por decurso de prazo.

                Nota: A posição 157 a 158, também poderá ser utilizada para definir as seguintes mensagens, a serem impressas nos Boletos de cobrança, emitidas pelo Banco:
                08 Não cobrar juros de mora
                09 Não receber após o vencimento
                10 Multa de 10% após o 4º dia do Vencimento.
                11 Não receber após o 8º dia do vencimento.
                12 Cobrar encargos após o 5º dia do vencimento.
                13 Cobrar encargos após o 10º dia do vencimento.
                14 Cobrar encargos após o 15º dia do vencimento
                15 Conceder desconto mesmo se pago após o vencimento.
                Atenção: Essas instruções deverão ser enviadas no Arquivo-Remessa, quando da entrada, desde que o código de ocorrência na posição 109 a 110 do registro de transação, seja “01”, para as instruções de protesto, o CNPJ / CPF e o endereço do Sacado deverão ser informados corretamente.
                */
                Boleto.Instrucao1 = 6; // Protestar
                Boleto.Instrucao2 = 7; // Depois de 7 dias do vencimento

                // No bRadesco não é usado o campo Comando, mas outros bancos podem usar
                // Boleto.Comando = 0;

                // As linhas a seguir customiza qualquer valor sem precisar usar o evento 'r.onRegBoleto' o que torna a implementação mais simples
                // A forma mais pratica e segura é sempre usar os enumeradores
                // Mas é possivel usar as duas opções como neste exemplo, mas os valores personalizados tem sempre prioridade pois são inserridos por ultimo apos todos calculos, e processamento de eventos, portanto use com cuidado!
                Boleto.SetRegEnumValue(CNAB400Remessa1Sicredi.TipoJuros, "B");    // (posição 19) // Apenas se atente para a diferença do nome para SetRegEnumValue()
                Boleto.SetRegKeyValue("CNAB400Remessa1Sicredi.Alteracao", "E");   // (posição 71) // É possivel adicionar o nome e valor do enumerador, isso é compativel com VB6
                // Cuidado ao deixar algo explicito diretamente: 
                // Boleto.SetRegKeyValue("Emissao", "B"); // posição 74 // ou simplesmente informar o nome do campo, mas cuidado pois há layouts que usam mais de um tipo de registro e as vezes tem nomes iguais mas as funções podem ser diferentes
                Boleto.SetRegEnumValue(CNAB400Remessa1Bradesco.Condicao, 1); // Apenas para Bradesco enviar o boleto para residencia

                // Gera um registro
                //Boleto.Sacado = Sacado; // obrigatório para o registro
                r.Add(Boleto, Sacado);
            }

            // o numero de exemplo '123' é apenas um numero de teste
            // este numero é muito importante que seja gerado de forma exclusiva e sequencial
            txtRemessa.Text = r.Remessa(); //r.CNAB400(123);
        }

        // Uso para personalizar os campos do sicred ou de qualquer outro que não seguem os padrão comum
        void r_onRegBoleto(CNAB cnab, IReg reg, BoletoInfo boleto)
        {
            // A verificação do tipo agora é obrigatporio poosi todos os registros, incluindo o header e footer podem ser personalizados
            // Logico que em certos registro o valor de BoletoInfo é null
            if (reg.NameType == typeof(CNAB400Remessa1Sicredi))
            {
                Reg<CNAB400Remessa1Sicredi> regBoleto = (Reg<CNAB400Remessa1Sicredi>)reg;

                // A rotina padrão define estas variáveis comentadas abaixo:
                
                regBoleto[CNAB400Remessa1Sicredi.NumeroDocumento] = cnab.Cedente.DocumentoNumeros;
                regBoleto[CNAB400Remessa1Sicredi.NossoNumero] = boleto.NossoNumero;
                regBoleto[CNAB400Remessa1Sicredi.NumeroDocumento] = boleto.NumeroDocumento;
                regBoleto[CNAB400Remessa1Sicredi.DataVencimento] = boleto.DataVencimento;
                regBoleto[CNAB400Remessa1Sicredi.ValorDocumento] = boleto.ValorDocumento;
                regBoleto[CNAB400Remessa1Sicredi.Especie] = CNAB400Sicredi.EspecieSicred(boleto.Especie);
                regBoleto[CNAB400Remessa1Sicredi.Aceite] = boleto.Aceite == "A" ? "S" : "N";
                regBoleto[CNAB400Remessa1Sicredi.Data] = boleto.DataDocumento;
                regBoleto[CNAB400Remessa1Sicredi.DataEmissao] = boleto.DataDocumento;
                if (boleto.ParcelaTotal > 0)
                {
                    regBoleto[CNAB400Remessa1Sicredi.TipoImpressao] = "B";
                    regBoleto[CNAB400Remessa1Sicredi.ParcelaNumero] = boleto.ParcelaNumero;
                    regBoleto[CNAB400Remessa1Sicredi.ParcelaTotal] = boleto.ParcelaTotal;
                }
                regBoleto[CNAB400Remessa1Sicredi.Instrucao] = boleto.Instrucao1;
                regBoleto[CNAB400Remessa1Sicredi.Protesto] = boleto.DiasProtesto > 6 ? "06" : "00";
                regBoleto[CNAB400Remessa1Sicredi.DiasProtesto] = boleto.DiasProtesto;
                regBoleto[CNAB400Remessa1Sicredi.PercentualMora] = boleto.PercentualMora;
                regBoleto[CNAB400Remessa1Sicredi.DataDesconto] = boleto.DataDesconto;
                regBoleto[CNAB400Remessa1Sicredi.ValorDesconto] = boleto.ValorDesconto;
                regBoleto[CNAB400Remessa1Sicredi.SacadoTipo] = boleto.Sacado.Tipo;
                regBoleto[CNAB400Remessa1Sicredi.SacadoDocumento] = boleto.Sacado.DocumentoNumeros;
                regBoleto[CNAB400Remessa1Sicredi.Endereco] = boleto.Sacado.Endereco;
                regBoleto[CNAB400Remessa1Sicredi.CEP] = boleto.Sacado.CepNumeros;
                

                // Campos com certa particulariade no sicred
                regBoleto[CNAB400Remessa1Sicredi.Emissao] = "A"; // O padrão é que a emissão seja feito no cliente ("B")
                regBoleto[CNAB400Remessa1Sicredi.Alteracao] = "C"; // Desconto por dia de antecipação; 

                // Para que o Sicred poste o boleto tem que mudar o padrão abaixo
                regBoleto[CNAB400Remessa1Sicredi.TipoPostagem] = "S";
                regBoleto[CNAB400Remessa1Sicredi.Emissao] = "A";
            }
        }
    }
}

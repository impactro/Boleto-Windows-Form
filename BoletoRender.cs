using Impactro.Cobranca;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace BoletoForm2
{
    public class BoletoRender : BoletoNormal
    {
        // Exemplo de um render customizado
        public override void MakeFields(Boleto blt)
        {
            // obtem os campos padrão do boleto
            base.MakeFields(blt);

            // Tamanho Máximo: 169
            // Altura padrão da linha: 7
            // Largura padrão do campo: 40
            // BIT das linhas: TOP, RIGHT, BOTTOM, LEFT: 0011 => 3

            // Cria os novos campos
            Fields.Add(new FieldDraw(0, 0 + Height, null, "COMPROVANTE DE ENTREGA DE BOLETO", 129, 7, StringAlignment.Center, 0x0) { Destaque = true, Linhas = 0x0F });
            Fields.Add(new FieldDraw(129, 0 + Height, "Nota Fiscal", "1234") { Linhas = 0x0F });
            Fields.Add(new FieldDraw(0, 7 + Height, "Cliente (Razão social)", blt.Sacado, 169, 7, StringAlignment.Near) { Linhas = 0x0F });
            Fields.Add(new FieldDraw(0, 14 + Height, "Data de Vencimento", blt.DataVencimento.ToString("dd/MM/yyyy"), 90, 7, StringAlignment.Center));
            Fields.Add(new FieldDraw(90, 14 + Height, "Valor do Documento", blt.ValorDocumento.ToString("C"), 79) { Linhas = 0x0F });
            Fields.Add(new FieldDraw(0, 22 + Height, "Identificação e assinatura do recebedor", "", 90) { Linhas = 0x0F });
            Fields.Add(new FieldDraw(90, 22 + Height, "Documento de Identidade", "", 39) { Linhas = 0x0F });
            Fields.Add(new FieldDraw(129, 22 + Height, "Data Recebimento", "") { Linhas = 0x0F });

            Height += 22 + 7;
            // retorna o conteudo a ser renderizado
        }
    }
}

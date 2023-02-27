using System.Collections.Generic;
using System.Linq;
using B3Modelo.Ativo.CDB;

namespace B3Api.ModeloDeResposta
{
    public class CdbRespostaResponse
    {
        public float ValorInvestido { get; set; }
        public float ValorAjustado { get; set; }
        public float ValorLiquido { get; set; }
        public float AliquotaIR { get; set; }
        public float ValorIR { get; set; }
        public float LucroBruto { get; set; }
        public float LucroLiquido { get; set; }
        public uint MesesInvestidos { get; set; }
    }

    public static class CdbRespostaResponseExtensao
    {
        public static CdbRespostaResponse ParaCdbRespostaResponse(this Cdb cdb)
        {
            return new CdbRespostaResponse
            {
                ValorInvestido = cdb.ValorInicial.Valor,
                ValorAjustado = cdb.ValorValorizado.Valor,
                ValorLiquido = cdb.ValorLiquido.Valor,
                AliquotaIR = cdb.PercentualImpostoDeRenda.Valor,
                ValorIR = cdb.ValorImpostoDeRenda.Valor,
                LucroBruto = cdb.Lucro.Valor,
                LucroLiquido = cdb.LucroLiquido.Valor,
                MesesInvestidos = cdb.Mes
            };
        }

        public static IEnumerable<CdbRespostaResponse> ParaCdbRespostaResponse(this IEnumerable<Cdb> cdb)
        {
            return cdb.Select(c => c.ParaCdbRespostaResponse());
        }
    }
}
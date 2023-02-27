using B3Modelo.Enums;
using B3Modelo.ObjetosDeValor;

namespace B3Modelo.Ativo.CDB
{
    public static class CdbAliquotas
    {
        public static Percentual MaisDeDoisAnos => new Percentual(0.15f);
        public static Percentual AteDoisAnos => new Percentual(0.175f);
        public static Percentual AteUmAno => new Percentual(0.20f);
        public static Percentual AteSeisMeses => new Percentual(0.225f);

        public static Percentual ObterTaxaPercentualImpostoDeRenda(ETempoDeInvestimento tempoDeInvestimento)
        {
            Percentual percentual = AteSeisMeses;

            switch (tempoDeInvestimento)
            {
                case ETempoDeInvestimento.MaisDeDoisAnos: percentual = MaisDeDoisAnos; break;
                case ETempoDeInvestimento.AteDoisAnos: percentual = AteDoisAnos; break;
                case ETempoDeInvestimento.AteUmAno: percentual = AteUmAno; break;
            }

            return percentual;
        }
    }
}

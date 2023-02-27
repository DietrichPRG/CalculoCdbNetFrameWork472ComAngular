using B3Modelo.Enums;
using B3Modelo.ObjetosDeValor;

namespace B3Modelo.Extensoes
{
    public static class ETempoDeInvestimentoExtensao
    {
        public static ETempoDeInvestimento ParaETempoDeInvestimento(this uint value)
        {
            ETempoDeInvestimento tempo = ETempoDeInvestimento.AteSeisMeses;

            if (value > 24)
            {
                tempo = ETempoDeInvestimento.MaisDeDoisAnos;
            }
            else if (value > 12)
            {
                tempo = ETempoDeInvestimento.AteDoisAnos;
            }
            else if (value > 6)
            {
                tempo = ETempoDeInvestimento.AteUmAno;
            }

            return tempo;
        }
    }
}

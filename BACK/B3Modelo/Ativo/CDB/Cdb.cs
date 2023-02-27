using B3Modelo.ObjetosDeValor;
using B3Modelo.Extensoes;
using static B3Modelo.Ativo.CDB.CdbAliquotas;

namespace B3Modelo.Ativo.CDB
{
    public readonly struct Cdb
    {
        public Dinheiro ValorInicial { get; }
        public Dinheiro ValorValorizado { get; }
        public uint Mes { get; }
        public Dinheiro ValorLiquido => this.ValorValorizado - ValorImpostoDeRenda;
        public Dinheiro Lucro => this.ValorValorizado - ValorInicial;
        public Dinheiro LucroLiquido => this.ValorLiquido - ValorInicial;
        public Percentual PercentualImpostoDeRenda => ObterTaxaPercentualImpostoDeRenda(this.Mes.ParaETempoDeInvestimento());
        public Dinheiro ValorImpostoDeRenda => (this.ValorValorizado - this.ValorInicial) * this.PercentualImpostoDeRenda;

        public Cdb(Dinheiro valorInicial, Dinheiro valorValorizado, uint mes)
        {
            ValorInicial = valorInicial;
            ValorValorizado = valorValorizado;
            Mes = mes;
        }

        public override string ToString()
        {
            return
                $"Valor investido: {this.ValorInicial} | Rendimento total: {this.Lucro} | Valor total: {this.ValorValorizado} | Meses Investidos: {this.Mes} | Aliquota IR: {this.PercentualImpostoDeRenda} | Valor IR: {this.ValorImpostoDeRenda} | Valor se sacar investimento: {this.ValorLiquido}";
        }
    }
}

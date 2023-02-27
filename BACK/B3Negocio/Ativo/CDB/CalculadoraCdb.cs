using System.Collections.Generic;
using B3Modelo.Ativo.CDB;
using B3Modelo.ObjetosDeValor;

namespace B3Negocio.Ativo.CDB
{
    public class CalculadoraCdb
    {
        private readonly Percentual taxaCdi = new Percentual(0.009f);
        private readonly Percentual taxaBancaria = new Percentual(1.08f);
        private static Dinheiro CalcularCdb(Dinheiro valorInicial, Percentual taxaCdi, Percentual taxaBancaria) => new Dinheiro(valorInicial.Valor * (1 + (taxaCdi.Valor * taxaBancaria.Valor)));

        public IList<Cdb> CalcularCdbComHistorico(Dinheiro valorInicial, uint meses)
        {
            if (meses <= 1)
                throw new System.ArgumentException("A quantidade de meses deve ser superior a 1.", nameof(meses));

            // cria a lista de retorno
            IList<Cdb> lst = new List<Cdb>()
            {
                // adiciona o primeiro item
                new Cdb(valorInicial, // usa o ultimo valor valorizado como input
                    this.CalcularCdb(valorInicial), // ''
                    1)
            };

            // adiciona os outros meses
            for (uint i = 1; i < meses; i++)
            {
                lst.Add(new Cdb(
                        valorInicial, // usa o ultimo valor valorizado como input
                    this.CalcularCdb(lst[(int)i - 1].ValorValorizado), // ''
                    i + 1) // acrescenta +1 na quantidade de meses
                );
            }

            return lst;
        }

        public Cdb CalcularCdb(Dinheiro valorInicial, uint meses)
        {
            if (meses <= 1)
                throw new System.ArgumentException("A quantidade de meses deve ser superior a 1.", nameof(meses));

            return new Cdb(valorInicial, this.Calcular(valorInicial, meses), meses);
        }

        private Dinheiro CalcularCdb(Dinheiro valorInicial)
        {
            return CalcularCdb(valorInicial, this.taxaCdi, this.taxaBancaria);
        }

        private Dinheiro Calcular(Dinheiro valor, uint totalDeMeses, uint mes = 0)
        {
            if (mes == totalDeMeses)
                return valor;

            return this.Calcular(this.CalcularCdb(valor), totalDeMeses, mes + 1);
        }
    }
}

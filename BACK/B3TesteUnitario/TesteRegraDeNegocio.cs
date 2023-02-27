using B3Modelo.Ativo.CDB;
using B3Modelo.ObjetosDeValor;
using B3Negocio.Ativo.CDB;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace B3TesteUnitario
{
    [TestClass]
    public class TesteRegraDeNegocio
    {
        [DataTestMethod]
        [DataRow(0, 1u)]
        [DataRow(-1, 1u)]
        public void CdbNaoPodeReceberValorIgualOuMenorQueZero(float valor, uint meses)
        {
            Assert.ThrowsException<ArgumentException>(() => new CalculadoraCdb().CalcularCdb(new Dinheiro(valor), meses));
        }

        [DataTestMethod]
        [DataRow(1, 0u)]
        public void CdbNaoPodeReceberMesIgualOuMenorQueZero(float valor, uint meses)
        {
            Assert.ThrowsException<ArgumentException>(() => new CalculadoraCdb().CalcularCdb(new Dinheiro(valor), meses));
        }

        [DataTestMethod]
        [DataRow(1000, 2u)]
        [DataRow(1000, 3u)]
        [DataRow(1000, 4u)]
        [DataRow(1000, 5u)]
        [DataRow(1000, 6u)]
        public void IRAteSeisMeses(float valor, uint meses)
        {
            var cdb = new CalculadoraCdb().CalcularCdb(new Dinheiro(valor), meses);
            
            Assert.AreEqual(CdbAliquotas.AteSeisMeses, cdb.PercentualImpostoDeRenda);
        }

        [DataTestMethod]
        [DataRow(1000, 7u)]
        [DataRow(1000, 8u)]
        [DataRow(1000, 9u)]
        [DataRow(1000, 10u)]
        [DataRow(1000, 11u)]
        [DataRow(1000, 12u)]
        public void IRAteDozeMeses(float valor, uint meses)
        {
            var cdb = new CalculadoraCdb().CalcularCdb(new Dinheiro(valor), meses);

            Assert.AreEqual(CdbAliquotas.AteUmAno, cdb.PercentualImpostoDeRenda);
        }

        [DataTestMethod]
        [DataRow(1000, 13u)]
        [DataRow(1000, 14u)]
        [DataRow(1000, 15u)]
        [DataRow(1000, 16u)]
        [DataRow(1000, 17u)]
        [DataRow(1000, 18u)]
        [DataRow(1000, 19u)]
        [DataRow(1000, 20u)]
        [DataRow(1000, 21u)]
        [DataRow(1000, 22u)]
        [DataRow(1000, 23u)]
        [DataRow(1000, 24u)]
        public void IRAteDoisAnos(float valor, uint meses)
        {
            var cdb = new CalculadoraCdb().CalcularCdb(new Dinheiro(valor), meses);

            Assert.AreEqual(CdbAliquotas.AteDoisAnos, cdb.PercentualImpostoDeRenda);
        }

        [DataTestMethod]
        [DataRow(1000, 25u)]
        public void IRMaisDeDoisAnos(float valor, uint meses)
        {
            var cdb = new CalculadoraCdb().CalcularCdb(new Dinheiro(valor), meses);

            Assert.AreEqual(CdbAliquotas.MaisDeDoisAnos, cdb.PercentualImpostoDeRenda);
        }

        [DataTestMethod]
        [DataRow(1000, 2u)]
        [DataRow(1000, 5u)]
        [DataRow(1000, 50u)]
        [DataRow(1000, 100u)]
        public void QuantidadeHistoricoIgualQuantidadeDeMeses(float valor, uint meses)
        {
            var cdb = new CalculadoraCdb().CalcularCdbComHistorico(new Dinheiro(valor), meses);

            Assert.AreEqual(meses, (uint)cdb.Count);
        }
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using B3Modelo.ObjetosDeValor;

namespace B3TesteUnitario
{
    [TestClass]
    public class TesteObjetoDeValor
    {
        [DataTestMethod]
        [DataRow(0)]
        [DataRow(-1)]
        public void DinheiroNaoPodeSerIgualOuMenorQueZero(float valor)
        {
            Assert.ThrowsException<ArgumentException>(() => new Dinheiro(valor));
        }

        [DataTestMethod]
        [DataRow(0)]
        [DataRow(-1)]
        public void PercentualNaoPodeSerIgualOuMenorQueZero(float valor)
        {
            Assert.ThrowsException<ArgumentException>(() => new Percentual(valor));
        }
    }
}

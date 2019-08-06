using Microsoft.VisualStudio.TestTools.UnitTesting;
using ContaBancariaTesteUnitario;

namespace ContaBancariaTestes
{
    [TestClass]
    public class ContaBancariaTeste
    {
        [TestMethod]
        public void Debito_ComValorValido()
        {
            double saldoInicial = 11.99;
            double quantidadeDebitada = 4.55;
            double saldoEsperado = 7.44;
            ContaBancaria conta = new ContaBancaria("Mario", saldoInicial);

            conta.Debito(quantidadeDebitada);

            double saldoReal = conta.Saldo;
            Assert.AreEqual(saldoEsperado, saldoReal, 0.001, "Conta não debitada corretamente");
        }
    }
}

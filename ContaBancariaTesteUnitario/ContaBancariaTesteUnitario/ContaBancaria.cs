using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContaBancariaTesteUnitario
{
    public class ContaBancaria
    {
        public const string MsgValorDebitoMaiorSaldo = "O valor de débito é maior que o saldo";
        public const string MsgValorDebitoMenorQueZero = "O valor de débito é menor que zero";

        public string Nome { get; private set; }
        public double Saldo { get; private set; }

        public ContaBancaria(string nome, double saldo)
        {
            this.Nome = nome;
            this.Saldo = saldo;
        }

        public void Debito(double valor)
        {
            if (valor > Saldo)
            {
                throw new ArgumentOutOfRangeException("valor", valor, MsgValorDebitoMaiorSaldo);
            }

            if (valor < 0)
            {
                throw new ArgumentOutOfRangeException("valor", valor, MsgValorDebitoMenorQueZero);
            }

            Saldo -= valor;
        }

        public void Credito(double valor)
        {
            if (valor < 0)
            {
                throw new ArgumentOutOfRangeException("valor");
            }
            Saldo += valor;
        }
    }
}

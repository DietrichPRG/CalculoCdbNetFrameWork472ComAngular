using System;

namespace B3Modelo.ObjetosDeValor
{
    public readonly struct Dinheiro
    {
        public float Valor { get; }

        public override string ToString()
        {
            return this.Valor.ToString("C2");
        }

        public Dinheiro(float valor)
        {
            if (valor <= 0)
                throw new ArgumentException("Valor informado no objeto de valor 'Dinheiro' não pode ser igual ou menor que zero", nameof(valor));

            Valor = valor;
        }

        public static Dinheiro operator +(Dinheiro a, Dinheiro b)
        {
            return new Dinheiro(a.Valor + b.Valor);
        }

        public static Dinheiro operator +(Dinheiro a, Percentual b)
        {
            return new Dinheiro(a.Valor * (1 + b.Valor));
        }

        public static Dinheiro operator -(Dinheiro a, Dinheiro b)
        {
            return new Dinheiro(a.Valor - b.Valor);
        }

        public static Dinheiro operator -(Dinheiro a, Percentual b)
        {
            return new Dinheiro(a.Valor - (a.Valor * b.Valor));
        }

        public static Dinheiro operator *(Dinheiro a, Dinheiro b)
        {
            return new Dinheiro(a.Valor * b.Valor);
        }

        public static Dinheiro operator *(Dinheiro a, Percentual b)
        {
            return new Dinheiro(a.Valor * b.Valor);
        }

        public static Dinheiro operator /(Dinheiro a, Dinheiro b)
        {
            return new Dinheiro(a.Valor / b.Valor);
        }
    }
}

using System;

namespace B3Modelo.ObjetosDeValor
{
    public readonly struct Percentual
    {
        public float Valor { get; }

        public Percentual(float valor)
        {
            if (valor <= 0)
                throw new ArgumentException($"Valor informado no objeto de valor 'Percentual' não pode ser igual ou menor que zero", nameof(valor));

            Valor = valor;
        }

        public override string ToString()
        {
            return this.Valor.ToString("P2");
        }

        public static Percentual operator +(Percentual a, Percentual b)
        {
            return new Percentual(a.Valor + b.Valor);
        }

        public static Percentual operator -(Percentual a, Percentual b)
        {
            return new Percentual(a.Valor - b.Valor);
        }

        public static Percentual operator *(Percentual a, Percentual b)
        {
            return new Percentual(a.Valor * b.Valor);
        }

        public static Percentual operator /(Percentual a, Percentual b)
        {
            return new Percentual(a.Valor / b.Valor);
        }
    }
}

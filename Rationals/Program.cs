using System;

namespace Rationals
{
    internal class Program
    {
        private struct Rational
        {
            public Rational(int numerator, int denominator)
            {
                Numerator = numerator;
                Denominator = denominator == 0 ? 1 : denominator;
            }

            public Rational(int numerator)
            {
                Numerator = numerator;
                Denominator = 1;
            }

            private int Numerator { get; set; }

            private int Denominator { get; set; }

            public double Value => (double)Numerator / Denominator;

            public Rational Add(Rational addRational)
            {
                if (Denominator == addRational.Denominator)
                {
                    var newRational = new Rational(Numerator + addRational.Numerator, Denominator);
                    return newRational;
                }
                else
                {
                    var denominator = Denominator * addRational.Denominator;
                    var newRational = new Rational( denominator / addRational.Denominator 
                        * addRational.Numerator 
                        + denominator / Denominator 
                        * Numerator, denominator);
                    return newRational;
                }
            }

            public Rational Mul(Rational mulRational)
            {
                var newRational = new Rational(
                    Numerator * mulRational.Numerator, 
                    Denominator * mulRational.Denominator);
                return newRational;
            }

            public void Reduce()
            {
                var numerator = Numerator;
                Numerator /= Gcd(Numerator, Denominator);
                Denominator /= Gcd(numerator, Denominator);
            }

            public override string ToString()
            {
                return $"{Numerator}/{Denominator}";
            }

            private static int Gcd(int a, int b)
            {
                return b == 0 ? a : Gcd(b, a % b);
            }

        }

        public static void Main(string[] args)
        {
            var r0 = new Rational(18);
            var r1 = new Rational(150, 50);
            var r2 = new Rational(6, 24);
            var r3 = r1.Add(r2);
            var r4 = r1.Mul(r2);
            var r5 = r0.Add(r2);

            Console.WriteLine($"{r0} + {r2} = {r5} = {r5.Value}");
            Console.WriteLine($"{r1} + {r0} = {r3} = {r3.Value}");
            Console.WriteLine($"{r1} * {r2} = {r4} = {r4.Value}");

            r0.Reduce();
            r1.Reduce();
            r2.Reduce();
            r3.Reduce();
            r4.Reduce();
            r5.Reduce();

            Console.WriteLine("\nReducing the rational equation:\n");
            Console.WriteLine($"{r0} + {r2} = {r5} = {r5.Value}");
            Console.WriteLine($"{r1} + {r2} = {r3} = {r3.Value}");
            Console.WriteLine($"{r1} * {r2} = {r4} = {r4.Value}");
        }
    }
}

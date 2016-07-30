using System;

namespace Rationals
{
    internal class Program
    {
        //Consider extracting this to a different file and outside of other types.
        private struct Rational
        {
            public Rational(int numerator, int denominator)
            {
                Numerator = numerator;
                Denominator = denominator == 0 ? 1 : denominator;
            }

            //Should have considered to call the other constructor: Rational(int numerator) : this(numerator, 1) { }
            public Rational(int numerator)
            {
                Numerator = numerator;
                Denominator = 1;
            }

            //Why is this private
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
            var num1 = new Rational(1, 2);
            var num2 = new Rational(1, 2);

            var num3 = num1.Add(num2);

            var num4 = num2.Mul(num2);

            var num6 = new Rational(2, 4);
            var num7 = new Rational(2, 4);
            num7.Reduce();


            Console.WriteLine($"{num1} + {num2} = {num3}");
            Console.WriteLine($"{num2} * {num2} = {num4}");
            Console.WriteLine($"{num6} reduced {num7}");
        }
    }
}

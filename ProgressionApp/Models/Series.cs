using System;

namespace ProgressionApp.Models
{
    public abstract class Series
    {
        public abstract double GetElement(int j);
        public abstract double GetSum(int n);
    }

    public class Linear : Series
    {
        private double a, d;
        public Linear(double a, double d)
        {
            this.a = a;
            this.d = d;
        }

        public override double GetElement(int j)
        {
            return a + (j - 1) * d;
        }

        public override double GetSum(int n)
        {
            return n * (2 * a + (n - 1) * d) / 2;
        }
    }

    public class Exponential : Series
    {
        private double a, r;
        public Exponential(double a, double r)
        {
            this.a = a;
            this.r = r;
        }

        public override double GetElement(int j)
        {
            return a * Math.Pow(r, j - 1);
        }

        public override double GetSum(int n)
        {
            if (r == 1)
                return a * n;
            return a * (1 - Math.Pow(r, n)) / (1 - r);
        }
    }
}

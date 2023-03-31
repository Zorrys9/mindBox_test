namespace AreaCalculator.Models
{
    public class Triangle : IFigure
    {
        public double A { get; set; }
        public double B { get; set; }
        public double C { get; set; }
        public Triangle(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0)
                throw new ArgumentException("The value of the side is not valid");
            A = a;
            B = b;
            C = c;
        }

        public bool IsStraight()
        {
            // Можно было сделать переборов if-ов и найти максимальное число или Max() методами, но решил так
            var tempArr = new double[] { A, B, C }
                .OrderByDescending(x => x)
                .ToArray();

            return Math.Pow(tempArr[0], 2) == Math.Pow(tempArr[1], 2) + Math.Pow(tempArr[2], 2);
        }

        public double GetPerimeter() =>
            A + B + C;

        public override double GetArea()
        {
            // Можно сделать проверку на прямоугольность и если прямоугольный - юзать другую формулу. но не уверен насколько это правильно
            var p = GetPerimeter() / 2;

            return Math.Sqrt(p * (p - A) * (p - B) * (p - C));
        }


    }
}

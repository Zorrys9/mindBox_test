namespace AreaCalculator.Test
{
    [TestClass]
    public class AreaTest
    {
        // Unit-тесты делаю впервые, так что могу что-то не так сделать 

        [TestMethod]
        public void TestCircleArea()
        {
            var testArr = new double[] { 5, 10, 4.3, -1, -9, 19, 200, -300, 0, 400 };
            foreach (var testRadius in testArr)
                CircleAreaTest(testRadius);
        }

        [TestMethod]
        public void TestTriangleArea()
        {
            var testArr = new double[] { 5, 10, 4.3, -1, -9, 19, 200, -300, 0, 400, 400, 26, 534, 25.7, 65.3, 30, 32, };
            for (var i = 0; i < 500; i++)
            {
                var aIndex = new Random().Next(0, testArr.Length - 1);
                var bIndex = new Random().Next(0, testArr.Length - 1);
                var cIndex = new Random().Next(0, testArr.Length - 1);
                TriangleAreaTest(aIndex, bIndex, cIndex);
            }
        }

        [TestMethod]
        public void TestTriangleIsStraight()
        {
            try
            {
                var testArr = new Triangle[]
           {
                new Triangle(1,2,3),
                new Triangle(-5,4,19),
                new Triangle(100,24,47),
                new Triangle(43,254,543),
                new Triangle(3,4,5),
                new Triangle(5,4,3),
                new Triangle(20.4,24.7,40),
                new Triangle(-14,25,36),
                new Triangle(13,24,-36),
                new Triangle(0,26345,3654),
                new Triangle(500,300,400),
                new Triangle(154,2543,34352),
           };

                foreach (var testTrinagle in testArr)
                {
                    var result = testTrinagle.IsStraight();
                    var tempArr = new double[] { testTrinagle.A, testTrinagle.B, testTrinagle.C }
                        .OrderByDescending(x => x)
                        .ToArray();

                    var test = Math.Pow(tempArr[0], 2) == Math.Pow(tempArr[1], 2) + Math.Pow(tempArr[2], 2);

                    Assert.AreEqual(test, result);
                }
            }
            catch (ArgumentException ex)
            {
                StringAssert.Contains(ex.Message, "The value of the side is not valid");
            }
           
        }

        private void TriangleAreaTest(double a, double b, double c)
        {
            try
            {
                if (a <= 0 || b <= 0 || c <= 0)
                    throw new ArgumentException("The value of the side is not valid");
                IFigure triangle = new Triangle(a, b, c);
                var result = FigureService.GetArea(triangle);
                var area = GetTriangleArea(a, b, c);

                Assert.AreEqual(result, area);
            }
            catch (ArgumentException ex)
            {
                StringAssert.Contains(ex.Message, "The value of the side is not valid");
            }
        }

        private void CircleAreaTest(double radius)
        {
            try
            {
                if (radius <= 0)
                    throw new ArgumentException("radius is not valid");
                IFigure circle = new Circle(radius);
                var result = FigureService.GetArea(circle);
                var area = GetCircleArea(radius);

                Assert.AreEqual(result, area);
            }
            catch (ArgumentException ex)
            {
                StringAssert.Contains(ex.Message, "radius is not valid");
            }
        }

        private double GetTriangleArea(double a, double b, double c)
        {
            var p = (a + b + c) / 2;

            return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        }
        private double GetCircleArea(double r)
        {
            return Math.PI * Math.Pow(r, 2);
        }
    }
}
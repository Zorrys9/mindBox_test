using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AreaCalculator.Models
{
    public class Circle : IFigure
    {
        public Circle(double r)
        {
            if (r <= 0)
                throw new ArgumentException("radius is not valid");
            Radius = r;
        }
        public double Radius { get; set; }

        public override double GetArea() =>
            Math.PI * Math.Pow(Radius, 2);
    }
}

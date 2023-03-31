using AreaCalculator.Models;

namespace AreaCalculator.Services
{
    public static class FigureService
    {
        public static double GetArea(IFigure figure)
        {
            return figure.GetArea();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriangleLib
{
    public class Triangle
    {
        public static bool IsTriangle(double sideAB, double sideBC, double sideAC)
        {
            return (sideAB > 0 && sideBC > 0 && sideAC > 0 && (sideAB + sideBC > sideAC) && (sideAB + sideAC > sideBC) && (sideBC + sideAC > sideAB));
        }
        public static bool IsIsoscelesTriangle(double sideAB, double sideBC, double sideAC)
        {
            return (IsTriangle(sideAB, sideBC, sideAC) && (sideAB == sideBC || sideAB == sideAC || sideBC == sideAC));
        }
        public static bool IsEquilateralTriangle(double sideAB, double sideBC, double sideAC)
        {
            return (IsTriangle(sideAB, sideBC, sideAC) && (sideAB == sideBC && sideAB == sideAC));
        }
        public static bool IsRightTriangle(double sideAB, double sideBC, double sideAC)
        {
            return (IsTriangle(sideAB, sideBC, sideAC) &&
                ((Math.Pow(sideAB, 2) + Math.Pow(sideBC, 2)) == Math.Pow(sideAC, 2) ||
                (Math.Pow(sideAB, 2) + Math.Pow(sideAC, 2)) == Math.Pow(sideBC, 2) ||
                (Math.Pow(sideBC, 2) + Math.Pow(sideAC, 2)) == Math.Pow(sideAB, 2)));
        }
    }
}

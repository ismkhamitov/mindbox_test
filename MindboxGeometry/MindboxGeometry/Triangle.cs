using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MindboxGeometry
{
    /// <summary>
    /// Represents Triangle with its three edges
    /// </summary>
    public class Triangle
    {
        public Triangle(double a, double b, double c)
        {
            if (a + b < c || a + c < b || b + c < a)
                throw new ArgumentException("Triangle inequality is not satisfied!");

            _a = a;
            _b = b;
            _c = c;
        }

        /// <summary>
        /// Indicates that one of the angles is 90 degrees
        /// </summary>
        public bool IsRectangular
        {
            get
            {
                return Math.Abs(_a*_a + _b*_b - _c*_c) < _eps
                    || Math.Abs(_a*_a + _c*_c - _b*_b) < _eps
                    || Math.Abs(_b*_b + _c*_c - _a*_a) < _eps;
            }
        }

        /// <summary>
        /// Gets area of triangle
        /// </summary>
        public double Area
        {
            get
            {
                double p = (_a + _b + _c)/2;
                return Math.Sqrt(p * (p - _a) * (p - _b) * (p - _c));
            }
        }

        protected double _a;
        protected double _b;
        protected double _c;

        private double _eps = 1e-9;
    }
}

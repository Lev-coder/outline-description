using OpenCvSharp;
using RecognizerLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecognizerTest
{
    /// <summary>
    /// класс ,который делает вещи проще
    /// </summary>
    class Simplifier
    {
        /// <summary>
        /// вычисляет расстояние от точки до точки. 
        /// </summary>
        /// <param name="pointsA">Массив точек</param>
        /// <param name="pointsB">Массив точек,который получен в результате поиска контуров </param>
        /// <returns>суммарное отклонение имеющихся точек от тех которые получили в результате поиска контура</returns>
        public static int SumError(Point[] pointsA, Point[] pointsB)
        {
            if(pointsA.Count() != pointsB.Count())
            {
                throw new ArgumentException("pointsA.Count() != pointsB.Count()");
            }
            int sumError = 0;
            int pointLength = pointsA.Count();
            for(int i = 0; i < pointLength; i++)
            {
                sumError += (int)HelperMath.Distance(pointsA[i], pointsB[i]);
            }
            return sumError;
        }
    }
}

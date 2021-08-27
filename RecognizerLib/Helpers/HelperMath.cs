using System;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using OpenCvSharp;

namespace RecognizerLib
{
    /// <summary>
    /// Содержит в себе функции связанные с математикой
    /// </summary>
    public static class HelperMath
    {
        /// <summary>
        /// возвращает меридиану для изображения по гистограмме изображения
        /// </summary>
        /// <param name="imgMat">изображение в типе Mat</param>
        /// <returns>медиана</returns>
        public static double Median(Mat imgMat)
        {
            double m = (imgMat.Rows * imgMat.Cols) / 2;
            int bin = 0;
            double med = -1.0;

            Mat hist = new Mat();
            int[] hdims = { 256 };
            Rangef[] ranges = { new Rangef(0, 256), };
            Cv2.CalcHist(
                new Mat[] { imgMat },
                new int[] { 0 },
                null,
                hist,
                1,
                hdims,
                ranges);

            for (int i = 0; i < hdims[0] && med < 0.0; ++i)
            {
                bin += (int)hist.At<float>(i);

                if (bin > m && med < 0.0)
                {
                    med = i;
                }
            }

            return med;
        }

        /// <summary>
        /// Возвращает дистанцию от точки A до точки B
        /// </summary>
        /// <param name="pointA">точки A</param>
        /// <param name="pointB">точки B</param>
        /// <returns>дистанция</returns>
        public static double Distance(Point pointA, Point pointB)
        {
            return pointA.DistanceTo(pointB);
        }

        /// <summary>
        /// вычисляет расстояние между точками контура
        /// </summary>
        /// <param name="cuntureA">первый контур</param>
        /// <param name="cuntureB">второй контур</param>
        /// <returns>расстояние между контурами</returns>
        public static double CuntureDistance(Point[][] cuntureA, Point[][] cuntureB)
        {
            double cuntureDistance = 0;

            int minCuntur = Math.Min(cuntureA.Length,cuntureB.Length);
            for (int i = 0; i < minCuntur; i++)
            {
                int minСurve = Math.Min(cuntureA[i].Length, cuntureB[i].Length);
                for (int j = 0; j < minСurve; j++)
                {
                    cuntureDistance += Distance(cuntureA[i][j], cuntureB[i][j]);
                }
            }
            return cuntureDistance;
        }

        /// <summary>
        /// приводит массив точек типа Point2f к типу Point
        /// </summary>
        /// <param name="boxPoints">массив точек типа Point2f</param>
        public static Point[] ParsePoint2fToPoint(Point2f[] boxPoints)
        {
            Point[] approxPoints = new Point[boxPoints.Length];
            for (int i = 0; i < boxPoints.Length; i++)
            {
                approxPoints[i] = (Point)boxPoints[i];
            }

            return approxPoints;
        }

        /// <summary>
        /// вычисляет верхнии и нижнии пределы изображения серого цвета на основе мередианы
        /// </summary>
        /// <param name="mat">изображение серого цвета</param>
        /// <param name="sigma">отклонение</param>
        /// <returns>нижний и верхний пределы</returns>
        public static Tuple<int,int> getLoverAndUpperThresh(Mat mat,float sigma)
        {
            double median = Task.Run(() => HelperMath.Median(mat)).Result;
            int lowerThresh = (int)Math.Max(0, (1.0 - sigma) * median);
            int upperThresh = (int)Math.Min(255, (1.0 + sigma) * median);
            
            return new Tuple<int, int>(lowerThresh,upperThresh);
        }
    }
}

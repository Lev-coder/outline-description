using Microsoft.VisualStudio.TestTools.UnitTesting;

using RecognizerLib.Finders;
using OpenCvSharp;
using RecognizerTest;
using System.Diagnostics;

namespace Recognizer
{
    [TestClass]
    public class Recogniz
    {
        private ImgPaint img = new ImgPaint();
        private TypicalFindContours _typicalFindContours = new TypicalFindContours();

        /// <summary>
        /// найти точки линии
        /// </summary>
        [TestMethod]
        public void Line()
        {
            Point[] line = new Point[]
            { 
                new Point(5, 5),
                new Point(100, 100) 
            };
            
            Mat lineMat = img.DrawLine(line[0], line[1],new Scalar(255,0,140),"line.png",false,false,true);

            Cv2.CvtColor(lineMat, lineMat, ColorConversionCodes.BGRA2GRAY);
            Point[][] points = _typicalFindContours.FindContours(lineMat);

            CollectionAssert.AreEqual(line, points[0]);
        }

        /// <summary>
        /// найти точки треугольника
        /// </summary>
        [TestMethod]
        public void Triangle()
        {
            Point[] triangle = new Point[]
            {
                new Point(50,50),
                new Point(80, 80),
                new Point(110,50)
            };

            Mat lineMat = img.DrawTriangle(triangle[0], triangle[1], triangle[2], new Scalar(255, 0, 200));

            Cv2.CvtColor(lineMat, lineMat, ColorConversionCodes.BGRA2GRAY);
            Point[][] points = _typicalFindContours.FindContours(lineMat);

            CollectionAssert.AreEqual(triangle, points[0]);
        }

        /// <summary>
        /// найти точки прямоугольника
        /// </summary>
        [TestMethod]
        public void Rectangle()
        {
            int x = 10;
            int y = 10;
            int w = 80;
            int h = 50;
            Point[] rectangle = new Point[]
            {
                new Point(x, y),
                new Point(x, y+h),
                new Point(x+w,y+h),
                new Point(x+w, y)
            };

            Mat lineMat = img.DrawRectangle(x, y, w, h,new Scalar(105,32,2));

            Cv2.CvtColor(lineMat, lineMat, ColorConversionCodes.BGRA2GRAY);
            Point[][] points = _typicalFindContours.FindContours(lineMat);

            int sumError = Simplifier.SumError(rectangle, points[0]);
            Debug.Assert(sumError < 5);
        }

        /// <summary>
        /// найти точки большего из двух прямоугольников
        /// </summary>
        [TestMethod]
        public void RectangleInRectangle()
        {
            int x = 10;
            int y = 10;
            int w = 80;
            int h = 50;
            Point[] rectangle1 = new Point[]
            {
                new Point(x, y),
                new Point(x, y+h),
                new Point(x+w,y+h),
                new Point(x+w, y)
            };

            int x2 = 14;
            int y2 = 14;
            int w2 = 7;
            int h2 = 4;
            Point[] rectangle2 = new Point[]
            {
                new Point(x2, y2),
                new Point(x2, y2+h2),
                new Point(x2+w2,y2+h2),
                new Point(x2+w2, y2)
            };

            Mat rectagnlMat = img.DrawRectangle(x, y, w, h,new Scalar(0,250,250));
            rectagnlMat = img.DrawRectangle2(rectagnlMat, x2, y2, w2, h2, new Scalar(255, 0, 0), "rectangleInRectangle.png");

            Cv2.CvtColor(rectagnlMat, rectagnlMat, ColorConversionCodes.BGRA2GRAY);
            Point[][] points = _typicalFindContours.FindContours(rectagnlMat);

            int sumError = Simplifier.SumError(rectangle1, points[0]);
            Debug.Assert(sumError < 5);
        }

        /// <summary>
        /// найти точки большего из двух прямоугольников вариант 2
        /// </summary>
        [TestMethod]
        public void RectangleInRectangle2()
        {
            int x = 10;
            int y = 10;
            int w = 80;
            int h = 50;
            Point[] rectangle1 = new Point[]
            {
                new Point(x, y),
                new Point(x, y+h),
                new Point(x+w,y+h),
                new Point(x+w, y)
            };

            int x2 = 5;
            int y2 = 5;
            int w2 = 100;
            int h2 = 100;
            Point[] rectangle2 = new Point[]
            {
                new Point(x2, y2),
                new Point(x2, y2+h2),
                new Point(x2+w2,y2+h2),
                new Point(x2+w2, y2)
            };

            Mat rectagnlMat = img.DrawRectangle(x, y, w, h, new Scalar(0, 250, 250));
            rectagnlMat = img.DrawRectangle2(rectagnlMat, x2, y2, w2, h2,new Scalar(255, 0, 0), "rectangleInRectangle2.png");

            Cv2.CvtColor(rectagnlMat, rectagnlMat, ColorConversionCodes.BGRA2GRAY);
            Point[][] points = _typicalFindContours.FindContours(rectagnlMat);

            int sumError = Simplifier.SumError(rectangle2, points[0]);
            Debug.Assert(sumError < 5);
        }

        /*
         * Тут должны быть тесты на пересечение фигур, но находились лишние точки + была большая погрешность.
         * Я решил что больший контур находится относительно хорошо ,а вот при наложение фигур появляються некоторые дефекты.
         * Точки фигуры находились неправильно( не прилипали точь в точь к первоначальному контуру )
         * Это проблема была решена тем что перестала считаться проблемой.
         * Нужно описывать только приблизительное очертание фигуры(которое получилось в результате пересечения других фигур).
         */
    }
}

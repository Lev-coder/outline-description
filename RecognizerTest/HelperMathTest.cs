using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenCvSharp;
using RecognizerLib;

namespace RecognizerTest
{
    [TestClass]
    public class HelperMathTest
    {
        [TestMethod]
        public void Distance1()
        {
            Point pointA = new Point(5, 0);
            Point pointB = new Point(5, 5);

            double distance = HelperMath.Distance(pointA, pointB);

            Assert.AreEqual( 5, distance,0.0001);
        }

        [TestMethod]
        public void Distance2()
        {
            Point pointA = new Point(5, 5);
            Point pointB = new Point(5, 5);

            double distance = HelperMath.Distance(pointA, pointB);

            Assert.AreEqual(0, distance,0.0001);
        }

        [TestMethod]
        public void CuntureDistance1()
        {
            Point[][] cuntureA = new Point[][]
            {
                new Point[]
                {
                    new Point(0,0),
                    new Point(1,0),
                    new Point(0,1),
                    new Point(1,1),
                },
            };

            Point[][] cuntureB = new Point[][]
            {
                new Point[]
                {
                    new Point(0,0),
                    new Point(1,0),
                    new Point(0,1),
                    new Point(1,2),
                },
            };

            double distance = HelperMath.CuntureDistance(cuntureA,cuntureB);

            Assert.AreEqual(1, distance, 0.0001);
        }

        [TestMethod]
        public void CuntureDistance2()
        {
            Point[][] cuntureA = new Point[][]
            {
                new Point[]
                {
                    new Point(0,0),
                    new Point(1,0),
                    new Point(0,1),
                    new Point(1,1),
                },
                new Point[]
                {
                    new Point(5,5),
                    new Point(6,5),
                    new Point(5,6),
                    new Point(6,6),
                },
            };

            Point[][] cuntureB = new Point[][]
            {
                new Point[]
                {
                    new Point(0,0),
                    new Point(1,5),
                    new Point(1,1),
                    new Point(1,2),
                },
                new Point[]
                {
                    new Point(4,5),
                    new Point(6,5),
                    new Point(5,6),
                    new Point(6,6),
                },
            };

            double distance = HelperMath.CuntureDistance(cuntureA, cuntureB);

            Assert.AreEqual(8, distance, 0.0001);
        }

        [TestMethod]
        public void ParsePoint2fToPoint()
        {
            Point2f[] p2f = new Point2f[]
            {
                new Point2f(1.4f,42.2f),
                new Point2f(1.7f,42.3f),
                new Point2f(4.4f,42.8f),
            };

            Point[] points = HelperMath.ParsePoint2fToPoint(p2f);

            Point[] res = new Point[]
            {
                new Point(1,42),
                new Point(1,42),
                new Point(4,42),
            };

            CollectionAssert.AreEqual(points, res);
        }
    }
}

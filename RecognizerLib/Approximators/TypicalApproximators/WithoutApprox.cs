using System.Collections.Generic;
using System.Linq;
using OpenCvSharp;
using RecognizerLib.Сontracts;

namespace RecognizerLib.Approximators
{
    public class WithoutApprox : IApproxPoints
    {
        readonly double? _perimeterLimit;
        public WithoutApprox(double? perimeterLimit = null)
        {
            this._perimeterLimit = perimeterLimit;
        }
        public Point[][] ApproxPoints(Point[][] points)
        {
            LinkedList<Point[]> newPoints = new LinkedList<Point[]>();
            for (int i = 0; i < points.Length; i++)
            {
                double perimeter = Cv2.ArcLength(points[i], true);

                if (_perimeterLimit == null || perimeter > _perimeterLimit)
                {
                    newPoints.AddLast(points[i]);
                }
            }
            return newPoints.ToArray();
        }
    }
}

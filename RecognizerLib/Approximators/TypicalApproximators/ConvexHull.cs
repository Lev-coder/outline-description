using System.Collections.Generic;
using System.Linq;
using OpenCvSharp;
using RecognizerLib.Сontracts;

namespace RecognizerLib.Approximators
{
    public class ConvexHull : IApproxPoints
    {
        readonly double? _perimeterLimit;

        public ConvexHull(double? perimeterLimit = null)
        {
            this._perimeterLimit = perimeterLimit;
        }
        public Point[][] ApproxPoints(Point[][] points)
        {
            LinkedList<Point[]> vectorApproxPoints = new LinkedList<Point[]>();
            for (int i = 0; i < points.Length; i++)
            {
                double perimeter = Cv2.ArcLength(points[i], true);
                if (_perimeterLimit == null || perimeter > _perimeterLimit)
                {
                    Point[] approxPoints = Cv2.ConvexHull(points[i], false);
                    vectorApproxPoints.AddLast(approxPoints);
                }
            }
            return vectorApproxPoints.ToArray();
        }
    }
}

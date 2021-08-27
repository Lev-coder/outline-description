using RecognizerLib.Сontracts;
using System.Collections.Generic;
using System.Linq;
using OpenCvSharp;

namespace RecognizerLib.Approximators
{
    public class PolyDP : IApproxPoints
    {
        readonly double? _perimeterLimit;
        public PolyDP(double? perimeterLimit = null)
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
                    double mistake = 0.02 * perimeter;
                    Point[] approxPoints = Cv2.ApproxPolyDP(points[i], mistake, true);
                    vectorApproxPoints.AddLast(approxPoints);
                }
            }
            return vectorApproxPoints.ToArray();
        }
    }
}

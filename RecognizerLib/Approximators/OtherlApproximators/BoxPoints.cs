using RecognizerLib.Сontracts;
using OpenCvSharp;

namespace RecognizerLib.Approximators
{
    public class BoxPointsApprox : IApproxPoints
    {
        readonly IApproxPoints _beforeApprox;

        public BoxPointsApprox(IApproxPoints beforeApprox)
        {
            this._beforeApprox = beforeApprox;
        }

        public Point[][] ApproxPoints(Point[][] points)
        {
            Point[][] beforeApproxPoints = _beforeApprox.ApproxPoints(points);

            Point[][] approxPoints = new Point[beforeApproxPoints.Length][];

            for (int j = 0; j < beforeApproxPoints.Length; j++)
            {
                RotatedRect rect = Cv2.MinAreaRect(points[j]);
                Point2f[] boxPoints = Cv2.BoxPoints(rect);
                approxPoints[j] = HelperMath.ParsePoint2fToPoint(boxPoints);
            }

            return approxPoints;
        }
    }
}

using OpenCvSharp;

namespace RecognizerLib.Сontracts
{
    public interface IApproxPoints
    {
        Point[][] ApproxPoints(Point[][] points);
    }
}

using OpenCvSharp;

namespace RecognizerLib.Сontracts
{
    public interface IContursRecogniz
    {
        Point[][] ContursRecogniz(Mat imgMat, bool showImgFlag = false, bool showPointFlas = false);
    }
}

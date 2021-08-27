using OpenCvSharp;

namespace RecognizerLib.Сontracts
{
    public abstract class LoverUpperPrepareImage : IBasePrepareImage
    {
        public int lowerThresh = 0;
        public int upperThresh = 255;
        public abstract Mat PrepareImage(Mat imgMat, int lowerThresh, int upperThresh);
    }
}

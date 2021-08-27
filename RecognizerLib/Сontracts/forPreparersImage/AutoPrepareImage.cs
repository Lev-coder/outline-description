using OpenCvSharp;

namespace RecognizerLib.Сontracts
{
    public abstract class AutoPrepareImage : IBasePrepareImage
    {
        public abstract Mat PrepareImage(Mat imgMat);
    }
}

using OpenCvSharp;

namespace RecognizerLib.Сontracts
{
    public abstract class HSVPrepareImage : IBasePrepareImage
    {
        public int loverH = 0;
        public int loverS = 0;
        public int loverV = 0;

        public int upperH = 255;
        public int upperS = 255;
        public int upperV = 255;

        public abstract Mat PrepareImage(Mat imgMat, Scalar loverHSV, Scalar upperHSV);

    }
}

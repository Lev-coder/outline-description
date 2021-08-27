using RecognizerLib.Сontracts;
using OpenCvSharp;

namespace RecognizerLib.PreparersImage
{
    public class Binary : AutoPrepareImage
    {
        public override Mat PrepareImage(Mat imgMat)
        {
            Mat grayMat = new Mat();
            Cv2.CvtColor(imgMat, grayMat, ColorConversionCodes.BGR2GRAY);

            Mat binaryMat = new Mat();
            Cv2.Threshold(grayMat, binaryMat, 128, 255, ThresholdTypes.Binary | ThresholdTypes.Otsu);
            //Cv2.ImShow("BINARY", binaryMat);

            return binaryMat;
        }
    }
}

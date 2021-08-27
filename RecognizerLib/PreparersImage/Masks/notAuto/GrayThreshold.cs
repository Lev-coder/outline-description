using OpenCvSharp;
using RecognizerLib.Сontracts;

namespace RecognizerLib.PreparersImage
{
    public class GrayThreshold : LoverUpperPrepareImage
    {
        public override Mat PrepareImage(Mat imgMat,int lowerThresh, int upperThresh)
        {
            Mat grayImgMat = new Mat();
            Cv2.CvtColor(imgMat, grayImgMat, ColorConversionCodes.BGR2GRAY);

            Mat matThreshold = new Mat();
            Cv2.Threshold(grayImgMat, matThreshold, lowerThresh, upperThresh, ThresholdTypes.BinaryInv);

            return matThreshold;
        }
    }
}

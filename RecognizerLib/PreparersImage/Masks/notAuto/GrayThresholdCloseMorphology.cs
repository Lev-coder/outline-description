using OpenCvSharp;
using RecognizerLib.Сontracts;

namespace RecognizerLib.PreparersImage
{
    public class GrayThresholdCloseMorphology : LoverUpperPrepareImage
    {
        public override Mat PrepareImage(Mat imgMat, int lowerThresh, int upperThresh)
        {
            Mat grayImgMat = new Mat();
            Cv2.CvtColor(imgMat, grayImgMat, ColorConversionCodes.BGR2GRAY);

            Mat noNoise = new Mat();
            Cv2.MorphologyEx(grayImgMat, noNoise, MorphTypes.Dilate, null);
            Cv2.MorphologyEx(noNoise, noNoise, MorphTypes.Close, null);

            Mat matThreshold = new Mat();
            Cv2.Threshold(noNoise, matThreshold, lowerThresh, upperThresh, ThresholdTypes.BinaryInv);

            return matThreshold;
        }
    }
}

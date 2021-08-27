using OpenCvSharp;
using RecognizerLib.Сontracts;

namespace RecognizerLib.PreparersImage
{
    public class AbsoluteDifference : LoverUpperPrepareImage
    {
        public override Mat PrepareImage(Mat imgMat, int lowerThresh, int upperThresh)
        {
            //
            Mat grayImgMat = new Mat();
            Cv2.CvtColor(imgMat, grayImgMat, ColorConversionCodes.BGR2GRAY);

            //
            Mat matThreshold = new Mat();
            Cv2.Threshold(grayImgMat, matThreshold, lowerThresh, upperThresh, ThresholdTypes.Binary);

            //
            Mat kernal = Cv2.GetStructuringElement(MorphShapes.Rect, new Size(5, 5));
            Mat dilate = new Mat();
            Cv2.MorphologyEx(matThreshold, dilate, MorphTypes.Dilate, kernal);

            //
            Mat diff = new Mat();
            Cv2.Absdiff(dilate, matThreshold, diff);

            return diff;
        }
    }
}

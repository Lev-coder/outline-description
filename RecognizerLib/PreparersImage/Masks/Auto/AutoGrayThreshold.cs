using System;
using OpenCvSharp;
using RecognizerLib.Сontracts;

namespace RecognizerLib.PreparersImage
{
    public class AutoGrayThreshold : AutoPrepareImage
    {
        readonly float _sigma;
        public AutoGrayThreshold(float sigma = 0.33f)
        {
            this._sigma = sigma;
        }
        public override Mat PrepareImage(Mat imgMat)
        {
            //
            Mat grayImgMat = new Mat();
            Cv2.CvtColor(imgMat, grayImgMat, ColorConversionCodes.BGR2GRAY);

            //
            Tuple<int, int> loverUpper = HelperMath.getLoverAndUpperThresh(grayImgMat, _sigma);

            //
            Mat matThreshold = new Mat();
            Cv2.Threshold(grayImgMat, matThreshold, loverUpper.Item1, loverUpper.Item2, ThresholdTypes.BinaryInv);

            Cv2.MorphologyEx(matThreshold, matThreshold, MorphTypes.Dilate, null);
            Cv2.MorphologyEx(matThreshold,matThreshold,MorphTypes.Close,null);

            return matThreshold;
        }
    }
}

using System;
using System.Threading.Tasks;
using OpenCvSharp;
using RecognizerLib.Сontracts;

namespace RecognizerLib.PreparersImage
{
    public class AutoCanny : AutoPrepareImage
    {
        readonly float _sigma;
        public AutoCanny(float sigma = 0.33f)
        {
            this._sigma = sigma;
        }

        public override Mat PrepareImage(Mat imgMat)
        {
            //
            Mat grayImgMat = new Mat();
            Cv2.CvtColor(imgMat, grayImgMat, ColorConversionCodes.BGR2GRAY,3);

            //
            Mat matBlur = new Mat();
            Cv2.GaussianBlur(grayImgMat, matBlur, new Size(5, 5), 2);

            //
            Tuple<int, int> loverUpper = HelperMath.getLoverAndUpperThresh(matBlur, _sigma);

            //
            Mat cannyImgMat = new Mat();
            Cv2.Canny(matBlur,cannyImgMat, loverUpper.Item1, loverUpper.Item2);

            return cannyImgMat;
        }
    }
}

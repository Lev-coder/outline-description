using OpenCvSharp;
using RecognizerLib.Сontracts;

namespace RecognizerLib.PreparersImage
{
    public class CannyBlur : LoverUpperPrepareImage
    {
        public override Mat PrepareImage(Mat imgMat,int lowerThresh,int upperThresh)
        {
            Mat grayImgMat = new Mat();
            Cv2.CvtColor(imgMat, grayImgMat, ColorConversionCodes.BGR2GRAY);

            Mat matBlur = new Mat();
            Cv2.GaussianBlur(grayImgMat, matBlur, new Size(3, 3), 1);

            Mat cannyImgMat = new Mat();
            Cv2.Canny(matBlur, cannyImgMat, lowerThresh, upperThresh);

            return cannyImgMat;
        }
    }
}

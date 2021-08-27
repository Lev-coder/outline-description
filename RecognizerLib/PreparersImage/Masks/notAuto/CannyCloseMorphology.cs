using OpenCvSharp;
using RecognizerLib.Сontracts;

namespace RecognizerLib.PreparersImage
{
    public class CannyCloseMorphology : LoverUpperPrepareImage
    {
        public override Mat PrepareImage(Mat imgMat, int lowerThresh, int upperThresh)
        {
            CannyBlur cannyBlur = new CannyBlur();
            Mat cannyImgMat = cannyBlur.PrepareImage(imgMat, lowerThresh, upperThresh);

            Cv2.MorphologyEx(cannyImgMat, cannyImgMat, MorphTypes.Close, null);

            return cannyImgMat;
        }
    }
}

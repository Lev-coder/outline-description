using RecognizerLib.Сontracts;
using  OpenCvSharp;

namespace RecognizerLib.PreparersImage
{
    public class MaskByHVS : HSVPrepareImage
    {
        public override Mat PrepareImage(Mat imgMat, Scalar loverHSV ,Scalar upperHSV)
        {
            Mat matHsv = new Mat();
            Cv2.CvtColor(imgMat, matHsv, ColorConversionCodes.BGR2HSV);

            Mat mask = new Mat();
            Cv2.InRange(matHsv, loverHSV, upperHSV,mask);

            Mat grayMat = new Mat();
            Cv2.CvtColor(imgMat,grayMat,ColorConversionCodes.BGR2GRAY);

            Mat result = new Mat();
            Cv2.BitwiseAnd(grayMat, mask, result);

            return result;
        }
    }
}

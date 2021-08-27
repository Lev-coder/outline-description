using OpenCvSharp;
using RecognizerLib.Сontracts;

namespace RecognizerLib.PreparersImage
{
    public class CannyOfBGR : LoverUpperPrepareImage
    {
        public override Mat PrepareImage(Mat imgMat, int lowerThresh, int upperThresh)
        {
            Mat[] bgrMats = Cv2.Split(imgMat);

            foreach (var bgrMat in bgrMats)
            {
                Cv2.Canny(bgrMat, bgrMat, lowerThresh, upperThresh);
            }

            Mat resMat = new Mat();
            Cv2.BitwiseAnd(bgrMats[0], bgrMats[1], resMat);
            Cv2.BitwiseAnd(resMat, bgrMats[2], resMat);

            return resMat;
        }
    }
}

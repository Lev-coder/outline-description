using OpenCvSharp;
using RecognizerLib.Сontracts;

namespace RecognizerLib.PreparersImage
{
    public class AbsoluteDifferenceCloseMorphology : LoverUpperPrepareImage
    {
        public override Mat PrepareImage(Mat imgMat, int lowerThresh, int upperThresh)
        {

            AbsoluteDifference absoluteDifference = new AbsoluteDifference();
            Mat diffrenceMat = absoluteDifference.PrepareImage(imgMat,lowerThresh,upperThresh);

            Cv2.MorphologyEx(diffrenceMat,diffrenceMat,MorphTypes.Close,null);

            return diffrenceMat;
        }
    }
}
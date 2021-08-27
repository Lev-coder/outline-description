using System;
using System.Threading.Tasks;
using OpenCvSharp;
using RecognizerLib.Сontracts;

namespace RecognizerLib.PreparersImage
{
    public class AutoCannyOfBGR : AutoPrepareImage
    {
        private float _sigma;
        public AutoCannyOfBGR(float sigma = 0.33f)
        {
            this._sigma = sigma;
        }

        public override Mat PrepareImage(Mat imgMat)
        {
            Mat newMat = new Mat();
            imgMat.ConvertTo(newMat,-1,1,40);
            Cv2.MedianBlur(newMat, newMat,5);
            
            Mat[] bgrMats = Cv2.Split(newMat);

            for (int i = 0; i < bgrMats.Length; i++)
            {
                //
                Tuple<int, int> loverUpper = HelperMath.getLoverAndUpperThresh(bgrMats[i], _sigma);

                Cv2.Canny(bgrMats[i], bgrMats[i], loverUpper.Item1, loverUpper.Item2);
            }

            Mat resMat = new Mat();
            Cv2.BitwiseAnd(bgrMats[0], bgrMats[1], resMat);
            Cv2.BitwiseAnd(resMat, bgrMats[2], resMat);

            return resMat;
        }
    }
}

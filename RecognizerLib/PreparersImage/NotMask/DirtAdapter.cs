using OpenCvSharp;
using RecognizerLib.Сontracts;

namespace RecognizerLib.PreparersImage.NotMask
{
    /// <summary>
    /// использует класс ,которые автоматически находит маску и отдает общие элементы кадров
    /// </summary>
    public class DirtAdapter : AutoPrepareImage
    {
        readonly IBasePrepareImage _basePrepareImage;
        readonly CleanFrame _cleanFrame;
        public DirtAdapter(IBasePrepareImage basePrepareImage,int limitOfFrame = 3)
        {
            this._basePrepareImage = basePrepareImage;
            this._cleanFrame = new CleanFrame(limitOfFrame);
        }
        public override Mat PrepareImage(Mat imgMat)
        {
            AutoPrepareImage autoPrepare = ( AutoPrepareImage )_basePrepareImage;

            //нахождения маски
            Mat prepareMat = autoPrepare.PrepareImage(imgMat);
            //нахождение общих частей
            Mat commonElements = _cleanFrame.PushFrame(prepareMat);

            return commonElements;
        }
    }
}

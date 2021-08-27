using System.Threading.Tasks;
using OpenCvSharp;
using RecognizerLib.Recognizs;
using RecognizerLib.Сontracts;

namespace RecognizerLib
{
    public class Recogniz : BaseRecognizer, IContursRecogniz
    {
        private IBasePrepareImage prepare;
        private IApproxPoints approx;
        private IFindContours find;

        public Recogniz(IBasePrepareImage prepare, IApproxPoints approx, IFindContours find) : base(prepare)
        {
            this.prepare = prepare;
            this.approx = approx;
            this.find = find;
        }

        public Point[][] ContursRecogniz(Mat imgMat, bool showImgFlag = false, bool showPointFlas = false)
        {
            Mat cleanImgMat = null;
            //упрощение контура
            if (prepare is AutoPrepareImage)
            {
                AutoPrepareImage autoPrepare = (AutoPrepareImage)prepare;
                cleanImgMat = autoPrepare.PrepareImage(imgMat);
            }
            else if (prepare is LoverUpperPrepareImage)
            {
                LoverUpperPrepareImage handLoverUpperPrepare = (LoverUpperPrepareImage)prepare;

                handLoverUpperPrepare.lowerThresh = Cv2.GetTrackbarPos("lower", "Trackbar");
                handLoverUpperPrepare.upperThresh = Cv2.GetTrackbarPos("upper", "Trackbar");

                //подготовить изображение
                cleanImgMat = handLoverUpperPrepare.PrepareImage(imgMat, handLoverUpperPrepare.lowerThresh
                                                                        , handLoverUpperPrepare.upperThresh);
            }
            else if(prepare is HSVPrepareImage)
            {
                HSVPrepareImage handHsvPrepareImage = (HSVPrepareImage)prepare;


                handHsvPrepareImage.loverH = Cv2.GetTrackbarPos("loverH", "HSVTrackbar");
                handHsvPrepareImage.loverS = Cv2.GetTrackbarPos("loverS", "HSVTrackbar");
                handHsvPrepareImage.loverV = Cv2.GetTrackbarPos("loverV", "HSVTrackbar");

                handHsvPrepareImage.upperH = Cv2.GetTrackbarPos("upperH", "HSVTrackbar");
                handHsvPrepareImage.upperS = Cv2.GetTrackbarPos("upperS", "HSVTrackbar");
                handHsvPrepareImage.upperV = Cv2.GetTrackbarPos("upperV", "HSVTrackbar");

                Scalar loverHSV = new Scalar(handHsvPrepareImage.loverH,
                                            handHsvPrepareImage.loverS,
                                            handHsvPrepareImage.loverV);

                Scalar upperHSV = new Scalar(handHsvPrepareImage.upperH, 
                                            handHsvPrepareImage.upperS, 
                                            handHsvPrepareImage.upperV);

                cleanImgMat = handHsvPrepareImage.PrepareImage(imgMat, loverHSV, upperHSV);
            }

            //найти контуры
            Point[][] points = find.FindContours(cleanImgMat).Item1;

            //уменьшить количество точек,которые описывают объект
            points = approx.ApproxPoints(points);

            //нарисовать контуры 
            //Task.Run(() => DrawContours(imgMat, points, new Scalar(0, 255, 255)) );
            DrawContours(imgMat, points, new Scalar(0, 255, 255));

            //
            if (showPointFlas)
            {
                //показать точки контура
                Task.Run( () => PutPoints(points, imgMat) );
            }

            //показать изображение
            if (showImgFlag)
            {
                Cv2.ImShow("cleanImgMat", cleanImgMat);
                Cv2.ImShow("imgMat", imgMat);
                //Cv2.WaitKey();
            }

            return points;
        }
    }
}

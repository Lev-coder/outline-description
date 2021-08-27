using System.Collections.Generic;
using OpenCvSharp;
using RecognizerLib.Сontracts;

namespace RecognizerLib.Recognizs
{
    public class BaseRecognizer
    {
        readonly IBasePrepareImage _prepare;
        protected BaseRecognizer()
        {}

        protected BaseRecognizer(IBasePrepareImage prepare)
        {
            this._prepare = prepare;

            MakeTrackbar(this._prepare);
        }

        protected void MakeTrackbar(IBasePrepareImage prepare)
        {
            if (prepare is LoverUpperPrepareImage)
            {
                Cv2.NamedWindow("Trackbar");

                LoverUpperPrepareImage handLoverUpperPrepare = (LoverUpperPrepareImage)prepare;

                Cv2.CreateTrackbar("lower", "Trackbar", ref handLoverUpperPrepare.lowerThresh, 255);
                Cv2.CreateTrackbar("upper", "Trackbar", ref handLoverUpperPrepare.upperThresh, 255);
            }
            else if (prepare is HSVPrepareImage)
            {
                Cv2.NamedWindow("HSVTrackbar");

                HSVPrepareImage handPrepare = (HSVPrepareImage)prepare;

                Cv2.CreateTrackbar("loverH", "HSVTrackbar", ref handPrepare.loverH, 255);
                Cv2.CreateTrackbar("loverS", "HSVTrackbar", ref handPrepare.loverS, 255);
                Cv2.CreateTrackbar("loverV", "HSVTrackbar", ref handPrepare.loverV, 255);

                Cv2.CreateTrackbar("upperH", "HSVTrackbar", ref handPrepare.upperH, 255);
                Cv2.CreateTrackbar("upperS", "HSVTrackbar", ref handPrepare.upperS, 255);
                Cv2.CreateTrackbar("upperV", "HSVTrackbar", ref handPrepare.upperV, 255);
            }
        }

        /// <summary>
        /// Рисует все контуры
        /// </summary>
        /// <param name="imgMat">изображение для контуров</param>
        /// <param name="vectorapproxPoints">точки контуров</param>
        /// <param name="colorContours">цвет контуров</param>
        /// <param name="widthContours">ширена контуров</param>
        public virtual void DrawContours(Mat imgMat, IEnumerable<IEnumerable<Point>> points,
                                          Scalar colorContours, int widthContours = 2)
        {
            Cv2.DrawContours(imgMat, points, -1, colorContours, widthContours);
        }

        public virtual void PutPoints(Point[][] points, Mat ImgMat)
        {
            foreach (Point[] approxPoints in points)
            {
                foreach (Point point in approxPoints)
                {
                    //string coordinates = string.Format("({0};{1})", point.X, point.Y);
                    Cv2.PutText(ImgMat,".", point, HersheyFonts.HersheyComplex, 5, new Scalar(255, 0, 255));
                }
            }
        }
    }
}

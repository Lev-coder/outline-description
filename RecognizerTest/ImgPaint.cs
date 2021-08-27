using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using OpenCvSharp;
using System.Drawing;

using Point = OpenCvSharp.Point;

namespace Recognizer
{
    public class ImgPaint
    {
        //путь к папке с фотографиями "Recognizer\RecognizerTest\bin\Debug\imgs"
        private string _pathFormImg = null;
        private int _widthImg;
        private int _heightImg;

        public ImgPaint(int widthImg = 300, int heightImg = 300)
        {
            var path = Directory.GetCurrentDirectory();
            path = Path.Combine(path, "imgs");

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            _pathFormImg = path;
            _widthImg = widthImg;
            _heightImg = heightImg;
        }
        public Mat LoadImg(string fileName)
        {
            string pathToImg = Path.Combine(_pathFormImg, fileName);
            Mat mat = Cv2.ImRead(pathToImg);
            return mat;
        }

        public Mat DrawLine(Point start,Point end, Scalar color, string fileName = "line.png", bool showImgFlag = false,
                            bool showPointFlas = false, bool writeFlag = false)
        {
            string pathToImg = Path.Combine(_pathFormImg, fileName);

            if (writeFlag && File.Exists(pathToImg))
            {
                return Cv2.ImRead(pathToImg);
            }
            PrepareFile(pathToImg);
            Mat limeMat = Cv2.ImRead(pathToImg);

            Cv2.Line(limeMat,start, end, color);
            Cv2.ImWrite(pathToImg, limeMat);

            if (showImgFlag == true)
            {
                Cv2.ImShow(fileName, limeMat);
                Cv2.WaitKey(3000);
            }
            return limeMat;
        }

        public Mat DrawRectangle(int x, int y, int width, int height, Scalar color,string fileName = "rectangle.png",
                                bool showFlag = false, bool writeFlag = false)
        {
            string pathToImg = Path.Combine(_pathFormImg, fileName);

            if (writeFlag && File.Exists(pathToImg))
            {
                return Cv2.ImRead(pathToImg);
            }
            PrepareFile(pathToImg);
            Mat rectangleMat = Cv2.ImRead(pathToImg);
            var rectangle = new Rect(x, y, width, height);
            Cv2.Rectangle(rectangleMat, rectangle, color);
            Cv2.ImWrite(pathToImg, rectangleMat);

            if (showFlag == true)
            {
                Cv2.ImShow(fileName, rectangleMat);
                Cv2.WaitKey(3000);
            }
            return rectangleMat;
        }

        public Mat DrawRectangle2(Mat rectangleMat,int x, int y, int width, int height, Scalar color, string fileName = "rectangle2.png",
                        bool showFlag = false, bool writeFlag = false)
        {
            string pathToImg = Path.Combine(_pathFormImg, fileName);

            if (writeFlag && File.Exists(pathToImg))
            {
                return Cv2.ImRead(pathToImg);
            }
            PrepareFile(pathToImg);

            var rectangle = new Rect(x, y, width, height);
            Cv2.Rectangle(rectangleMat, rectangle, color);
            Cv2.ImWrite(pathToImg, rectangleMat);

            if (showFlag == true)
            {
                Cv2.ImShow(fileName, rectangleMat);
                Cv2.WaitKey(3000);
            }
            return rectangleMat;
        }

        public Mat DrawTriangle(Point p1, Point p2, Point p3, Scalar color,string fileName = "trianglee.png",
                                bool showFlag = false, bool writeFlag = false)
        {
            string pathToImg = Path.Combine(_pathFormImg, fileName);

            if (writeFlag && File.Exists(pathToImg))
            {
                return Cv2.ImRead(pathToImg);
            }
            PrepareFile(pathToImg);
            Mat triangleMat = Cv2.ImRead(pathToImg);

            Cv2.Line(triangleMat, p1, p2, color);
            Cv2.Line(triangleMat, p1, p3, color);
            Cv2.Line(triangleMat, p2, p3, color);

            Cv2.ImWrite(pathToImg, triangleMat);

            if (showFlag == true)
            {
                Cv2.ImShow(fileName, triangleMat);
                Cv2.WaitKey(3000);
            }

            return triangleMat;
        }


        public Mat DrawEllipse(Point2f center, Size2f r, float angle, Scalar color,string fileName = "elips.png",
                                bool showFlag = false, bool writeFlag = false)
        {
            string pathToImg = Path.Combine(_pathFormImg, fileName);

            if (writeFlag && File.Exists(pathToImg))
            {
                return Cv2.ImRead(pathToImg);
            }

            PrepareFile(pathToImg);
            Mat elipsMat = Cv2.ImRead(pathToImg);

            var elipse = new RotatedRect(center, r, angle);
            Cv2.Ellipse(elipsMat, elipse, color);
            Cv2.ImWrite(pathToImg, elipsMat);

            if (showFlag == true)
            {
                Cv2.ImShow(fileName, elipsMat);
                Cv2.WaitKey(3000);
            }
            return elipsMat;
        }


        /// <summary>
        /// создание файла 
        /// </summary>
        /// <param name="pathToImg">путь к файлу</param>
        private void PrepareFile(string pathToImg)
        {
            Bitmap bitmap = new Bitmap(_widthImg, _heightImg);
            bitmap.Save(pathToImg);
        }
    }
}

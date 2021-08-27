using System.Collections.Generic;
using System.Threading.Tasks;
using OpenCvSharp;
using RecognizerLib.Сontracts;

namespace RecognizerLib.CatchСontours
{
    public class CatchСontoursFromVideo : ICatchСontours
    {
        private int cameraIndex;
        private VideoCaptureAPIs videoCaptureAPIs;
        private IContursRecogniz recogniz;
        private VideoCapture videoCapture;

        /// <summary>
        /// инициализация по умолчанию
        /// </summary>
        public CatchСontoursFromVideo()
        {
            this.cameraIndex = 0;
            this.videoCaptureAPIs = VideoCaptureAPIs.ANY;
            this.recogniz = null;
            this.videoCapture = new VideoCapture(cameraIndex, videoCaptureAPIs);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="recogniz">распознователь контуров</param>
        /// <param name="cameraIndex">номер камеры, из которой будет братся информация</param>
        /// <param name="videoCaptureAPIs">выберите предпочтительный API</param>
        /// <param name="numThreads">количество потоков для операций из библиотеки Cv2</param>
        public CatchСontoursFromVideo(IContursRecogniz recogniz,int cameraIndex = 0, VideoCaptureAPIs videoCaptureAPIs = VideoCaptureAPIs.ANY)
        {
            this.cameraIndex = cameraIndex;
            this.videoCaptureAPIs = videoCaptureAPIs;
            this.recogniz = recogniz;
            this.videoCapture = new VideoCapture(cameraIndex, videoCaptureAPIs);
        }

        /// <summary>
        /// Метод предназначенный для откладке и оценки распознавания контуров на "глаз"
        /// </summary>
        /// <param name="showImgFlag">нужно ли показывать изображение?</param>
        /// <param name="showPointFlas">нужно ли показывать точки на изображении?</param>
        public void ISeeYou(int numThreads = 0,bool showImgFlag = true, bool showPointFlas = false)
        {
            Cv2.SetNumThreads(numThreads);
            Mat mat = new Mat();

            using (videoCapture)
            {
                while (true)
                {
                    videoCapture.Read(mat);
                    recogniz.ContursRecogniz(mat, showImgFlag, showPointFlas);
                    Cv2.WaitKey(1);
                }
            }
        }

        /// <summary>
        /// Возвращает точки ,полученные в результате обработки изображения
        /// </summary>
        /// <param name="showImgFlag">нужно ли показывать изображение?</param>
        /// <param name="showPointFlas">нужно ли показывать точки на изображении?</param>
        /// <returns>точки контуров</returns>
        public IEnumerable<Point[][]> GetPoints(int numThreads = 0, bool showImgFlag = false, bool showPointFlas = false)
        {
            Cv2.SetNumThreads(numThreads);
            Mat mat = new Mat();

            using (videoCapture)
            {
                while (true)
                {
                    videoCapture.Read(mat);
                    yield return recogniz.ContursRecogniz(mat, showImgFlag, showPointFlas); ;
                }
            }
        }

        /// <summary>
        /// асинхронно возвращает точки ,полученные в результате обработки изображения
        /// </summary>
        /// <param name="showImgFlag">нужно ли показывать изображение?</param>
        /// <param name="showPointFlas">нужно ли показывать точки на изображении?</param>
        /// <returns>точки контуров</returns>
        public async Task<Point[][]> GetPointsAsync(int numThreads = 0, bool showImgFlag = false, bool showPointFlas = false)
        {
            Cv2.SetNumThreads(numThreads);
            Mat mat = new Mat();
            
            using (videoCapture)
            {
                videoCapture.Read(mat);
                return await Task.Run(() => recogniz.ContursRecogniz(mat, showImgFlag, showPointFlas));
            }
        }

        public IEnumerable<Point[][]> GetPoints(IContursRecogniz thisRecogniz,int numThreads = 0, bool showImgFlag = false, bool showPointFlas = false)
        {
            Cv2.SetNumThreads(numThreads);
            Mat mat = new Mat();

            using (videoCapture)
            {
                while (true)
                {
                    videoCapture.Read(mat);
                    yield return thisRecogniz.ContursRecogniz(mat, showImgFlag, showPointFlas);
                }
            }
        }

        public async Task<Point[][]> GetPointsAsync(IContursRecogniz thisRecogniz,int numThreads = 0, bool showImgFlag = false, bool showPointFlas = false)
        {
            Cv2.SetNumThreads(numThreads);
            Mat mat = new Mat();

            using (videoCapture)
            {
                videoCapture.Read(mat);
                return await Task.Run(() => thisRecogniz.ContursRecogniz(mat, showImgFlag, showPointFlas));
            }
        }
    }
}

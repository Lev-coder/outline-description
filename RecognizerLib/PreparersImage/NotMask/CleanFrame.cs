using System.Collections.Generic;
using OpenCvSharp;

namespace RecognizerLib.PreparersImage
{
    /// <summary>
    /// Находит на изображениях общие черты и возвращает их
    /// </summary>
    public class CleanFrame
    {
        //очередь кадров
        private Queue<Mat> _frames = new Queue<Mat>();
        //лимит фреймов на основе которых вычисляются общие части
        readonly int _limitOfFrame;

        public CleanFrame(int limitOfFrame = 3)
        {
            this._limitOfFrame = limitOfFrame;
        }

        /// <summary>
        /// поставить маску кадра в очередь на обработку
        /// </summary>
        /// <param name="frame">маска кадра</param>
        /// <returns>общие элементы на всех масках кадра</returns>
        public Mat PushFrame(Mat frame)
        {
            if (_frames.Count == _limitOfFrame)
            {
                _frames.Dequeue();
            }
            _frames.Enqueue(frame);
            return GetCommonElements();
        }

        /// <summary>
        /// обрабатывает маски и возвращает общие элементы
        /// </summary>
        /// <returns>общие элементы на всех масках кадра</returns>
        private Mat GetCommonElements()
        {
            Mat result = _frames.Peek();

            foreach (var frame in _frames)
            {
                Cv2.BitwiseAnd(result,frame,result);
            }

            return result;
        }
    }
}

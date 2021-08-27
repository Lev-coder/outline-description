using System.Collections.Generic;
using System.Threading.Tasks;
using  RecognizerLib.Сontracts;
using  OpenCvSharp;

namespace RecognizerLib.CatchСontours
{
    public class MultiplesCatchContourFromVideo
    {
        private ICatchСontours catcher;

        public MultiplesCatchContourFromVideo(ICatchСontours catcher)
        {
            this.catcher = catcher;
        }

        public IEnumerable<IEnumerable<Point[][]>> GetPoints(IEnumerable<IContursRecogniz> recognizs,
                                    int numThreads = 0, bool showImgFlag = false, bool showPointFlas = false)
        {
            foreach (var recogniz in recognizs)
            {
                yield return catcher.GetPoints(recogniz, numThreads, showImgFlag, showPointFlas);
            }
        }

        public async Task<IEnumerable<Point[][]>> GetPointsAsync(IEnumerable<IContursRecogniz> recognizs, 
            int numThreads = 0,bool showImgFlag = false, bool showPointFlas = false)
        {
            LinkedList<Point[][]> pointsAsync = new LinkedList<Point[][]>();

            foreach (var recogniz in recognizs)
            {
               Point[][] points = catcher.GetPointsAsync(recogniz, numThreads, showImgFlag, showPointFlas).Result;
               pointsAsync.AddLast(points);
            }
            return pointsAsync;
        }
    }
}

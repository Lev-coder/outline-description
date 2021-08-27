using System.Collections.Generic;
using System.Threading.Tasks;
using OpenCvSharp;

namespace RecognizerLib.Сontracts
{
    public interface ICatchСontours
    {
        IEnumerable<Point[][]> GetPoints(int numThreads = 0, bool showImgFlag = false,
            bool showPointFlas = false);

        Task<Point[][]> GetPointsAsync(int numThreads = 0, bool showImgFlag = false, bool showPointFlag = false);
        IEnumerable<Point[][]> GetPoints(IContursRecogniz thisRecogniz,
            int numThreads = 0, bool showImgFlag = false, bool showPointFlag = false);

        Task<Point[][]> GetPointsAsync(IContursRecogniz thisRecogniz,
            int numThreads = 0, bool showImgFlag = false, bool showPointFlag = false);
    }
}

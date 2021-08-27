using System;
using OpenCvSharp;
using RecognizerLib.Сontracts;

namespace RecognizerLib.Finders
{
    public class TypicalFindContours : IFindContours
    {
        readonly ContourApproximationModes _metod;

        public TypicalFindContours(ContourApproximationModes metod = ContourApproximationModes.ApproxSimple)
        {
            this._metod = metod;
        }

        public Tuple<Point[][], HierarchyIndex[]> FindContours(Mat imgMat)
        {
            Point[][] points = null;
            HierarchyIndex[] hierarchyIndex = null;
            Cv2.FindContours(imgMat, out points, out hierarchyIndex,
                RetrievalModes.External, _metod);

            return new Tuple<Point[][], HierarchyIndex[]>(points,hierarchyIndex);
        }
    }
}

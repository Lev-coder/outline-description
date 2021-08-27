using System;
using OpenCvSharp;

namespace RecognizerLib.Сontracts
{
    public interface IFindContours
    {
        Tuple<Point[][], HierarchyIndex[]> FindContours(Mat imgMat);
    }
}

using System;
using OpenCvSharp;
using RecognizerLib.Сontracts;

namespace RecognizerLib.PreparersImage.Masks.Auto
{
    public class AutoMaskByHVS : AutoPrepareImage
    {
        readonly MaskByHVS _maskByHvs = new MaskByHVS();
        private readonly Tuple<Scalar, Scalar>[] _tuples;

        public AutoMaskByHVS(Tuple<Scalar, Scalar>[] tuples)
        {
            this._tuples = tuples;
        }

        public override Mat PrepareImage(Mat imgMat)
        {
            Mat result = _maskByHvs.PrepareImage(imgMat, _tuples[0].Item1, _tuples[0].Item2);

            for (int i = 1; i < _tuples.Length; i++)
            {
                result += _maskByHvs.PrepareImage(imgMat, _tuples[i].Item1, _tuples[i].Item2);
            }

            return result;
        }
    }
}

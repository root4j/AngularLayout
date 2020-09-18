using System;

namespace AngularLayout.Model.Common.Exceptions
{
    [Serializable]
    public class NonEqualObjectException : SystemException
    {
        public NonEqualObjectException() : base(Constants.EXCEPTION_MESSAGEKEY_NONEQUALOBJECT)
        {
        }
    }
}

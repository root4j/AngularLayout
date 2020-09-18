using System;

namespace AngularLayout.Model.Common.Exceptions
{
    [Serializable]
    public class NonObjectFoundException : SystemException
    {
        public NonObjectFoundException() : base(Constants.EXCEPTION_MESSAGEKEY_NONOBJECTFOUND)
        {
        }
    }
}
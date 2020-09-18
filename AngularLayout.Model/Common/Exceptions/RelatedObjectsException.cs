using System;

namespace AngularLayout.Model.Common.Exceptions
{
    [Serializable]
    public class RelatedObjectsException : SystemException
    {
        public RelatedObjectsException() : base(Constants.EXCEPTION_MESSAGEKEY_RELATEDOBJECTS)
        {
        }
    }
}
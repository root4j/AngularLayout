using System;

namespace AngularLayout.Model.Common.Exceptions
{
    [Serializable]
    public class EqualUniqueRowException : SystemException
    {
        public EqualUniqueRowException() : base(Constants.EXCEPTION_MESSAGEKEY_EQUALUNIQUEROW)
        {
        }
    }
}

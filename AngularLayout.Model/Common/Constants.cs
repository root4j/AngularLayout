using System.Collections.Generic;

namespace AngularLayout.Model.Common
{
    public static class Constants
    {
        public const string APP_POLICY = "SysOccrePolicy";

        #region Application Areas Constants
        public const string AREA_GENERAL = "General";
        #endregion

        #region Application Dictionaries
        public static Dictionary<string, string> AppDictionary { get; set; }
        public static Dictionary<string, string> AppSettings { get; set; }
        #endregion

        #region Exception Message Key Constants
        public const string EXCEPTION_MESSAGEKEY_RELATEDOBJECTS = "EXCEPTION_MESSAGEKEY_RELATEDOBJECTS";
        public const string EXCEPTION_MESSAGEKEY_NONOBJECTFOUND = "EXCEPTION_MESSAGEKEY_NONOBJECTFOUND";
        public const string EXCEPTION_MESSAGEKEY_NONEQUALOBJECT = "EXCEPTION_MESSAGEKEY_NONEQUALOBJECT";
        public const string EXCEPTION_MESSAGEKEY_EQUALUNIQUEROW = "EXCEPTION_MESSAGEKEY_EQUALUNIQUEROW";
        #endregion
    }
}

using MultilingualProject.Debugging;

namespace MultilingualProject
{
    public class MultilingualProjectConsts
    {
        public const string LocalizationSourceName = "MultilingualProject";

        public const string ConnectionStringName = "Default";

        public const bool MultiTenancyEnabled = true;


        /// <summary>
        /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
        /// </summary>
        public static readonly string DefaultPassPhrase =
            DebugHelper.IsDebug ? "gsKxGZ012HLL3MI5" : "4a6f68cfa4114062a67f016763d48b21";
    }
}

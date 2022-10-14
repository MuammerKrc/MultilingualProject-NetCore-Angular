using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace MultilingualProject.Localization
{
    public static class MultilingualProjectLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(MultilingualProjectConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(MultilingualProjectLocalizationConfigurer).GetAssembly(),
                        "MultilingualProject.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Domain.Entities;

namespace MultilingualProject
{
    public class TranslationDtoBase : EntityDto, IEntityTranslation
    {
        public TranslationDtoBase(string lang, bool isLanguageDisabled)
        {
            if (isLanguageDisabled)
            {
                var propertyInfos = GetType().GetProperties()
                    .Where(i => i.Name != "Language" &&
                                i.GetCustomAttributes(true)
                                    .Any(type => type.GetType() == typeof(RequiredAttribute))
                    );

                foreach (var propertyInfo in propertyInfos)
                {
                    if (propertyInfo.PropertyType == typeof(string))
                    {
                        propertyInfo.SetValue(this, $"[{propertyInfo.Name}-{lang}]".ToString());
                    }
                }
            }

            Language = lang;
            IsLanguageDisabled = isLanguageDisabled;
        }
        public TranslationDtoBase()
        {
        }
        [Required] public string Language { get; set; }
        public bool IsLanguageDisabled { get; set; }


    }
}

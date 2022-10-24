using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultilingualProject.WebApp.Languages.Dtos
{
    [AutoMapTo(typeof(ApplicationLanguage))]
    [AutoMapFrom(typeof(ApplicationLanguage))]
    public class LanguageDto : EntityDto<int>
    {
        public string DisplayName { get; set; }
        public string Icon { get; set; }
        public string Name { get; set; }
        public bool IsDisabled { get; set; }
        public bool IsActiveOnWeb { get; set; }
    }
}

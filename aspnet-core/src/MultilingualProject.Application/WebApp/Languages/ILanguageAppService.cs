using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using MultilingualProject.WebApp.Languages.Dtos;

namespace MultilingualProject.WebApp.Languages
{
    public interface ILanguageAppService : IAsyncCrudAppService<LanguageDto, int, PagedBaseResultRequestDto>
    {

    }
}

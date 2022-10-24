using Abp.Application.Services;
using System;
using MultilingualProject.WebApp.TextContents.Dto;

namespace MultilingualProject.WebApp.TextContents
{
    public interface ITextContentAppService : IAsyncCrudAppService<TextContentDto, Guid , PagedTextContentRequestDto>
    {

    }
}

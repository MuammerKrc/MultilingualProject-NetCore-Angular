using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using MultilingualProject.WebApp.Contacts.Dtos;

namespace MultilingualProject.WebApp.Contacts
{
    public interface IContactAppService:IAsyncCrudAppService<ContactDto,int,PagedBaseResultRequestDto>
    {

    }
}

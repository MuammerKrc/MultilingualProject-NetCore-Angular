using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Domain.Repositories;
using MultilingualProject.Entities.MultilingualEntities.Contacts;
using MultilingualProject.WebApp.Contacts.Dtos;

namespace MultilingualProject.WebApp.Contacts
{
    public class ContactAppService:AsyncCrudAppService<Contact,ContactDto,int,PagedBaseResultRequestDto>,IContactAppService
    {
        public ContactAppService(IRepository<Contact, int> repository) : base(repository)
        {
        }
    }
}

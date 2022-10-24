using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using MultilingualProject.Entities.MultilingualEntities.Contacts;

namespace MultilingualProject.WebApp.Contacts.Dtos
{
    [AutoMapFrom(typeof(Contact))]
    public class ContactDto : EntityDto<int>
    {
        public string NameSurname { get; set; }
        public string Email { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public bool IsApproved { get; set; }
    }
}

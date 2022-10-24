using Abp.Domain.Entities.Auditing;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;

namespace MultilingualProject.Entities.MultilingualEntities.Contacts
{
    public class Contact : Entity<int>
    {
        public string NameSurname { get; set; }
        public string Email { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public bool IsApproved { get; set; }
    }
}

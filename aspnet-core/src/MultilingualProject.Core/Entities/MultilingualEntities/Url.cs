using System;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;

namespace MultilingualProject.Entities.MultilingualEntities
{
    [Table("WebUrls")]
    public class Url : FullAuditedEntity
    {
        public string Value { get; set; }
        public string Parameters { get; set; }
        public string RedirectUrl { get; set; }
        public Guid? ItemPkId { get; set; }
        public string Language { get; set; }
        public string Discriminator { get; set; }
    }
}
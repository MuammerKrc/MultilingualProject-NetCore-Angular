using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MultilingualProject.Entities.MultilingualEntities.DisplayedServices
{
    public class DisplayedService : FullAuditedEntity<Guid>, IMultiLingualEntity<DisplayedServiceTranslation>
    {
        public string ImageUrl { get; set; }
        public int OrderNo { get; set; }
        public ICollection<DisplayedServiceTranslation> Translations { get; set; }
    }
}

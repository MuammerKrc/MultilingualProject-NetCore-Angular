using System;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;

namespace MultilingualProject.Entities.MultilingualEntities.DisplayedServices
{
    public class DisplayedServiceTranslation : Entity, IEntityTranslation<DisplayedService, Guid>
    {
        public string Language { get; set; }
        public DisplayedService Core { get; set; }
        public Guid CoreId { get; set; }

        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
    }
}

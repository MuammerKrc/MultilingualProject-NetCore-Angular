using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultilingualProject.Entities.MultilingualEntities.FAQs
{
    public class FaqTranslation : Entity, IEntityTranslation<Faq, Guid>
    {
        public string Language { get; set; }
        public Faq Core { get; set; }
        public Guid CoreId { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
    }
}

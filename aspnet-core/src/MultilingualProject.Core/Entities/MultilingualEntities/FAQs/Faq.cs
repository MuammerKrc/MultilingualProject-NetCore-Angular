using Abp.Domain.Entities.Auditing;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultilingualProject.Enums;

namespace MultilingualProject.Entities.MultilingualEntities.FAQs
{
    public class Faq : FullAuditedEntity<Guid>, IMultiLingualEntity<FaqTranslation>
    {
        public FaqCategoryType FaqCategoryType { get; set; }
        public ICollection<FaqTranslation> Translations { get; set; }
        public int OrderNo { get; set; }
    }
}

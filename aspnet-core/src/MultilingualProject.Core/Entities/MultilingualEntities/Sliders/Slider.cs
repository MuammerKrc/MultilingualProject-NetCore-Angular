using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;

namespace MultilingualProject.Entities.MultilingualEntities.Sliders
{
    public class Slider : FullAuditedEntity<Guid>, IMultiLingualEntity<SliderTranslation>
    {
        public int OrderNo { get; set; }
        public ICollection<SliderTranslation> Translations { get; set; }
    }
}

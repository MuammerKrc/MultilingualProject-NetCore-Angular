using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;

namespace MultilingualProject.Entities.MultilingualEntities.TextContents
{
    public class TextContent:FullAuditedEntity<Guid>,IMultiLingualEntity<TextContentTranslation>
    {
        public string Key { get; set; }
        public ICollection<TextContentTranslation> Translations { get; set; }
    }
}

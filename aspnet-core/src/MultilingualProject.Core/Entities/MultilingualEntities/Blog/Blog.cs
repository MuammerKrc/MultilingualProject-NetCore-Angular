using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;

namespace MultilingualProject.Entities.MultilingualEntities.Blog
{
    public class Blog : FullAuditedEntity<Guid>, IMultiLingualEntity<BlogTranslation>
    {
        public string CoverImagePath { get; set; }
        public ICollection<BlogTranslation> Translations { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;

namespace MultilingualProject.Entities.MultilingualEntities.TextContents
{
    public class TextContentTranslation:Entity,IEntityTranslation<TextContent,Guid>
    {
        public string Language { get; set; }
        public TextContent Core { get; set; }
        public Guid CoreId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string MenuTitle { get; set; }
        public string MetaTitle { get; set; }
        public string MetaDescription { get; set; }
        public string MetaKeywords { get; set; }
        public string Url { get; set; }
    }
}

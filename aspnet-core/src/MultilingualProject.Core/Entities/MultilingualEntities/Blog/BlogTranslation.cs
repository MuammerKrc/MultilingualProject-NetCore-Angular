using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities;

namespace MultilingualProject.Entities.MultilingualEntities.Blog
{
    public class BlogTranslation:Entity, IEntityTranslation<Blog,Guid>
    {
        public string Language { get; set; }
        public Blog Core { get; set; }
        public Guid CoreId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }

        public string MetaTitle { get; set; }
        public string MetaDescription { get; set; }
        public string MetaKeywords { get; set; }
    }
}

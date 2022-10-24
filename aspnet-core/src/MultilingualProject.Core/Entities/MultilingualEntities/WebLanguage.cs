using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities;

namespace MultilingualProject.Entities.MultilingualEntities
{
    public class WebLanguage : Entity<int>
    {
        public int LanguageId { get; set; }
    }
}

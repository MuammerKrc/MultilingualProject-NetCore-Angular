using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities;

namespace MultilingualProject.Entities.MultilingualEntities.MLObjects
{
    public class MLObject : Entity, IMultiLingualEntity<MLObjectTranslation>
    {
        public string Key { get; set; }
        public ICollection<MLObjectTranslation> Translations { get; set; }
    }
}

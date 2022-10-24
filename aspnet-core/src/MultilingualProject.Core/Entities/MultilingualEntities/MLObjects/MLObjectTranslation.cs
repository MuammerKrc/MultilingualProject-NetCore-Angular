using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities;

namespace MultilingualProject.Entities.MultilingualEntities.MLObjects
{
    [Table("MLObjectTranslation")]
    public class MLObjectTranslation : Entity, IEntityTranslation<MLObject>
    {
        public string Language { get; set; }
        public MLObject Core { get; set; }
        public int CoreId { get; set; }
        public string Value { get; set; }
    }
}

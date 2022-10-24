using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using MultilingualProject.Entities.MultilingualEntities.MLObjects;

namespace MultilingualProject.Entities.MultilingualEntities.Products
{
    public class ProductTranslation : Entity, IEntityTranslation<MLObject>
    {
        public string Language { get; set; }
        public MLObject Core { get; set; }
        public int CoreId { get; set; }
    }
}

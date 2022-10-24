using Abp.Domain.Entities;
using MultilingualProject.Entities.MultilingualEntities.MLObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultilingualProject.Entities.MultilingualEntities.Products
{
    public class ProductGroup : Entity<int>, IMultiLingualEntity<ProductGroupTranslation>
    {
        public ICollection<ProductGroupTranslation> Translations { get; set; }
        public ICollection<ProductGroup> ProductGroups { get; set; }
    }
}

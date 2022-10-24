using Abp.Domain.Entities;
using MultilingualProject.Entities.MultilingualEntities.MLObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultilingualProject.Entities.MultilingualEntities.Products
{
    public class Product : Entity<int>, IMultiLingualEntity<MLObjectTranslation>
    {
        public ICollection<MLObjectTranslation> Translations { get; set; }

        [ForeignKey("ProductGroup")]
        public int ProductGroupId { get; set; }
        public ProductGroup ProductGroup { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities;

namespace MultilingualProject.Entities.MultilingualEntities.Products
{
    public class ProductGroupTranslation:Entity, IEntityTranslation<ProductGroup>
    {
        public string Language { get; set; }
        public ProductGroup Core { get; set; }
        public int CoreId { get; set; }

    }
}

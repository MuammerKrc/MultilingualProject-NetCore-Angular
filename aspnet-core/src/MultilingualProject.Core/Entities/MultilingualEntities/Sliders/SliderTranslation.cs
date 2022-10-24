using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities;

namespace MultilingualProject.Entities.MultilingualEntities.Sliders
{
    public class SliderTranslation : Entity, IEntityTranslation<Slider>
    {
        public string Language { get; set; }
        public Slider Core { get; set; }
        public int CoreId { get; set; }
        public string Title { get; set; }
    }
}

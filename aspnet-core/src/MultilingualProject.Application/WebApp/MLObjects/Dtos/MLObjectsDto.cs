using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Domain.Entities;
using MultilingualProject.Entities.MultilingualEntities.MLObjects;

namespace MultilingualProject.WebApp.MLObjects.Dtos
{
    public class MLObjectsDto : EntityDto<int>, IMultiLingualEntity<MLObjectTranslation>
    {
        public string Key { get; set; }
        public ICollection<MLObjectTranslation> Translations { get; set; }
    }
}

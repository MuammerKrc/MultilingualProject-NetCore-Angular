using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities;

namespace MultilingualProject
{
    public interface IML<ITranslation> where ITranslation : class, IEntityTranslation
    {
        List<ITranslation> Translations { get; set; }
    }
}

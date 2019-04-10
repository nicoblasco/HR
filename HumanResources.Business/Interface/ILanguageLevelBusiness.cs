using HumanResource.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResources.Business.Interface
{
    public interface ILanguageLevelBusiness
    {
        List<LanguageLevel> GetAll();

        List<LanguageLevel> GetDuplicates(int id, string descripcion);

        LanguageLevel GetLanguageLevel(int Id);

        void Save(LanguageLevel  languageLevel);
    }
}

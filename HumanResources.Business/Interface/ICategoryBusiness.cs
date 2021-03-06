﻿using HumanResource.Domain;
using HumanResource.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResources.Business.Interface
{
    public interface ICategoryBusiness
    {
        string GetName(int Id);
        List<Categories> GetAllCategories();

        List<Categories> GetDuplicates(int id, string descripcion);

        Categories GetCategory(int Id);

        void Save(Categories category);
    }
}

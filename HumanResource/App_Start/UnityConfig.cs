using HumanResource.Controllers;
using HumanResource.Models;
using HumanResource.Repository.Infrastructure;
using HumanResource.Repository.Infrastructure.Contract;
using HumanResources.Business;
using HumanResources.Business.Interface;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data;
using System.Data.Common;
using System.Data.Entity;
using System.Web.Mvc;
using Unity;
using Unity.Injection;
using Unity.Lifetime;
using Unity.Mvc5;

namespace HumanResource
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            container.RegisterType<IUserStore<ApplicationUser>, UserStore<ApplicationUser>>();
            //container.RegisterType<IDbConnection, DbConnection>();
            //container.RegisterType<DbContext, ApplicationDbContext>(new HierarchicalLifetimeManager());
            //container.RegisterType<UserManager<ApplicationUser>>(new HierarchicalLifetimeManager());
            //container.RegisterType<IUserStore<ApplicationUser>, UserStore<ApplicationUser>>(new HierarchicalLifetimeManager());
            // TODO: Register your types here
            container.RegisterType<IUserStore<ApplicationUser>, UserStore<ApplicationUser>>();
            container.RegisterType<UserManager<ApplicationUser>>();
            container.RegisterType<DbContext, ApplicationDbContext>();
            container.RegisterType<ApplicationUserManager>();
            container.RegisterType<AccountController>(new InjectionConstructor());

            container.RegisterType<IBusinessSectorsBusiness, BusinessSectorsBusiness>();
            container.RegisterType<ICategoryBusiness, CategoryBusiness>();
            container.RegisterType<ICitiesBusiness, CitiesBusiness>();
            container.RegisterType<ICivilStatusBusiness, CivilStatusBusiness>();
            container.RegisterType<ICountriesBusiness, CountriesBusiness>();
            container.RegisterType<IDrivingCategoriesBusiness, DrivingCategoriesBusiness>();
            container.RegisterType<IIdentificationTypeBusiness, IdentificationTypeBusiness>();
            container.RegisterType<IKnowledgeBusiness, KnowledgeBusiness>();
            container.RegisterType<ILanguageLevelBusiness, LanguageLevelBusiness>();
            container.RegisterType<ILanguagesBusiness, LanguagesBusiness>();
            container.RegisterType<IRegionsBusiness, RegionsBusiness>();
            container.RegisterType<ISoftwareBusiness, SoftwareBusiness>();
            container.RegisterType<IStudiesLevelBusiness, StudiesLevelBusiness>();
            container.RegisterType<ISubCategoriesBusiness, SubCategoriesBusiness>();
            container.RegisterType<IUnitOfWork, UnitOfWork>();


            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}
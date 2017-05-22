using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;
using BusinessLogic.Interfaces;
using BusinessLogic;
using Data.Repositories;
using BusinessLogic.BL;
using Core.Interfaces;

namespace DependencyResolver
{
    public class Resolver : NinjectModule
    {
        public override void Load()
        {
            Bind(typeof(IProductBL)).To(typeof(ProductBL));
            Bind(typeof(IProdCategoryBL)).To(typeof(CategoryBL));
            Bind<IUOW>().To<UOW>();
        }
    }
}

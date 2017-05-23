using Core.Interfaces;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Interfaces;

namespace BusinessLogic.BL
{
    public class CategoryBL : GenericBL<Category>,IProdCategoryBL
    {
        public CategoryBL(IUOW UnitOfWork) : base(UnitOfWork)
        { 
        }

        public Category GetCategoryById(int Id)
        {
            return FindbyId<int>(Id);
        }

        public IEnumerable<Category> GetAllCategory()
        {
            return GetAllCategory();
        }
    }
}

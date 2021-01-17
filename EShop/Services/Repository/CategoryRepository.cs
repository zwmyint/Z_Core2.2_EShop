using EShop.Models;
using EShop.Services.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShop.Services.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _appDbContext;

        public CategoryRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<m_cls_Category> GetAllCategories => _appDbContext.Categories;
        
        //
        //public IEnumerable<m_cls_Category> GetAllCategories => new List<m_cls_Category>
        //{
        //    new m_cls_Category{CategoryId=1,CategoryName="Hard Candy",CategoryDescription = "Awesome and Delicious Hard Candy"},
        //    new m_cls_Category{CategoryId=2,CategoryName="Chocolate Candy",CategoryDescription="Scuptious Chocolate Candy"},
        //    new m_cls_Category{CategoryId=3, CategoryName="Fruit Candy",CategoryDescription="Sweet and Sour Fruit Candy"}
        //};



        //
    }
}

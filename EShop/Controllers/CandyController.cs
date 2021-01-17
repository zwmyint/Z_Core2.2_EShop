using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EShop.Services.IRepository;
using EShop.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EShop.Controllers
{
    public class CandyController : Controller
    {
        private readonly ICandyRepository _candyRepository;
        private readonly ICategoryRepository _categoryRepository;

        public CandyController(ICandyRepository candyRepository, ICategoryRepository categoryRepository)
        {
            _candyRepository = candyRepository;
            _categoryRepository = categoryRepository;
        }

        //
        public IActionResult List()
        {
            //1
            //return View(_candyRepository.GetAllCandy); 

            //2
            var candyListViewModel = new CandyListViewModel();
            candyListViewModel.Candies = _candyRepository.GetAllCandy;
            candyListViewModel.CurrentCategory = "BestSellers";
            return View(candyListViewModel);
        }

        //
        public IActionResult Details(int id)
        {
            var candy = _candyRepository.GetCandyById(id);
            if (candy == null)
                return NotFound();

            return View(candy);
        }

        //
    }
}
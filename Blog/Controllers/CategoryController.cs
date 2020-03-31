using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Core;
using Blog.Core.DbEntities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace Blog.Controllers
{
    
    public class CategoryController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryController(IUnitOfWork unitOfWork)  :base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        [Route("Category/{id}")]
        public IActionResult CategoryPosts(int id)
        {
            var posts = _unitOfWork.PostRepository.Find(x => x.CategoryId == id);
            return View(posts);
        }
        [Route("Category/Manage")]
        public IActionResult CategoryManagement()
        {
            var categories = _unitOfWork.CategoryRepository.GetAll();
            return View(categories);
        }
        [Route("Category/Add")]
        [HttpPost]
        public IActionResult Add(string Name)
        {
            _unitOfWork.CategoryRepository.Add(new Category(){Name = Name,Date = DateTime.UtcNow});
            _unitOfWork.Complete();
            return RedirectToAction("CategoryManagement");
        }
    }
}
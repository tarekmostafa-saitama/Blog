using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace Blog.Controllers
{
    
    public class CategoryController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        [Route("Category/{id}")]
        public IActionResult CategoryPosts(int id)
        {
            var posts = _unitOfWork.PostRepository.Find(x => x.CategoryId == id);
            return View(posts);
        }
   
    }
}
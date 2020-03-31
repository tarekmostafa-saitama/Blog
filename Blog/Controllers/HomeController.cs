using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Core;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [Route("Home")]
        public IActionResult Index()
        {
            var posts = _unitOfWork.PostRepository.GetAll().OrderByDescending(x => x.Date);
            return View(posts);
        }
    }
}
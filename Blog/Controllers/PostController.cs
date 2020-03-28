using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Core;
using Blog.Core.DbEntities;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
    public class PostController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;

        public PostController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [Route("Post/{id}")]
        public IActionResult Post(int id)
        {
            var post = _unitOfWork.PostRepository.Get(id);
            return View(post);
        }
        [HttpPost]
        public IActionResult Comment(Comment comment)
        {
            _unitOfWork.CommentRepository.Add(comment);
            _unitOfWork.Complete();
            return RedirectToAction("Post",new{id = comment.PostId});
        }
    }
}
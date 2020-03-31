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

        public PostController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [Route("Post/{id}")]
        public IActionResult Post(int id)
        {
            var post = _unitOfWork.PostRepository.Get(id);
            post.Comments = _unitOfWork.CommentRepository.Find(x => x.PostId == post.Id).ToList();
            return View(post);
        }
        [HttpPost]
        [Route("Comment/Add")]
        public IActionResult Comment(string commentData,int postId)
        {
            _unitOfWork.CommentRepository.Add(new Comment()
            {
                Content = commentData,
                PostId = postId,
                Date = DateTime.UtcNow
            });
            _unitOfWork.Complete();
            return RedirectToAction("Post",new{id = postId});
        }
        [HttpPost]
        [Route("Comment/Delete/{id}")]
        public IActionResult DeleteComment(int commentId,int postId)
        {
            var comment = _unitOfWork.CommentRepository.Get(commentId);
            _unitOfWork.CommentRepository.Remove(comment);
            _unitOfWork.Complete();
            return RedirectToAction("Post", new { id = postId });
        }
        [Route("Post/Manage/{operation}/{id?}")]
        public IActionResult Manage(string operation, int id =0)
        {
            return View();
        }
        [Route("Post/Manage/{operation}/{id?}")]
        [HttpPost]
        public IActionResult Manage(string operation, string Title, string Body,int categoryId, int id = 0)
        {
            var post = new Post()
            {
                CategoryId = categoryId,
                Body = Body,
                Title = Title,
                Date = DateTime.UtcNow
            };
            _unitOfWork.PostRepository.Add(post);
            _unitOfWork.Complete();
            return View();
        }
        [HttpPost]
        [Route("Post/Delete")]
        public IActionResult Delete(int id)
        {
            var post = _unitOfWork.PostRepository.Get(id);
            _unitOfWork.PostRepository.Remove(post);
            _unitOfWork.Complete();
            return RedirectToAction("Index","Home");
        }
    }
}
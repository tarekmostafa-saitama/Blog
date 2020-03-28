using Blog.Core.Repositories;

namespace Blog.Core
{
    public interface IUnitOfWork
    {
         ICategoryRepository CategoryRepository { get; set; }
         IPostRepository PostRepository { get; set; }
         ICommentRepository CommentRepository { get; set; }

         void Complete();
    }
}

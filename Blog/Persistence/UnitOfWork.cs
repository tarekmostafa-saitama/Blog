using Blog.Core;
using Blog.Core.Repositories;
using Blog.Persistence.Model;
using Blog.Persistence.Repositories;

namespace Blog.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;
        public ICategoryRepository CategoryRepository { get; set; }
        public IPostRepository PostRepository { get; set; }
        public ICommentRepository CommentRepository { get; set; }

        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;

            CategoryRepository = new CategoryRepository(dbContext);
            PostRepository = new PostRepository(dbContext);
            CommentRepository = new CommentRepository(dbContext);
        }
        public void Complete()
        {
            _dbContext.SaveChanges();
        }
    }
}

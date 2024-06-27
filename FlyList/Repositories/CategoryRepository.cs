using FlyList.Models;

namespace FlyList.Repositories
{
    public class CategoryRepository(ApplicationDbContext context) : IRepository<Category>
    {
        private readonly ApplicationDbContext _context = context;

        public void Create(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
        }

        public Category Read(Guid id)
        {
            return _context.Categories.Find(id);
        }

        public void Update(Category category)
        {
            _context.Categories.Update(category);
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var category = _context.Categories.Find(id);
            if (category != null)
            {
                _context.Categories.Remove(category);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Category> GetAll()
        {
            return _context.Categories.ToList();
        }
    }
}

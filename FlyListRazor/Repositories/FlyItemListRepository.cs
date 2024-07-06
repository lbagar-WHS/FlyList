using FlyList.Models;
using Microsoft.EntityFrameworkCore;


namespace FlyList.Repositories
{
    public class FlyItemListRepository(ApplicationDbContext context)
    {
        private readonly ApplicationDbContext _context = context;

        public void Create(FlyItemList flyList)
        {
            _context.FlyItemLists.Add(flyList);
            _context.SaveChanges();
        }

        public FlyItemList Read(Guid id)
        {
            return _context.FlyItemLists
                .Include(fl => fl.FlyItems).ThenInclude(fi => fi.Product)
                .FirstOrDefault(fl => fl.Id == id);
        }

        public void Update(FlyItemList flyList)
        {
            _context.FlyItemLists.Update(flyList);
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var flyList = _context.FlyItemLists.Find(id);
            if (flyList != null)
            {
                _context.FlyItemLists.Remove(flyList);
                _context.SaveChanges();
            }
        }

        public IEnumerable<FlyItemList> GetAll()
        {
            return _context.FlyItemLists
                .Include(fl => fl.FlyItems).ThenInclude(fi => fi.Product)
                .ToList();
        }
    }
}

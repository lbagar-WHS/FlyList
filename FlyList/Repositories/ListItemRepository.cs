
using System;
using System.Collections.Generic;
using System.Linq;
using FlyList.Models;
using Microsoft.EntityFrameworkCore;
namespace FlyList.Repositories
{

    public class ListItemRepository(ApplicationDbContext context) : IRepository<ListItem>
    {
        private readonly ApplicationDbContext _context = context;

        public void Create(ListItem listItem)
        {
            _context.ListItems.Add(listItem);
            _context.SaveChanges();
        }

        public ListItem Read(Guid id)
        {
            return _context.ListItems.Include(li => li.Product).FirstOrDefault(li => li.Id == id);
        }

        public void Update(ListItem listItem)
        {
            _context.ListItems.Update(listItem);
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var listItem = _context.ListItems.Find(id);
            if (listItem != null)
            {
                _context.ListItems.Remove(listItem);
                _context.SaveChanges();
            }
        }

        public IEnumerable<ListItem> GetAll()
        {
            return _context.ListItems.Include(li => li.Product).ToList();
        }
    }
}

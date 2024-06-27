using FlyList.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace FlyList
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ListItem> ListItems { get; set; }
        public DbSet<FlyItemList> FlyItemLists { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("YourConnectionStringHere");
        }
    }
}

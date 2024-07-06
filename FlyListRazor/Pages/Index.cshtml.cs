using FlyList.Models;
using FlyList.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FlyListRazor.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly FlyItemListRepository _flyItemListRepository;
        private readonly CategoryRepository _categoryRepository;
        private readonly ProductRepository _productRepository;
        private readonly ListItemRepository _listItemRepository;

        public FlyItemList FlyItemList { get; set; }
        public List<Category> Categories { get; set; }

        public IndexModel(ILogger<IndexModel> logger, FlyItemListRepository flyItemListRepository, 
            CategoryRepository categoryRepository, ProductRepository productRepository, ListItemRepository listItemRepository)
        {
            _logger = logger;
            _flyItemListRepository = flyItemListRepository;
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
            _listItemRepository = listItemRepository;

            var category1 = _categoryRepository.GetAll();

            if(!category1.Any())
            {
                Category getraenke = new() { Name = "Getränke" };
				Category meat = new() { Name = "Fleisch" };
				Category snacks = new() { Name = "Snacks" };
				Category vegetables = new() { Name = "Gemüse" };
				Category fruit = new() { Name = "Obst" };

                _categoryRepository.Create(getraenke);
                _categoryRepository.Create(meat);
                _categoryRepository.Create(snacks);
                _categoryRepository.Create(vegetables);
                _categoryRepository.Create(fruit);

				Product fanta = new() { Name = "Fanta", Category = getraenke, Description = "Fanta ist ein Lebensmittel" };
				Product cola = new() { Name = "Cola", Category = getraenke, Description = "Cola ist ein Lebensmittel" };

                Product steak = new() { Name = "Steak", Category = meat, Description = "Steak ist ein Lebensmittel" };
                Product chicken = new() { Name = "Hähnchen", Category = meat, Description = "Hähnchen ist ein Lebensmittel" };

                Product chips = new() { Name = "Chips", Category = snacks, Description = "Chips ist ein Lebensmittel" };
                Product chocolate = new() { Name = "Schokolade", Category = snacks, Description = "Schokolade ist ein Lebensmittel" };

                Product cucumber = new() { Name = "Gurke", Category = vegetables, Description = "Gurke ist ein Lebensmittel" };
                Product tomato = new() { Name = "Tomate", Category = vegetables, Description = "Tomaote ist ein Lebensmittel" };

                Product apple = new() { Name = "Apfel", Category = fruit, Description = "Apfel ist ein Lebensmittel" };

                _productRepository.Create(fanta);
                _productRepository.Create(cola);
                _productRepository.Create(steak);
                _productRepository.Create(chicken);
                _productRepository.Create(chips);
                _productRepository.Create(chocolate);
                _productRepository.Create(cucumber);
                _productRepository.Create(tomato);
                _productRepository.Create(apple);

                ListItem fantaItem = new() { Product = fanta, Amount = 2, IsBought = false };
                ListItem colaItem = new() { Product = cola, Amount = 1, IsBought = false };
                ListItem steakItem = new() { Product = steak, Amount = 1, IsBought = false };
                ListItem chickenItem = new() { Product = chicken, Amount = 1, IsBought = false };
                ListItem chipsItem = new() { Product = chips, Amount = 1, IsBought = false };
                ListItem chocolateItem = new() { Product = chocolate, Amount = 1, IsBought = false };
                ListItem cucumberItem = new() { Product = cucumber, Amount = 1, IsBought = false };
                ListItem tomatoItem = new() { Product = tomato, Amount = 1, IsBought = false };
                ListItem appleItem = new() { Product = apple, Amount = 1, IsBought = false };

                _listItemRepository.Create(fantaItem);
                _listItemRepository.Create(colaItem);
                _listItemRepository.Create(steakItem);
                _listItemRepository.Create(chickenItem);
                _listItemRepository.Create(chipsItem);
                _listItemRepository.Create(chocolateItem);
                _listItemRepository.Create(cucumberItem);
                _listItemRepository.Create(tomatoItem);
                _listItemRepository.Create(appleItem);

                FlyItemList flyItemList = new() { Name = "Einkaufsliste", FlyItems = {fantaItem, colaItem, steakItem, chickenItem, chipsItem, chocolateItem, cucumberItem, tomatoItem } };

                _flyItemListRepository.Create(flyItemList);
			}

			//Product product1 = new() { Name = "Fanta", Category = category1, Description = "Fanta ist ein Lebensmittel" };
			//         _productRepository.Create(product1);

			//         ListItem listItem1 = new() { Product = product1,Amount = 3, IsBought = false };
			//         _listItemRepository.Create(listItem1);

			//FlyItemList flyItemList = _flyItemListRepository.GetAll().FirstOrDefault();
			//flyItemList.FlyItems.Remove(listItem1);
			//_flyItemListRepository.Update(flyItemList);

			Categories = _categoryRepository.GetAll().ToList();

			FlyItemList = _flyItemListRepository.GetAll().FirstOrDefault();
		}

		public void OnGetAsync()
        {
            Categories = _categoryRepository.GetAll().ToList();

            FlyItemList = _flyItemListRepository.GetAll().FirstOrDefault();
        }

        public JsonResult OnPostSaveListItem(IFormCollection listItemDTO)
        {

            foreach (var key in listItemDTO.Keys)
            {
				_logger.LogInformation($"{key}: {listItemDTO[key]}");
				var category = _categoryRepository.Read(Guid.Parse(key));
				var product = new Product { Name = key, Category = category };

				_productRepository.Create(product);
				var listItem = new ListItem { Product = product, Amount = 1, IsBought = false };
				_listItemRepository.Create(listItem);

				FlyItemList.FlyItems.Add(listItem);
				_flyItemListRepository.Update(FlyItemList);
			}

            

			return new JsonResult(new { success = true, data = FlyItemList });
		}
    }
}

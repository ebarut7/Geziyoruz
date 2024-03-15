using Geziyoruz.WebUI.BasketTransaction;
using Geziyoruz.WebUI.BasketTransaction.BasketModels;
using Microsoft.AspNetCore.Mvc;

namespace Geziyoruz.WebUI.Controllers
{
    public class BasketController : Controller
    {
        private readonly IBasketTransaction _basketTransaction;

        public BasketController(IBasketTransaction basketTransaction)
        {
            _basketTransaction = basketTransaction;
        }

        [HttpGet]
        public IActionResult BuyTravel(string message = "")
        {      
            ViewBag.Message = message;
            Basket basket = _basketTransaction.GetOrCreateBasket();
            return View(basket);
        }
        [HttpPost]
        public IActionResult BuyTravel(BasketItem basketItem)
        {
            _basketTransaction.AddOrUpdateItem(basketItem);
            return RedirectToAction("Index","Home");
        }
        public IActionResult Decrease(int id)
        {
            _basketTransaction.Decrease(id);
            return RedirectToAction("Basket");
        }

        public IActionResult Increase(int id)
        {
            _basketTransaction.Increase(id);
            return RedirectToAction("Basket");
        }

        public IActionResult RemoveItem(int id)
        {
            _basketTransaction.DeleteItem(id);
            return RedirectToAction("Basket");
        }

        public IActionResult RemoveBasket()
        {
            _basketTransaction.DeleteBasket();
            return RedirectToAction("Basket");
        }


        public IActionResult AddBasketItem(BasketItem basketItem)
        {
            _basketTransaction.AddOrUpdateItem(basketItem);
            return RedirectToAction("Index", "Product");
        }








        BasketItem basketitem = new BasketItem()
        {
            ProductId = 1,
            Price = 60,
            ProductName = "Basit",
            Quantity = 999,
        };
        BasketItem basketItem2 = new BasketItem()
        {
            ProductId = 2,
            Price = 100,
            ProductName = "Premium",
            Quantity = 999,
        };
        BasketItem basketItem3 = new BasketItem()
        {
            ProductId = 3,
            Price = 200,
            ProductName = "Premium Deluxia",
            Quantity = 999,
        };
    }
}

using Microsoft.AspNetCore.Mvc;
using _6.Models;
using System.Collections.Generic;

namespace _6.Controllers
{
	public class PizzaOrderController : Controller
	{
		private static User _user;
		private static List<Product> _products;

		[HttpGet]
		public IActionResult Register()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Register(User user)
		{
			if (user.Age < 16)
			{
				ModelState.AddModelError("", "Вам повинно бути більше 16 років для замовлення піци.");
				return View();
			}

			_user = user;
			return RedirectToAction("ProductQuantity");
		}

		[HttpGet]
		public IActionResult ProductQuantity()
		{
			return View();
		}

		[HttpPost]
		public IActionResult ProductQuantity(int quantity)
		{
			if (quantity < 0)
			{
				ModelState.AddModelError("", "Кількість товарів повинна бути невід'ємною.");
				return View();
			}

			_user.ProductQuantity = quantity;
			return RedirectToAction("ProductForm");
		}

		[HttpGet]
		public IActionResult ProductForm()
		{
			_products = new List<Product>();
			for (int i = 0; i < _user.ProductQuantity; i++)
			{
				_products.Add(new Product());
			}
			return View(_products);
		}

		[HttpPost]
		public IActionResult ProductForm(List<Product> products)
		{
			_products = products;
			return RedirectToAction("Summary");
		}

		public IActionResult Summary()
		{
			return View(_products);
		}
	}
}
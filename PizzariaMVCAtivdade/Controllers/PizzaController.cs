using Microsoft.AspNetCore.Mvc;
using PizzariaMVCAtivdade.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzariaMVCAtivdade.Controllers
{
    public class PizzaController : Controller
    {
        private PizzariaDbContext _context;

        public PizzaController(PizzariaDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Pizzas);
        }
        public IActionResult Detalhes(int id)
        {
            var result = _context.Pizzas.FirstOrDefault(x => x.Id == id);
            return View(result);
        }
        public IActionResult Criar() => View();

        [HttpPost]
        public IActionResult Criar(Pizza pizza)
        {
            Pizza p1 = new Pizza(pizza.Nome,pizza.FotoURL,pizza.Preco);
            _context.Pizzas.Add(p1);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}

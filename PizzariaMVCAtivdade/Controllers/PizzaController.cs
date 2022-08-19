using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PizzariaMVCAtivdade.Models;
using PizzariaMVCAtivdade.Models.ViewModels;
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
        public IActionResult Criar(int id)
        {
            DadosDropDown();
            return View();
        }

        [HttpPost, ActionName("Criar")]
        public IActionResult CriarConfirmar(PostPizzaDTO pizzaDto)
        {
            Pizza pizza = new Pizza
            (
                pizzaDto.Nome,
                pizzaDto.FotoURL,
                pizzaDto.Preco,
                pizzaDto.TamanhoId
            );
            _context.Add(pizza);
            _context.SaveChanges();

            foreach (var saborId in pizzaDto.SaboresId)
            {
                var s = new PizzaSabor(pizza.Id,saborId);
                _context.PizzasSabores.Add(s);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }




        public void DadosDropDown()
        {
            var result = new PostPizzaDropdownDTO()
            {
                Sabores = _context.Sabores.OrderBy(x => x.Nome).ToList(),
                Tamanhos = _context.Tamanhos.OrderBy(x => x.Nome).ToList()
            };
            ViewBag.Sabores = new SelectList(result.Sabores, "Id", "Nome");
            ViewBag.Tamanhos = new SelectList(result.Tamanhos, "Id", "Nome");
        }
    }
}

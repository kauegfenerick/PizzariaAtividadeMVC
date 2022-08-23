using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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
            var result = _context.Pizzas
                .Include(t => t.Tamanho)
                .Include(ps => ps.PizzaSabores).ThenInclude(c => c.Sabor)
                .FirstOrDefault(p => p.Id == id);

            return View(result);
        }
        public IActionResult Criar()
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

        public IActionResult Atualizar(int id)
        {
            var result = _context.Pizzas
                .Include(x => x.PizzaSabores).ThenInclude(x => x.Sabor)
                .FirstOrDefault(x => x.Id == id);

            if (result == null)
                return View("NotFound");

            var response = new PostPizzaDTO()
            {
                Nome = result.Nome,
                FotoURL = result.FotoURL,
                Preco = result.Preco,
                TamanhoId = result.TamanhoId,
                SaboresId = result.PizzaSabores.Select(x => x.SaborId).ToList()
            };

            DadosDropDown();
            return View(response);
        }

        [HttpPost, ActionName("Atualizar")]
        public IActionResult ConfirmarAtualizar(int id, PostPizzaDTO pizzaDto)
        {
            var result = _context.Pizzas.FirstOrDefault(x => x.Id == id);

            if (!ModelState.IsValid)
            {
                DadosDropDown();
                return View(result);
            }

            result.AtualizarDados
                (
                pizzaDto.Nome,
                pizzaDto.FotoURL,
                pizzaDto.Preco,
                pizzaDto.TamanhoId
                );

            _context.Update(result);
            _context.SaveChanges();

            return RedirectToAction(nameof(Detalhes), result);
        }

        public IActionResult Deletar(int id)
        {
            var result = _context.Pizzas.FirstOrDefault(x => x.Id == id);

            if (result == null)
                return View("NotFound");

            return View(result);
        }

        [HttpPost, ActionName("Deletar")]
        public IActionResult ConfirmarDeletar(int id)
        {
            var result = _context.Pizzas.FirstOrDefault(x => x.Id == id);

            _context.Remove(result);
            _context.SaveChanges();

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

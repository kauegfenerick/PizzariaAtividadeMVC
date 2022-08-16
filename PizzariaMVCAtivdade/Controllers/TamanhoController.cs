using Microsoft.AspNetCore.Mvc;
using PizzariaMVCAtivdade.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzariaMVCAtivdade.Controllers
{
    public class TamanhoController : Controller
    {
        private PizzariaDbContext _context;

        public TamanhoController(PizzariaDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Tamanhos);
        }
        public IActionResult Criar() => View();

        [HttpPost]
        public IActionResult Criar(Tamanho tamanho)
        {
            Tamanho c1 = new(tamanho.Nome);
            _context.Tamanhos.Add(c1);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}

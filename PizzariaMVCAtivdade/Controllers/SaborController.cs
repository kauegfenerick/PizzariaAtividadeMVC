using Microsoft.AspNetCore.Mvc;
using PizzariaMVCAtivdade.Models;
using PizzariaMVCAtivdade.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzariaMVCAtivdade.Controllers
{
    public class SaborController : Controller
    {
        private PizzariaDbContext _context;

        public SaborController(PizzariaDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.Sabores);
        }
        public IActionResult Detalhes(int id) => View(_context.Sabores.Find(id));
        public IActionResult Criar() => View();

        [HttpPost]
        public IActionResult Criar(PostSaborDTO saborDto)
        {
            if (!ModelState.IsValid) return View(saborDto);
            Sabor s1 = new Sabor(saborDto.Nome);
            _context.Add(s1);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}

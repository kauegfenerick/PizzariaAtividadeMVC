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
            Sabor s1 = new Sabor(saborDto.Nome,saborDto.FotoURL);
            _context.Add(s1);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        
        public IActionResult Atualizar(int id)
        {
            var result = _context.Sabores.FirstOrDefault(s => s.Id == id);
            return View(result);
        }

        [HttpPost,ActionName("Atualizar")]
        public IActionResult ConfirmarAtualizar(int id, PostSaborDTO saborDto)
        {
            var result = _context.Sabores.FirstOrDefault(s => s.Id == id);
            result.AtualizarDados(saborDto.Nome, saborDto.FotoURL);
            _context.Sabores.Update(result);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Deletar(int id)
        {
            var result = _context.Sabores.FirstOrDefault(s => s.Id == id);
            return View(result); ;
        }
        [HttpPost,ActionName("Deletar")]
        public IActionResult ConfirmarDeletar(int id)
        {
            var result = _context.Sabores.FirstOrDefault(s => s.Id == id);
            _context.Sabores.Remove(result);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using PizzariaMVCAtivdade.Models;
using PizzariaMVCAtivdade.Models.ViewModels;
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
        public IActionResult Criar(PostTamanhoDTO tamanhoDto)
        {
            Tamanho c1 = new(tamanhoDto.Nome);
            _context.Tamanhos.Add(c1);
            _context.SaveChanges(); ;
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Atualizar(int id)
        {
            var result = _context.Tamanhos.FirstOrDefault(s => s.Id == id);
            return View(result);
        }

        [HttpPost, ActionName("Atualizar")]
        public IActionResult ConfirmarAtualizar(int id, PostTamanhoDTO tamanhoDto)
        {
            var result = _context.Tamanhos.FirstOrDefault(t => t.Id == id);
            result.AtualizarDados(tamanhoDto.Nome);
            _context.Tamanhos.Update(result);
            _context.SaveChanges(); ;
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Deletar(int id)
        {
            var result = _context.Tamanhos.FirstOrDefault(s => s.Id == id);
            return View(result);
        }
        [HttpPost, ActionName("Deletar")]
        public IActionResult ConfirmarDeletar(int id)
        {
            var result = _context.Tamanhos.FirstOrDefault(t => t.Id == id);
            _context.Tamanhos.Remove(result);
            _context.SaveChanges(); ;
            return RedirectToAction(nameof(Index));
        }
    }
}

using Microsoft.AspNetCore.Mvc;
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
    }
}

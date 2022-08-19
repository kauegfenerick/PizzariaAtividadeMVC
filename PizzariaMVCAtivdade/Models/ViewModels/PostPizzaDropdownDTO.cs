using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzariaMVCAtivdade.Models.ViewModels
{
    public class PostPizzaDropdownDTO
    {
        public PostPizzaDropdownDTO()
        {
            Sabores = new List<Sabor>();
            Tamanhos = new List<Tamanho>();
        }

        public List<Sabor> Sabores { get; set; }
        public List<Tamanho> Tamanhos { get; set; }
    }
}

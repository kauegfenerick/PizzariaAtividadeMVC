using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzariaMVCAtivdade.Models.ViewModels
{
    public class PostPizzaDTO
    {
        public string Nome { get; set; }
        public string FotoURL { get; set; }
        public decimal Preco { get; set; }
        public int TamanhoId { get; set; }
        public List<int> SaboresId { get; set; }
    }
}

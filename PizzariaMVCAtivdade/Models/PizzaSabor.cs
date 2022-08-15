using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzariaMVCAtivdade.Models
{
    public class PizzaSabor
    {
        public Pizza Pizza { get; set; }
        public int PizzaId { get; set; }

        public Sabor Sabor { get; set; }
        public int SaborId { get; set; }
    }
}

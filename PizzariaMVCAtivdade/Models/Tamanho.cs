using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzariaMVCAtivdade.Controllers.Inferfaces
{
    public class Tamanho : IEntidade
    {
        // Contrato entidade

        public int Id { get; set; }

        public DateTime DataCadastro { get; set; }

        public DateTime DataAlteracao { get; set; }

        // Fim do contrato entidade

        public string Nome { get; set; }

        public List<Pizza> Pizzas { get; set; }


    }
}

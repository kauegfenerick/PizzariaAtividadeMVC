using PizzariaMVCAtivdade.Models;
using PizzariaMVCAtivdade.Models.Inferfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzariaMVCAtivdade.Models
{
    public class Tamanho : IEntidade
    {
        public Tamanho(string nome)
        {
            Nome = nome;
            DataCadastro = DateTime.Now;
            DataAlteracao = DataCadastro;
        }

        // Contrato entidade

        public int Id { get; set; }

        public DateTime DataCadastro { get; set; }

        public DateTime DataAlteracao { get; set; }

        // Fim do contrato entidade

        public string Nome { get; set; }

        public List<Pizza> Pizzas { get; set; }


        public void AtualizarDados(string nome)
        {
            Nome = nome;
            DataAlteracao = DateTime.Now;
        }

    }
}

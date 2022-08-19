using PizzariaMVCAtivdade.Models.Inferfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PizzariaMVCAtivdade.Models
{
    public class Pizza : IEntidade
    {
        public Pizza(string nome, string fotoURL, decimal preco, int tamanhoId)
        {
            DataCadastro = DateTime.Now;
            DataAlteracao = DataCadastro;
            Nome = nome;
            FotoURL = fotoURL;
            Preco = preco;
            TamanhoId = tamanhoId;
        }

        //Contrato entidade

        public int Id { get; set; }
        
        public DateTime DataCadastro { get; set; }

        public DateTime DataAlteracao { get; set; }

        // Fim do contrato entidade

        public string Nome { get; set; }

        public string  FotoURL { get; set; }

        public decimal Preco { get; set; }

        public Tamanho Tamanho { get; set; }

        public int TamanhoId { get; set; }

         public List<PizzaSabor> PizzaSabores { get; set; }



    }
}

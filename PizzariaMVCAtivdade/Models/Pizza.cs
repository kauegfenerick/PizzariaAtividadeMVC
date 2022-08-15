using PizzariaMVCAtivdade.Models.Inferfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzariaMVCAtivdade.Models
{
    public class Pizza : IEntidade
    {
        //public Pizza(int id, string fotoURL, decimal preco, Tamanho tamanho, int tamanhoId, List<PizzaSabor> pizzaSabores)
        //{
        //    Id = id;
        //    DataCadastro = DateTime.Now;
        //    DataAlteracao = DataCadastro;
        //    FotoURL = fotoURL;
        //    Preco = preco;
        //    Tamanho = tamanho;
        //    TamanhoId = tamanhoId;
        //    PizzaSabores = pizzaSabores;
        //}

        // Contrato entidade

        public int Id { get; set; }
        
        public DateTime DataCadastro { get; set; }

        public DateTime DataAlteracao { get; set; }

        // Fim do contrato entidade

        public string Nome { get; set; }

        public string  FotoURL { get; set; }

        public decimal Preco { get; set; }

        public Tamanho Tamanho { get; set; }

        public int TamanhoId { get; set; }

        // public List<PizzaSabor> PizzaSabores { get; set; }



    }
}

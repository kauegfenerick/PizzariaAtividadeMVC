using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzariaMVCAtivdade.Models.Inferfaces
{
    public interface IEntidade 
    {
        int Id { get; }

        DateTime DataCadastro { get; }

        DateTime DataAlteracao { get; }
    }
}

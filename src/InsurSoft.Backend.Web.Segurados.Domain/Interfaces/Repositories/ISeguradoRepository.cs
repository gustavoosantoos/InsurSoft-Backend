using InsurSoft.Backend.Web.Segurados.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace InsurSoft.Backend.Web.Segurados.Domain.Interfaces.Repositories
{
    public interface ISeguradoRepository
    {
        void Salvar(Segurado segurado);
        Segurado Obter(int id);
        IEnumerable<Segurado> ObterTodos();
        void Remover(Segurado segurado);
    }
}

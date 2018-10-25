using InsurSoft.Backend.Web.Segurados.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace InsurSoft.Backend.Web.Segurados.Domain.Interfaces.Repositories
{
    public interface ISeguradoRepository
    {
        void Salvar(Segurado segurado);
        Segurado Obter(Guid id);
        IEnumerable<Segurado> ObterTodos();
        void Remover(Guid id);
    }
}

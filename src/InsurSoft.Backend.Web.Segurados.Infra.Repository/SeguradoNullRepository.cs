using InsurSoft.Backend.Web.Segurados.Domain.Entities;
using InsurSoft.Backend.Web.Segurados.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace InsurSoft.Backend.Web.Segurados.Infra.Repository
{
    public class SeguradoNullRepository : ISeguradoRepository
    {
        public Segurado Obter(int id)
        {
            return null;
        }

        public IEnumerable<Segurado> ObterTodos()
        {
            return new List<Segurado>();
        }

        public void Remover(Guid id)
        {

        }

        public void Salvar(Segurado segurado)
        {

        }
    }
}

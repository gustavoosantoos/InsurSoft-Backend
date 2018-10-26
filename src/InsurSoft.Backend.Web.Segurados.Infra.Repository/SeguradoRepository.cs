using InsurSoft.Backend.Infra.Repository.PostgreSQL.Context;
using InsurSoft.Backend.Web.Segurados.Domain.Entities;
using InsurSoft.Backend.Web.Segurados.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InsurSoft.Backend.Web.Segurados.Infra.Repository
{
    public class SeguradoRepository : ISeguradoRepository
    {
        private readonly InsurSoftContext _context;

        public SeguradoRepository(InsurSoftContext context)
        {
            _context = context;
        }

        public Segurado Obter(int id)
        {
            return _context.Segurados.Find(id);
        }

        public IEnumerable<Segurado> ObterTodos()
        {
            return _context.Segurados.AsEnumerable();
        }

        public void Remover(Segurado segurado)
        {
            _context.Segurados.Remove(segurado);
        }

        public void Salvar(Segurado segurado)
        {
            _context.Segurados.Add(segurado);
        }
    }
}

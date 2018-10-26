using InsurSoft.Backend.Infra.Repository.PostgreSQL.Context;
using InsurSoft.Backend.Shared.Domain.Interfaces;
using InsurSoft.Backend.Web.Segurados.Domain.Entities;
using InsurSoft.Backend.Web.Segurados.Domain.Interfaces.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace InsurSoft.Backend.Web.Segurados.Infra.Repository
{
    public class SeguradoRepository : ISeguradoRepository
    {
        private readonly IUnitOfWork _unityOfWork;
        private readonly InsurSoftContext _context;

        public SeguradoRepository(IUnitOfWork unitOfWork)
        {
            _unityOfWork = unitOfWork;
            _context = unitOfWork.Context;
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
            _unityOfWork.Commit();
        }
    }
}

using InsurSoft.Backend.Infra.Repository.PostgreSQL.Context;
using InsurSoft.Backend.Shared.Domain.Interfaces;
using InsurSoft.Backend.Web.Segurados.Domain.Entities;
using InsurSoft.Backend.Web.Segurados.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
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

        public Segurado Obter(int codigo)
        {
            return _context.Segurados.FirstOrDefault(s => s.Codigo == codigo);
        }

        public IEnumerable<Segurado> ObterTodos()
        {
            return _context
                .Segurados
                .OrderBy(s => s.Codigo)
                .AsEnumerable();
        }

        public void Remover(Segurado segurado)
        {
            segurado.MarcarComoApagado();

            _context.Entry(segurado).State = EntityState.Modified;
            _unityOfWork.Commit();
        }

        public void Salvar(Segurado segurado)
        {
            _context.Segurados.Add(segurado);
            _unityOfWork.Commit();
        }
      
    }
}

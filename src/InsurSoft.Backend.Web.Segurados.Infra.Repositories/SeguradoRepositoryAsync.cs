using InsurSoft.Backend.Infra.Repository.PostgreSQL.Context;
using InsurSoft.Backend.Web.Segurados.Domain.Entities;
using InsurSoft.Backend.Web.Segurados.Domain.Interfaces;
using InsurSoft.Backend.Web.Segurados.Domain.Models.Segurados;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace InsurSoft.Backend.Web.Segurados.Infra.Repositories
{
    public class SeguradoRepositoryAsync : ISeguradoRepositoryAsync
    {
        private readonly InsurSoftContext _context;

        public SeguradoRepositoryAsync(InsurSoftContext context)
        {
            _context = context;
        }

        public async Task Adicionar(Segurado segurado, CancellationToken cancellationToken = default)
        {
            await _context.Segurados.AddAsync(segurado, cancellationToken);
        }

        public async Task<SeguradoDetalhado> ObterDetalhado(int codigo, CancellationToken cancellationToken = default)
        {
            var segurado = await _context.Segurados.FindAsync(new object[] { codigo }, cancellationToken: cancellationToken);
            if (segurado == null)
                return null;

            return SeguradoDetalhado.FromSegurado(segurado);
        }

        public async Task<IEnumerable<SeguradoPreview>> ObterPreviews(CancellationToken cancellationToken = default)
        {
            return await _context.Segurados.Select(SeguradoPreview.SelectField()).ToListAsync(cancellationToken);
        }

        public async Task Remover(int codigo, CancellationToken cancellationToken = default) 
        {
            var segurado = await _context.Segurados.FirstOrDefaultAsync(s => s.Codigo == codigo, cancellationToken);
            if (segurado == null)
                return;

            segurado.MarcarComoApagado();
            _context.Entry(segurado).State = EntityState.Modified;
        }

        public async Task Salvar(CancellationToken cancellationToken = default)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}

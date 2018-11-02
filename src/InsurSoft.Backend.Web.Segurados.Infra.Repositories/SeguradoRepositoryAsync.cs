using InsurSoft.Backend.Infra.Repository.PostgreSQL.Context;
using InsurSoft.Backend.Shared.Domain.Entities;
using InsurSoft.Backend.Web.Segurados.Domain.Interfaces;
using InsurSoft.Backend.Web.Segurados.Domain.Models.Segurados;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task Adicionar(Segurado segurado)
        {
            await _context.Segurados.AddAsync(segurado);
        }

        public async Task<Segurado> Obter(Guid codigo)
        {
            return await _context.Segurados.FindAsync(codigo);
        }

        public async Task<SeguradoDetalhado> ObterDetalhado(Guid codigo)
        {
            var segurado = await _context.Segurados.FindAsync(codigo);
            if (segurado == null)
                return null;

            return SeguradoDetalhado.FromSegurado(segurado);
        }

        public async Task<IEnumerable<SeguradoPreview>> ObterPreviews()
        {
            return await _context.Segurados.Select(SeguradoPreview.SelectField()).ToListAsync();
        }

        public async Task Remover(Guid codigo) 
        {
            var segurado = await _context.Segurados.FirstOrDefaultAsync(s => s.Codigo == codigo);
            if (segurado == null)
                return;

            segurado.MarcarComoApagado();
            _context.Entry(segurado).State = EntityState.Modified;
        }

        public async Task Salvar()
        {
            await _context.SaveChangesAsync();
        }
    }
}

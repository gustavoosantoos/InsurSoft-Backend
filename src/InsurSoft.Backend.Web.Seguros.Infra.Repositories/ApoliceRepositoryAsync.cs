using InsurSoft.Backend.Infra.Repository.PostgreSQL.Context;
using InsurSoft.Backend.Shared.Domain.Entities.Seguros;
using InsurSoft.Backend.Web.Seguros.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace InsurSoft.Backend.Web.Seguros.Infra.Repositories
{
    public class ApoliceRepositoryAsync : IApoliceRepositoryAsync
    {
        private readonly InsurSoftContext _context;

        public ApoliceRepositoryAsync(InsurSoftContext context)
        {
            _context = context;
        }

        public async Task Adicionar(Apolice apolice)
        {
            await _context.Apolices.AddAsync(apolice);
        }

        public async Task Salvar()
        {
            await _context.SaveChangesAsync();
        }
    }
}

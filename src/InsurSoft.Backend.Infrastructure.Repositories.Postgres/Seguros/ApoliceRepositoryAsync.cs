using System.Threading.Tasks;
using InsurSoft.Backend.Infrastructure.Repositories.Postgres.Context;
using InsurSoft.Backend.Shared.DomainModel.SegurosAggregate;
using InsurSoft.Backend.Web.Seguros.Domain.Repositories;

namespace InsurSoft.Backend.Infrastructure.Repositories.Postgres.Seguros
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

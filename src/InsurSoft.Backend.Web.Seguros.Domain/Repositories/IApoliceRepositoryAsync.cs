using System.Threading.Tasks;
using InsurSoft.Backend.Shared.DomainModel.SegurosAggregate;

namespace InsurSoft.Backend.Web.Seguros.Domain.Repositories
{
    public interface IApoliceRepositoryAsync
    {
        Task Adicionar(Apolice apolice);
        Task Salvar();
    }
}

using InsurSoft.Backend.Shared.Domain.Entities.Seguros;
using System.Threading.Tasks;

namespace InsurSoft.Backend.Web.Seguros.Domain.Repositories
{
    public interface IApoliceRepositoryAsync
    {
        Task Adicionar(Apolice apolice);
        Task Salvar();
    }
}

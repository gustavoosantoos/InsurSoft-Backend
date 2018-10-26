using InsurSoft.Backend.Shared.Funcional;
using InsurSoft.Backend.Web.Segurados.Application.Commands;
using InsurSoft.Backend.Web.Segurados.Application.Output.Segurados;
using InsurSoft.Backend.Web.Segurados.Domain.ValueObjects;
using InsurSoft.Backend.Web.Segurados.Input.Segurados;
using System.Threading.Tasks;

namespace InsurSoft.Backend.Web.Segurados.Application.Interfaces
{
    public interface ISeguradoAppService
    {
        Task CriarSegurado(CriarSeguradoInput input);
        Task<Maybe<SeguradoOutput>> ObterPorCodigo(int codigo);
    }
}

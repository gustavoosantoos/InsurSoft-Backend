using InsurSoft.Backend.Shared.Funcional;
using InsurSoft.Backend.Web.Segurados.Application.Output.Segurados;
using InsurSoft.Backend.Web.Segurados.Input.Segurados;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InsurSoft.Backend.Web.Segurados.Application.Interfaces
{
    public interface ISeguradoAppService
    {
        Task Criar(CriarSeguradoInput input);
        Task Remover(int id);
        Task<IEnumerable<SeguradoOutput>> ObterTodos();
        Task<Maybe<SeguradoOutput>> ObterPorCodigo(int codigo);
    }
}

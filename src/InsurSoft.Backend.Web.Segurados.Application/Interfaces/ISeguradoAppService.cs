using InsurSoft.Backend.Shared.Funcional;
using InsurSoft.Backend.Web.Segurados.Application.Commands;

namespace InsurSoft.Backend.Web.Segurados.Application.Interfaces
{
    public interface ISeguradoAppService
    {
        Result CriarSegurado(CriarSeguradoCommand command);
    }
}

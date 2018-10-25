using InsurSoft.Backend.Shared.Funcional;
using InsurSoft.Backend.Web.Segurados.Application.Commands;
using InsurSoft.Backend.Web.Segurados.Input.Segurados;

namespace InsurSoft.Backend.Web.Segurados.Application.Interfaces
{
    public interface ISeguradoAppService
    {
        Result CriarSegurado(CriarSeguradoInput input);
    }
}

using InsurSoft.Backend.Shared.Domain.Entities.Segurados;
using InsurSoft.Backend.Web.Segurados.Domain.Models.Segurados;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InsurSoft.Backend.Web.Segurados.Domain.Interfaces
{
    public interface ISeguradoRepositoryAsync
    {
        Task Adicionar(Segurado segurado);
        Task Remover(Guid codigo);
        Task<Segurado> Obter(Guid codigo);
        Task<SeguradoDetalhado> ObterDetalhado(Guid codigo);
        Task<IEnumerable<SeguradoPreview>> ObterPreviews();
        Task Salvar();
    }
}

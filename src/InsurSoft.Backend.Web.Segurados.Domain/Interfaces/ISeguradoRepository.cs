using InsurSoft.Backend.Web.Segurados.Domain.Entities;
using InsurSoft.Backend.Web.Segurados.Domain.Models.Segurados;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace InsurSoft.Backend.Web.Segurados.Domain.Interfaces
{
    public interface ISeguradoRepositoryAsync
    {
        Task Adicionar(Segurado segurado, CancellationToken cancellationToken = default);
        Task Remover(int codigo, CancellationToken cancellationToken = default);
        Task<SeguradoDetalhado> ObterDetalhado(int codigo, CancellationToken cancellationToken = default);
        Task<IEnumerable<SeguradoPreview>> ObterPreviews(CancellationToken cancellationToken = default);
        Task Salvar(CancellationToken cancellationToken = default);
    }
}

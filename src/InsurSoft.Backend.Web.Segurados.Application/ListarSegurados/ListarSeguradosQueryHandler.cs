using InsurSoft.Backend.Infra.Repository.PostgreSQL.Context;
using InsurSoft.Backend.Shared.Interfaces.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace InsurSoft.Backend.Web.Segurados.Application.ListarSegurados
{
    public class ListarSeguradosQueryHandler : IRequestHandler<ListarSeguradosQuery, List<SeguradoPreviewViewModel>>
    {
        private readonly IMediatorHandler _mediatorHandler;
        private readonly InsurSoftContext _context;

        public ListarSeguradosQueryHandler(
            IMediatorHandler mediatorHandler,
            InsurSoftContext context)
        {
            _mediatorHandler = mediatorHandler;
            _context = context;
        }

        public async Task<List<SeguradoPreviewViewModel>> Handle(ListarSeguradosQuery request, CancellationToken cancellationToken)
        {
            return await _context
                .Segurados
                .Select(SeguradoPreviewViewModel.SelectField())
                .ToListAsync();
        }
    }
}

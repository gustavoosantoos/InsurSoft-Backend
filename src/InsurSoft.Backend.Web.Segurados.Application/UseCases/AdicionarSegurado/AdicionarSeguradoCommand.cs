using System;
using MediatR;

namespace InsurSoft.Backend.Web.Segurados.Application.UseCases.AdicionarSegurado
{
    public class AdicionarSeguradoCommand : IRequest
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public DateTime DataNascimento { get; set; }
    }
}

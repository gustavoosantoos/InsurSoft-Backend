using InsurSoft.Backend.Shared.Funcional;
using InsurSoft.Backend.Web.Segurados.Application.Commands;
using InsurSoft.Backend.Web.Segurados.Application.Interfaces;
using InsurSoft.Backend.Web.Segurados.Domain.Entities;
using InsurSoft.Backend.Web.Segurados.Domain.Interfaces.Repositories;
using System;

namespace InsurSoft.Backend.Web.Segurados.Application.Services
{
    public class SeguradoAppService : ISeguradoAppService
    {
        private readonly ISeguradoRepository _seguradoRepository;

        private const string MensagemComandoVazio = "O comando para criação de segurados não deve ser vazio.";
        private const string MensagemFalhaAoCriar = "Falha ao salvar segurado.";

        public SeguradoAppService(ISeguradoRepository seguradoRepository)
        {
            _seguradoRepository = seguradoRepository;
        }

        public Result CriarSegurado(CriarSeguradoCommand command)
        {
            try
            {
                if (command == null)
                    return Result.Fail(MensagemComandoVazio);
                
                _seguradoRepository?.Salvar(new Segurado(command.Nome, command.DataNascimento));

                return Result.Ok();
            }
            catch (Exception ex)
            {
                return Result.Fail(MensagemFalhaAoCriar);
            }
        }
    }
}

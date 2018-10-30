using FluentValidation;
using InsurSoft.Backend.Web.Segurados.Application.AdicionarSegurado;
using InsurSoft.Backend.Web.Segurados.Application.ListarSegurados;
using InsurSoft.Backend.Web.Segurados.Application.ObterSeguradoDetalhado;
using InsurSoft.Backend.Web.Segurados.Application.RemoverSegurado;
using MediatR;
using SimpleInjector;
using System.Collections.Generic;

namespace InsurSoft.Backend.Web.Segurados.Infra.Ioc
{
    public static class Application
    {
        public static void RegisterIocSeguradosApplication(this Container container)
        {
            var assembly = typeof(AdicionarSeguradoCommandHandler).Assembly;
            container.Register(typeof(IRequestHandler<,>), assembly);

            container.Register<IValidator<ObterSeguradoDetalhadoQuery>, ObterSeguradoDetalhadoQueryValidator>(); 
            container.Register<IValidator<AdicionarSeguradoCommand>, AdicionarSeguradoCommandValidator>();
            container.Register<IValidator<RemoverSeguradoCommand>, RemoverSeguradoCommandValidator>();
        }
    }
}

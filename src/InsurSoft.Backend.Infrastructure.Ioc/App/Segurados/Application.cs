using FluentValidation;
using InsurSoft.Backend.Web.Segurados.Application.UseCases.AdicionarSegurado;
using InsurSoft.Backend.Web.Segurados.Application.UseCases.ObterSeguradoDetalhado;
using InsurSoft.Backend.Web.Segurados.Application.UseCases.RemoverSegurado;
using MediatR;
using SimpleInjector;

namespace InsurSoft.Backend.Infrastructure.Ioc.App.Segurados
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

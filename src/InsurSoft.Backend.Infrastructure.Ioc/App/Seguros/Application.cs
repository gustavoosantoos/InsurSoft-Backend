using FluentValidation;
using InsurSoft.Backend.Web.Seguros.Application.CriarApolice;
using MediatR;
using SimpleInjector;

namespace InsurSoft.Backend.Infrastructure.Ioc.App.Seguros
{
    public static class Application
    {
        public static void RegisterSegurosIocApplication(this Container container)
        {
            var assembly = typeof(CriarApoliceCommand).Assembly;
            container.Register(typeof(IRequestHandler<,>), assembly);

            container.Register<IValidator<CriarApoliceCommand>, CriarApoliceCommandValidator>();
        }
    }
}

using FluentValidation;
using InsurSoft.Backend.Web.Seguros.Application.CriarApolice;
using MediatR;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Text;

namespace InsurSoft.Backend.Web.Seguros.Infra.Ioc
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

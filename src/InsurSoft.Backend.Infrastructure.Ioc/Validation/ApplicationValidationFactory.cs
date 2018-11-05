using System;
using FluentValidation;
using SimpleInjector;

namespace InsurSoft.Backend.Infrastructure.Ioc.Validation
{
    public class ApplicationValidatorFactory : ValidatorFactoryBase, IValidatorFactory
    {
        private readonly Container _container;

        public ApplicationValidatorFactory(Container container)
        {
            _container = container;
        }

        public override IValidator CreateInstance(Type validatorType)
        {
            return (IValidator)_container.GetInstance(validatorType);
        }
    }
}

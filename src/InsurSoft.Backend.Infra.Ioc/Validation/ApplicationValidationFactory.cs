using FluentValidation;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Text;

namespace InsurSoft.Backend.Infra.Ioc.Validation
{
    public class ApplicationValidatorFactory : ValidatorFactoryBase, IValidatorFactory
    {
        private readonly Container _container;

        /// <summary>The constructor of the factory.</summary>
        /// <param name="container">The Simple Injector Container</param>
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

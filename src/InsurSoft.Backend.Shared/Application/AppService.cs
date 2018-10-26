using AutoMapper;
using InsurSoft.Backend.Shared.Interfaces.Domain;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace InsurSoft.Backend.Shared.Application
{
    public abstract class AppService
    {
        protected AppService(ILogger logger, IMediatorHandler mediatorHandler, IMapper mapper)
        {
            Logger = logger;
            MediatorHandler = mediatorHandler;
            Mapper = mapper;
        }

        protected ILogger Logger { get; }
        protected IMediatorHandler MediatorHandler { get; }
        protected IMapper Mapper { get; }
    }
}

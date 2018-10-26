using InsurSoft.Backend.Infra.Repository.PostgreSQL.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace InsurSoft.Backend.Shared.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        InsurSoftContext Context { get; }
        void Commit();
    }
}

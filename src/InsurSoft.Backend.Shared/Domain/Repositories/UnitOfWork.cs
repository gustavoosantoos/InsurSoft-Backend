using InsurSoft.Backend.Infra.Repository.PostgreSQL.Context;
using InsurSoft.Backend.Shared.Domain.Interfaces;
using System;

namespace InsurSoft.Backend.Shared.Domain.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public InsurSoftContext Context { get; }

        public UnitOfWork(InsurSoftContext context)
        {
            Context = context;
        }
        
        public void Commit()
        {
            Context.SaveChanges();
        }
    }
}

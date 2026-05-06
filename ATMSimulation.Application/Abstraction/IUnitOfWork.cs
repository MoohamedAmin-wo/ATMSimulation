using Microsoft.EntityFrameworkCore.Storage;

namespace ATMSimulation.Application.Abstraction
{
    public interface IUnitOfWork
    {

        int Commit();
        Task<int> CommitAsync();
        Task<int> NumberOfModifiedRows();
        IDbContextTransaction BeginTransactionAsync();
    }
}

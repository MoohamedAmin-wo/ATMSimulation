using ATMSimulation.Application.Abstraction;
using ATMSimulation.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore.Storage;

namespace ATMSimulation.Infrastructure.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public int Commit() => _context.SaveChanges();

        public async Task<int> CommitAsync() => await _context.SaveChangesAsync();

        public IDbContextTransaction BeginTransactionAsync() => _context.Database.BeginTransaction();

        public async Task<int> NumberOfModifiedRows() => await _context.SaveChangesAsync();
    }
}
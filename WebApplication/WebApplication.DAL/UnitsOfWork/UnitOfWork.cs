using System;
using WebApplication.DAL.EF;
using WebApplication.DAL.Entities;
using WebApplication.DAL.Interfaces;
using WebApplication.DAL.Repositories;

namespace WebApplication.DAL.UnitsOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseContext _databaseContext;
        private bool _disposed;

        private ICommonRepository<User> _userRepository;
        private ICommonRepository<Pet> _petRepository;

        public UnitOfWork(string connectionString)
        {
            _databaseContext = new DatabaseContext(connectionString);
        }

        public ICommonRepository<User> Users => _userRepository ??
                                                (_userRepository = new CommonRepository<User>(_databaseContext));

        public ICommonRepository<Pet> Pets => _petRepository ??
                                              (_petRepository = new CommonRepository<Pet>(_databaseContext));

        public void Save()
        {
            _databaseContext.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if(!_disposed)
            {
                if(disposing)
                {
                   _databaseContext.Dispose();
                }

                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
             GC.SuppressFinalize(this);
        }
    }
}
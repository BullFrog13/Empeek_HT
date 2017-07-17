using System;
using WebApplication.DAL.Entities;

namespace WebApplication.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ICommonRepository<User> Users { get; }

        ICommonRepository<Pet> Pets { get; }

        void Save();
    }
}
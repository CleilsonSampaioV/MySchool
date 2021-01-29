using MySchool.Domain.Entities;
using MySchool.Domain.Interfaces.Repositories.Base;
using System;

namespace MySchool.Domain.Interfaces.Repositories
{
    public interface IRepositoryClass : IRepositoryBase<Class, Guid>
    {
    }
}

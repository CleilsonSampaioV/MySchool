using MySchool.Domain.Interfaces.Repositories.Base;
using System;

namespace MySchool.Domain.Interfaces.Repositories
{
    public interface IRepositorySchool : IRepositoryBase<School, Guid>
    {
    }
}

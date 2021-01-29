using MySchool.Domain.Entities;
using MySchool.Domain.Interfaces.Repositories;
using MySchool.Infra.Data.Repositories.Base;
using MySchool.Infra.Data.Repositories.Context;
using System;

namespace MySchool.Infra.Data.Repositories
{
    public class RepositoryClass : RepositoryBase<Class, Guid>, IRepositoryClass
    {
        private readonly MySchoolContext _mySchoolContext;
        public RepositoryClass(MySchoolContext mySchoolContext) : base(mySchoolContext)
        {
            _mySchoolContext = mySchoolContext;
        }
    }
}

using MySchool.Domain.Interfaces.Repositories;
using MySchool.Infra.Data.Repositories.Base;
using MySchool.Infra.Data.Repositories.Context;
using System;

namespace MySchool.Infra.Data.Repositories
{
    public class RepositorySchool : RepositoryBase<School, Guid>, IRepositorySchool
    {
        private readonly MySchoolContext _mySchoolContext;
        public RepositorySchool(MySchoolContext mySchoolContext) : base(mySchoolContext)
        {
            _mySchoolContext = mySchoolContext;
        }
    }
}

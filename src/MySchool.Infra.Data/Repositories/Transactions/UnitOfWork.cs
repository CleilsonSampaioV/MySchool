using MySchool.Infra.Data.Repositories.Context;
using System;

namespace MySchool.Infra.Data.Repositories.Transactions
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MySchoolContext _mySchoolContext;

        public UnitOfWork(MySchoolContext mySchoolContext)
        {
            _mySchoolContext = mySchoolContext;
        }

        public void SaveChanges()
        {
            _mySchoolContext.SaveChanges();
        }
    }
}



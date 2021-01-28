namespace MySchool.Infra.Data.Repositories.Transactions
{
    public interface IUnitOfWork
    {
        void SaveChanges();
    }
}

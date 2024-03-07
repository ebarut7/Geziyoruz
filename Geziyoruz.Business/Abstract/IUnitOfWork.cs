using Geziyoruz.DataAccess.Abstract;
using Microsoft.EntityFrameworkCore.Storage;

namespace Geziyoruz.Business.Abstract
{
    public interface IUnitOfWork : IDisposable
    {
        IBlogPostDal BlogPostDal { get; }
        ICustomerDal CustomerDal { get; }
        IAdminDal AdminDal { get; }
        IPictureDal PictureDal { get; }
        Task<IDbContextTransaction> BeginTransactionAsync();
        Task<int> SaveAsync();
    }
}

using Geziyoruz.Business.Abstract;
using Geziyoruz.DataAccess.Abstract;
using Geziyoruz.DataAccess.Concrete.EntityFrameworkCore.Context;
using Microsoft.EntityFrameworkCore.Storage;

namespace Geziyoruz.Business.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        public IAdminDal AdminDal { get; }
        public IBlogPostDal BlogPostDal { get; }
        public ICustomerDal CustomerDal { get; }
        public IPictureDal PictureDal { get; }

        GeziyoruzContext _context;

        public UnitOfWork(GeziyoruzContext context, IAdminDal adminDal, IBlogPostDal blogPostDal, ICustomerDal customerDal, IPictureDal pictureDal)
        {
            _context = context;
            AdminDal = adminDal;
            BlogPostDal = blogPostDal;
            CustomerDal = customerDal;
            PictureDal = pictureDal;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            return await _context.Database.BeginTransactionAsync();
        }
    }
}

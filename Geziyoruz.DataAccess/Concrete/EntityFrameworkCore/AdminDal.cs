using Geziyoruz.DataAccess.Abstract;
using Geziyoruz.DataAccess.Concrete.EntityFrameworkCore.Context;
using Geziyoruz.Entities.Concrete;

namespace Geziyoruz.DataAccess.Concrete.EntityFrameworkCore
{
    public class AdminDal : RepositoryBase<Admin>, IAdminDal
    {
        public AdminDal(GeziyoruzContext context) : base(context)
        {

        }
    }
}

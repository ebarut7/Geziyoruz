

using Geziyoruz.DataAccess.Abstract;
using Geziyoruz.DataAccess.Concrete.EntityFrameworkCore.Context;
using Geziyoruz.Entities.Concrete;

namespace Geziyoruz.DataAccess.Concrete.EntityFrameworkCore
{
    public class CustomerDal : RepositoryBase<Customer>, ICustomerDal
    {
        public CustomerDal(GeziyoruzContext context) : base(context)
        {

        }
    }
}

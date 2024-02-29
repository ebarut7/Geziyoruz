

using Geziyoruz.DataAccess.Abstract;
using Geziyoruz.DataAccess.Concrete.EntityFrameworkCore.Context;
using Geziyoruz.Entities.Concrete;

namespace Geziyoruz.DataAccess.Concrete.EntityFrameworkCore
{
    public class PictureDal : RepositoryBase<Picture>, IPictureDal
    {
        public PictureDal(GeziyoruzContext context) : base(context)
        {

        }
    }
}

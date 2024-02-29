

using Geziyoruz.Entities.Abstract;

namespace Geziyoruz.Entities.Concrete.Dtos.UserDtos
{
    public class LoginDto : IDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}

﻿

using Geziyoruz.Entities.Abstract;

namespace Geziyoruz.Entities.Concrete.Dtos.UserDtos
{
    public class AdminRegisterDto : UserDto,IDto
    {
        public string Code { get; set; }
    }
}

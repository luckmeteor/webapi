using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mapster;
using webapi.Models;
namespace webapi.Helper
{
    public class UserDtoRegister
    {
        //public void Register(TypeAdapterConfig config)
        //{
        //    config.NewConfig<User, UserDto>()
        //        .Map(dest => dest.UserAge, src => src.Age)
        //        .Map(dest => dest.UserSex, src => src.Sex);
        //    //config.ForType<User, UserDto>()
        //    //    .Map(dest => dest.UserAge, src => src.Age)
        //    //    .Map(dest => dest.UserSex, src => src.Sex);
        //}
        public static void InitMapster() {
            TypeAdapterConfig<User, UserDto>.NewConfig()
                .Map(dest => dest.UserAge, src => src.Age)
                .Map(dest => dest.UserSex, src => src.Sex);
        }
        
    }
}
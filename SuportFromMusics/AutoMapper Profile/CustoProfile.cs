using AutoMapper;
using UserServices.ViewModels;
using UserServices;
using SingServices.ViewModels;
using SingServices;

namespace Suport.AutoMapper_Profile
{
    public class CustoProfile:Profile
    {
        public CustoProfile()
        {
            CreateMap<AddUserViewModel, User>();
        }
    }
}

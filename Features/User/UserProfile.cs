using AutoMapper;
using BackendTest.Features.User.Resources;

namespace BackendTest.Features.User;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<SignUpResource, User>();
    }
}
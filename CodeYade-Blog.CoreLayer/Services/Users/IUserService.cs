using CodeYade_Blog.CoreLayer.DTOs.Users;
using CodeYade_Blog.CoreLayer.Utilities;

namespace CodeYad_Blog.CoreLayer.Services.Users
{
    public interface IUserService
    {
        OperationResult RegisterUser(UserRegisterDTo registerDto);
        UserDto LoginUser(LoginUserDto loginDto);
    }
}
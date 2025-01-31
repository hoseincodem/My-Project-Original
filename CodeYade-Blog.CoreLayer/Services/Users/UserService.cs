using System;
using System.Linq;
using CodeYad_Blog.CoreLayer.Utilities;
using CodeYade_Blog.CoreLayer.DTOs.Users;
using CodeYade_Blog.CoreLayer.Utilities;
using CodeYade_Blog.DataLayer.Context;
using CodeYade_Blog.DataLayer.Entities;

namespace CodeYade_Blog.CoreLayer.Services.Users
{
    public class UserService : IUserService
    {
        private readonly BlogContext _context;

        public UserService(BlogContext context)
        {
            _context = context;
        }

        public OperationResult RegisterUser(UserRegisterDTo registerDto)
        {
            var isUserNameExist = _context.Users.Any(u => u.UserName == registerDto.UserName);

            if (isUserNameExist)
                return OperationResult.Error("نام کاربری تکراری است.");

            var passwordHash = registerDto.Password.EncodeToMd5();

            _context.Users.Add(entity: new User()
            {
                FullName = registerDto.FullName,
                IsDelete = false,
                UserName = registerDto.UserName,
                Role = UserRole.User,
                CreationDate = DateTime.Now,
                Password = passwordHash
            });


            _context.SaveChanges();
            return OperationResult.Success();
        }

        OperationResult IUserService.LoginUser(LoginUserDto loginDto)
        {
            var PasswordHashed = loginDto.Password.EncodeToMd5();
            var isUserExist = _context.Users.Any(u => u.UserName == loginDto.UserName && u.Password == PasswordHashed);
            if (isUserExist==false)
            {
                return OperationResult.NotFound();

            }
            return OperationResult.Success();
        }
    }
}

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
            var isFullNameExist = _context.Users.Any(u => u.UserName == registerDto.UserName);
            if (isFullNameExist)
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

       
    }
}

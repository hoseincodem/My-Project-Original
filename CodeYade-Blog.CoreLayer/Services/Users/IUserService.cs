using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeYade_Blog.CoreLayer.DTOs.Users;
using CodeYade_Blog.CoreLayer.Utilities;
using CodeYade_Blog.DataLayer.Entities;

namespace CodeYade_Blog.CoreLayer.Services.Users
{
    public interface IUserService
    {
        OperationResult RegisterUser(UserRegisterDTo registerDTo);
    }
}

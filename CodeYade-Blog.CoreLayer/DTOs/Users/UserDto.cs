using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeYade_Blog.DataLayer.Entities;

namespace CodeYade_Blog.CoreLayer.DTOs.Users
{
    public class UserDto
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Password { get; set; }
        public UserRole Role { get; set; }
        public DateTime RegisterDate { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using CodeYade_Blog.CoreLayer.DTOs.Users;
using CodeYade_Blog.CoreLayer.Services.Users;
using CodeYade_Blog.CoreLayer.Utilities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CodeYade_Blog.Web.Pages.Auth
{
    [ValidateAntiForgeryToken]
    [BindProperties]
    public class LoginModel : PageModel

    {
        private readonly IUserService _userService;
        public LoginModel(IUserService userService)
        {
            _userService = userService;
        }
        [Required(ErrorMessage ="نام کاربری را وارد کنید")]
        [BindProperty]
        public string UserName { get; set; }
        [Required(ErrorMessage ="کلمه ی عبور را وارد کنید")]
        [MaxLength(6,ErrorMessage ="کلمه ی عبور باید بیشتر از 5 کاراکتر باشد")]
        [BindProperty]
        public string Password { get; set; }
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid == false)
            {
                return Page();
            }

            var result = _userService.LoginUser(new LoginUserDto() 
            {
                Password= Password,UserName=UserName
            
            });
            if (result.Status== OperationResultStatus.NotFound)
            {
                ModelState.AddModelError("UserName", "کاربری با مشخصات وارد شده یافت نشد یافت نشد");
                return Page();
            }


            return RedirectToPage("../Index");
        }
    }
}

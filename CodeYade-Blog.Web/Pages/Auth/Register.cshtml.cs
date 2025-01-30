using System.ComponentModel.DataAnnotations;
using CodeYade_Blog.CoreLayer.DTOs.Users;
using CodeYade_Blog.CoreLayer.Services.Users;
using CodeYade_Blog.CoreLayer.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CodeYade_Blog.Web.Pages.Auth
{
    [BindProperties]
    public class RegisterModel : PageModel
    {
        private readonly IUserService _userService;

        #region Properties
        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = "{0}را وارد کنید")]

        public string UserName { get; set; }
        [Display(Name = "نام و نام خانوادگی")]
        [Required(ErrorMessage = "{0}را وارد کنید")]
        public string FullName { get; set; }
        [Display(Name = "کلمه ی عبور")]
        [Required(ErrorMessage = "{0}را وارد کنید")]
        [MaxLength(6,ErrorMessage ="{0} باید بیشتر از 5 کراکتر باشد")]
        public string Password { get; set; }
        #endregion

        public RegisterModel(IUserService userService)
        {
            _userService = userService;
        }

        public void OnGet()
        {

        }
        public IActionResult Onpost()
        {
            var result = _userService.RegisterUser(new UserRegisterDTo()
            {
                UserName = UserName,
                Password = Password,
                FullName = FullName
            });
            if (result.Status == OperationResultStatus.Error)
            {
                ModelState.AddModelError("UserName", result.Message);
                return Page();
            }
            return RedirectToPage("Login");
        }
    }
}

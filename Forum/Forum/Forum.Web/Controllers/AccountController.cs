using Microsoft.AspNetCore.Mvc;
using Forum.Application.Accounts;
using Forum.Application.Accounts.Requests;
using Forum.Application.Comments.Requests;
using Microsoft.AspNetCore.Authorization;

namespace Forum.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        private readonly ICurrentUserService _currentUserService;

        public AccountController(IUserService userService, ICurrentUserService currentUserService)
        {
            _userService = userService;
            _currentUserService = currentUserService;
        }

        public IActionResult Login()
        {
            return View();
        }

        /*        [ValidateAntiForgeryToken]
                [HttpPost]
                public async Task<IActionResult> Login([FromForm] LoginRequestModel model)
                {
                    if (!ModelState.IsValid)
                        return View();

                    var IsLoggedIn = await _userService.LoginAsync(model.Email, model.Password);
                    if (IsLoggedIn)
                    {
                        return RedirectToAction("GetAll", "Topic");
                    }

                    ModelState.AddModelError("", "Email or password is incorrect");
                    return View();
                }*/


        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Login([FromForm] LoginRequestModel model)
        {
            if (!ModelState.IsValid)
                return View();

            var result = await _userService.LoginAsync(model.Email, model.Password);
            if (result.Succeeded)
            {
                if (result.IsAdmin)
                    return RedirectToAction("GetAllForAdmin", "Topic");
                else
                    return RedirectToAction("GetAll", "Topic");
            }
            if(result.ErrorMessage != null)
            {
                ModelState.AddModelError("", result.ErrorMessage);
            }

            return View();
        }


        public async Task<IActionResult> Logout()
        {
            await _userService.LogoutAsync();
            return RedirectToAction(nameof(Login));
        }

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register([FromForm] RegistrationRequestModel model)
        {
            if (!ModelState.IsValid)
                return View();

            var result = await _userService.RegisterAsync(model);
            if (!result.Succeeded)
            {
                foreach (var err in result.Errors)
                {
                    ModelState.AddModelError("", err.Description);

                    return View();
                }
            }

            return RedirectToAction(nameof(Login));
        }


        public IActionResult Create(int? topicId)
        {
            if (topicId == null)
            {
                return NotFound();
            }
            var model = new CommentRequestPostModel { TopicId = topicId.Value };
            return View(model);
        }

        public async Task<IActionResult> EditUser(CancellationToken cancellationToken, string userId)
        {
            if (userId == null)
            {
                return NotFound();
            }
            var user = await _userService.GetAsync(cancellationToken, userId);
            var model = new UserPutModel
            { 
                Id = userId ,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Gender = user.Gender,
                UserName = user.UserName
            };

            return View(model);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Put(CancellationToken cancellationToken, UserPutModel model)
        {
            var errors = ModelState.Select(x => x.Value?.Errors)
             .Where(y => y.Count > 0).ToList();

            if (!ModelState.IsValid)
            {
                foreach (var error in errors)
                {
                    ModelState.AddModelError("", error[0].ErrorMessage);
                }
            }
            try
            {
                await _userService.UpdateAsync(cancellationToken, model);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View("EditUser", model);
            }
            var UserId = _currentUserService.GetCurrentUserId();

            return RedirectToAction("Index", "Home", new {id = UserId});
        }

        /*[ValidateAntiForgeryToken]
        [Authorize(Policy = "AdminAndUser")]
        [HttpPost]
        public async Task<IActionResult> RemovePropertiesAsync(CancellationToken cancellationToken, string userId)
        {
            if (!ModelState.IsValid)
                return View();

            await _userService.RemovePropertiesAsync(cancellationToken, userId);
            return RedirectToAction("Index", "Home", new { id = userId });
        }*/
    }
}
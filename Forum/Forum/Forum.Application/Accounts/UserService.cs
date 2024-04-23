using Forum.Application.Accounts.Requests;
using Forum.Application.Accounts.Responses;
using Forum.Application.Exceptions;
using Forum.Application.Exceptions.Topics;
using Forum.Application.Exceptions.Users;
using Forum.Application.Topics;
using Forum.Application.Topics.Responses;
using Forum.Domain.Entities;
using Mapster;
using Microsoft.AspNetCore.Identity;

namespace Forum.Application.Accounts
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IUserRepository _repository;


        //Cancelation tokens aq ar viyeneb
        public UserService(UserManager<User> userManager, SignInManager<User> signInManager, IUserRepository repository)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _repository = repository;
        }

        public async Task<IdentityResult> RegisterAsync(RegistrationRequestModel model)
        {
            var UserByEmail = await _userManager.FindByEmailAsync(model.Email);
            var UserByUserName = await _userManager.FindByNameAsync(model.UserName);
            if (UserByEmail != null || UserByUserName != null)
            {
                return IdentityResult.Failed(new IdentityError { Description = "This email or Username is already registered." });
            }
            var user = model.Adapt<User>();
            await _userManager.AddToRoleAsync(user, "User");

            return await _userManager.CreateAsync(user, model.Password);
        }

        /*        public async Task<bool> LoginAsync(string email, string password)
                {
                    var user = await _userManager.FindByEmailAsync(email);
                    if (user == null) 
                    {
                        return false;
                    }

                    var signInResult = await _signInManager.PasswordSignInAsync(user, password, false, false);
                    return signInResult.Succeeded;
                    
                }*/

        public async Task<LoginResult> LoginAsync(string email, string password)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return new LoginResult { Succeeded = false };
            }

            if (user.BanExpiration != null)
            {
                return new LoginResult { Succeeded = false, ErrorMessage = "Your account is currently banned." };
            }

            var signInResult = await _signInManager.PasswordSignInAsync(user, password, false, false);
            if (signInResult.Succeeded)
            {
                var isAdmin = await _userManager.IsInRoleAsync(user, "Admin");
                return new LoginResult { Succeeded = true, User = user, IsAdmin = isAdmin };
            }

            return new LoginResult { Succeeded = false, ErrorMessage = "Your Email or Password is incorrect." };
        }
        public async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync();
        }
        public async Task<UserPutModel> GetAsync(CancellationToken cancellationToken, string id)
        {
            var result = await _repository.GetAsync(cancellationToken, id);
            if (result == null)
            {
                throw new UserNotFound("User with this ID: " + id.ToString() + " was not found!");
            }
            return result.Adapt<UserPutModel>();
        }
        public async Task UpdateAsync(CancellationToken cancellationToken, UserPutModel model)
        {
            if (!await _repository.Exists(cancellationToken, model.Id))
            {
                throw new UserNotFound("User with this ID: " + model.Id.ToString() + " was not found!");
            }

            var existingUser = await _userManager.FindByIdAsync(model.Id.ToString());
            var isPasswordValid = await _userManager.CheckPasswordAsync(existingUser, model.Password);
            if (!isPasswordValid)
            {
                throw new UnauthorizedAccess("Incorrect password. Please confirm your identity!");
            }

            //var user = model.Adapt<User>();
            existingUser.FirstName = model.FirstName;
            existingUser.LastName = model.LastName;
            existingUser.Gender = model.Gender;
            existingUser.Email = model.Email;
            existingUser.UserName = model.UserName;
            await _repository.UpdateAsync(cancellationToken, existingUser);



            // პაროლის შეცვლა

           /* if (!string.IsNullOrEmpty(model.Password))
            {
                var result = await _userManager.ChangePasswordAsync(user, user.PasswordHash, model.Password);
                if (!result.Succeeded)
                {
                    throw new Exception("Failed to change password.");
                }
            }

            var updateResult = await _userManager.UpdateAsync(user);
            if (!updateResult.Succeeded)
            {
                throw new Exception("Failed to update user information.");
            }*/
        }

      /*  public async Task RemovePropertiesAsync(CancellationToken cancellationToken, string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                throw new Exception("User not found.");
            }
            user.Gender = null;
            await _userManager.UpdateAsync(user);
        }*/
    }
    
        public class LoginResult    
        {
            public bool Succeeded { get; set; }
            public User User { get; set; }
            public bool IsAdmin { get; set; }
            public string ErrorMessage { get; set; }
        }
    }

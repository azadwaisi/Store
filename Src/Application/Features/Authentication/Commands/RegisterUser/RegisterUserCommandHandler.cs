using Domain.Entities.Users;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Authentication.Commands.RegisterUser
{
	public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, IdentityResult>
	{
		private readonly UserManager<User> _userManager;
        // private readonly RoleManager<Role> _roleManager; // اگر می‌خواهید نقش پیش‌فرض بدهید
        public RegisterUserCommandHandler(UserManager<User> userManager/*, RoleManager<Role> roleManager*/)
		{
			_userManager = userManager;
			// _roleManager = roleManager;
		}

		public async Task<IdentityResult> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
		{
			var user = new User
			{
				UserName = request.UserDetails.UserName,
				Email = request.UserDetails.Email,
				// FirstName = request.UserDetails.FirstName, // اگر در User دارید
				// LastName = request.UserDetails.LastName,   // اگر در User دارید
				EmailConfirmed = false // یا false و سپس فرآیند تایید ایمیل
			};

			var result = await _userManager.CreateAsync(user, request.UserDetails.Password);

			if (result.Succeeded)
			{
				// می‌توانید نقش پیش‌فرض به کاربر بدهید
				// if (!await _roleManager.RoleExistsAsync("User"))
				// {
				//     await _roleManager.CreateAsync(new Role { Name = "User" });
				// }
				// await _userManager.AddToRoleAsync(user, "User");
			}
			return result;
		}
	}
}

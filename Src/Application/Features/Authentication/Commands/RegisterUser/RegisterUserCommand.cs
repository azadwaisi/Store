using Application.Dtos.User;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Authentication.Commands.RegisterUser
{
	public class RegisterUserCommand : IRequest<IdentityResult>
	{
		public required RegisterUserRequest UserDetails { get; set; }
	}
}

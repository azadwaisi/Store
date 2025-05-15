using Application.Dtos.User;
using Application.Features.Authentication.Commands.RegisterUser;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using WebApi.Common;

namespace WebApi.Controllers.V1
{
	public class AuthController : BaseApiController
	{
		[HttpPost("register")]
		public async Task<IActionResult> Register([FromBody] RegisterUserCommand request, CancellationToken cancellationToken)
		{
			return Ok(await Mediator.Send(request, cancellationToken));

		}
	}
}

﻿using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Common
{
	[Route("api/[controller]")]
	[ApiController]
	public class BaseApiController : ControllerBase
	{
		private ISender _mediator = null!;
		protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();
	}
}

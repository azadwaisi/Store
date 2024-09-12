using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Common
{
	[Route("api/[controller]")]
	[ApiController]
	public class BaseApiController : ControllerBase
	{
	}
}

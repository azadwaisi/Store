using Application.Dtos.Products;
using Application.Features.Products.Commands.AddProduct;
using Application.Features.Products.Queries.Get;
using Application.Features.Products.Queries.GetAll;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using WebApi.Common;

namespace WebApi.Controllers
{
	public class ProductsController : BaseApiController
	{
		//CQRS
		//Commands => add , edit , delete    // barai admin
		//Queries => select( get )           //
		[HttpGet]
		public async Task<ActionResult<IEnumerable<ProductDto>>> Get([FromQuery] GetAllProductsQuery request, CancellationToken cancellationToken)
		{
			return Ok(await Mediator.Send(request, cancellationToken));
		}
		[HttpGet("{id:Guid}") ]
		public async Task<ActionResult<ProductDto>> Get(Guid id,CancellationToken cancellationToken)
		{
			return Ok(await Mediator.Send(new GetProductQuery(id) ,cancellationToken));
		}
		[HttpPost]
		public async Task<ActionResult<ProductDto>> Add(AddProductCommand addProduct , CancellationToken cancellationToken)
		{
			return Ok(await Mediator.Send(addProduct, cancellationToken));
		}
	}
}

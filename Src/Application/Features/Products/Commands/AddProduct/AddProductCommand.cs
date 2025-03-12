using Application.Dtos.Products;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products.Commands.AddProduct
{
	public record AddProductCommand(AddProductDto Product) : IRequest<ProductDto>;
}

//can use this
//public class AddProductCommand : IRequest<Guid> // شناسه محصول جدید را برمی‌گرداند
//{
//	public string Name { get; set; }
//	public string Description { get; set; }
//	public decimal Price { get; set; }
//	public Guid CategoryId { get; set; }
//	// ... سایر ویژگی‌ها
//}
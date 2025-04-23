using Application.Common.Tags;
using Application.Contracts;
using Application.Dtos.Products;
using Application.Features.Products.Queries.GetAll;
using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities.Products;
using Domain.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products.Commands.UpdateProduct
{
	public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, ProductDto>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;
		private readonly ICacheService _cache;
		public UpdateProductCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ICacheService cache)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
			_cache = cache;
		}
		public async Task<ProductDto> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
		{
			var product = await _unitOfWork.Repository<Product>().GetByIdAsync(request.Id,cancellationToken);
			if (product == null) { throw new NotFoundEntityException(); }
			product.ProductName = request.ProductName;
			product.Barcode = request.Barcode;
			product.ProductBrandId = request.ProductBrandId;
			product.ProductTypeId = request.ProductTypeId;
			product.Description = request.Description;
			product.ModifiedDate = DateTime.Now;
			product.ModifiedUserId = request.UserId;
			product.PictureUrl = request.PictureUrl;
			product.UnitPrice = request.UnitPrice;
			product.Discontinued = request.Discontinued;
			await _cache.RemoveByTagAsync(CacheTags.Products);
			return _mapper.Map<ProductDto>(await _unitOfWork.Repository<Product>().UpdateAsync(product, cancellationToken));
		}
	}
}

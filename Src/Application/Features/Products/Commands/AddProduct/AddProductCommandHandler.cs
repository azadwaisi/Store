using Application.Contracts;
using Application.Dtos.Products;
using Application.Features.Products.Queries.Get;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities.Products;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products.Commands.AddProduct
{
	public class AddProductCommandHandler : IRequestHandler<AddProductCommand, ProductDto>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;
		private readonly ICacheService _cache;
        public AddProductCommandHandler(IUnitOfWork unitOfWork, IMapper mapper,ICacheService cache)
        {
			_unitOfWork = unitOfWork;
			_mapper = mapper;
			_cache = cache;
		}
        public async Task<ProductDto> Handle(AddProductCommand request, CancellationToken cancellationToken)
		{
			var product = _mapper.Map<Product>(request); //when use record --request.Product
			product.CreatedDate = DateTime.Now;
			product.CreateUserId = request.UserId;
			var res = await _unitOfWork.Repository<Product>().AddAsync(product, cancellationToken);
			await _unitOfWork.Save(cancellationToken);
			await _cache.RemoveByTagAsync("products");
			return _mapper.Map<ProductDto>(res);
		}
	}
}

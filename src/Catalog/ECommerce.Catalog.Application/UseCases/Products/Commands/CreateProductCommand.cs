using ECommerce.Catalog.Application.Abstractions.Repositories;
using ECommerce.Catalog.Application.Wrappers;
using ECommerce.Catalog.Domain.AggregateModels.ProductModels;
using MapsterMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Catalog.Application.UseCases.Products.Commands
{
    public class CreateProductCommandRequest : IRequest<Result<CreateProductCommandResponse>>
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public List<ProductVariantRequest>? ProductVariants { get; private set; }

        public class ProductVariantRequest
        {
            public string ProductVariantName { get; private set; }
            public string Description { get; private set; }
            public List<VariantPropertyRequest>? VariantProperties { get; private set; }

            public class VariantPropertyRequest
            {
                public string VariantName { get; set; }
                public string VariantValue { get; set; }
            }
        }
    }

    public class CreateProductCommandResponse
    {
        public int Id { get; set; }
    }

    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest, Result<CreateProductCommandResponse>>
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public CreateProductCommandHandler(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Result<CreateProductCommandResponse>> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {
            Product mappedRequest = _mapper.Map<Product>(request);

            await _repository.CreateProduct(mappedRequest);

            await _repository.SaveChangesAsync();

            return Result<CreateProductCommandResponse>.Success(new CreateProductCommandResponse { Id = mappedRequest.Id });
        }
    }
}

using AutoMapper;
using DemoCICD.Contract.Abstractions.Message;
using DemoCICD.Contract.Abstractions.Shared;
using DemoCICD.Contract.Services.Product;
using DemoCICD.Domain.Abstractions.Repository;
using DemoCICD.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DemoCICD.Application.UseCases.V1.Queries;

public sealed class GetProductQueryHandler : IQueryHandler<Query.GetProductQuery, List<Response.ProductResponse>>
{
    private readonly IMapper _mapper;
    private readonly IRepositoryBase<Product, Guid> _productRepository;

    public GetProductQueryHandler(
        IMapper mapper,
        IRepositoryBase<Product, Guid> productRepository)
    {
        _mapper = mapper;
        _productRepository = productRepository;
    }

    public async Task<Result<List<Response.ProductResponse>>> Handle(Query.GetProductQuery request,
        CancellationToken cancellationToken)
    {
        var products = await _productRepository.FindAll().ToListAsync();
        var result = _mapper.Map<List<Response.ProductResponse>>(products);
        return result;
    }
}
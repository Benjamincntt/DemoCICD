// <copyright file="Query.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using DemoCICD.Contract.Abstractions.Message;

namespace DemoCICD.Contract.Services.Product;

public static class Query
{
    public record GetProductQuery : IQuery<List<Response.ProductResponse>>;

    public record GetProductById(Guid Id) : IQuery<Response.ProductResponse>;
}

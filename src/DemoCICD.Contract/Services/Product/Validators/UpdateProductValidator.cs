﻿using FluentValidation;

namespace DemoCICD.Contract.Services.Product.Validators;

public class UpdateProductValidator : AbstractValidator<Command.UpdateProduct>
{
    public UpdateProductValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Price).GreaterThan(0);
        RuleFor(x => x.Name).NotEmpty();
    }
}
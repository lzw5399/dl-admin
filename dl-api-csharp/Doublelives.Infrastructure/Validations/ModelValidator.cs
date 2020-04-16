using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Doublelives.Infrastructure.Validations
{
    public static class ModelValidator<TModel, TValidator>
    where TModel : class
    where TValidator : AbstractValidator<TModel>, new()
    {
        public static void Validate(TModel model)
        {
            var validator = new TValidator();
            var result = validator.Validate(model);
            if (result.IsValid)
            {
                return;
            }

            FluentValidationExtensions.ThrowException(result);
        }
    }
}

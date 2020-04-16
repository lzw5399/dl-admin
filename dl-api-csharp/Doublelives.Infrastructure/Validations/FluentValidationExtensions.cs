using Doublelives.Infrastructure.Exceptions;
using FluentValidation;
using FluentValidation.Internal;
using FluentValidation.Resources;
using FluentValidation.Results;
using FluentValidation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Doublelives.Infrastructure.Validations
{
    public static class FluentValidationExtensions
    {
        public static IRuleBuilderOptions<T, TProperty> WithErrorCode<T, TProperty>(
            this IRuleBuilderOptions<T, TProperty> rule,
            Func<T, string> errorCodeProvider)
        {
            if (errorCodeProvider == null)
            {
                throw new ArgumentNullException(nameof(errorCodeProvider), "A errorCodeProvider must be provided.");
            }

            return rule.Configure((Action<PropertyRule>)(config =>
                config.CurrentValidator.Options.ErrorCodeSource =
                    (IStringSource)new LazyStringSource((Func<IValidationContext, string>)(ctx =>
                        errorCodeProvider((T)ctx.InstanceToValidate)))));
        }

        public static void SetValidator<T, TValidator>(this CustomContext context, TValidator validator, T newObj) where TValidator : AbstractValidator<T>
        {
            var result = validator.Validate(newObj);

            if (!result.IsValid)
            {
                foreach (var error in result.Errors)
                {
                    context.AddFailure(error);
                }
            }
        }

        public static void ThrowException(ValidationResult result)
        {
            var errors = result.Errors.GroupBy(e => e.PropertyName).Select(it =>
            {
                return new InvalidExceptionError
                {
                    FieldName = it.Key,
                    ErrorMessages = it.Select(e => new ErrorMessage(e.ErrorCode, e.ErrorMessage)).ToList()
                };
            }).ToList();

            throw new InvalidException(errors);
        }
    }
}

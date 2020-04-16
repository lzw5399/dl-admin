using Doublelives.Api.Models.Account.Requests;
using Doublelives.Shared.Constants;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Doublelives.Api.Validators.Account
{
    public class LoginRequestValidator : AbstractValidator<AccountLoginRequest>
    {
        public LoginRequestValidator()
        {
            RuleFor(s => s.UserName)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .WithErrorCode(ErrorMessages.USERNAME_REQUIRED_CODE)
                .WithMessage(ErrorMessages.USERNAME_REQUIRED_MESSAGE)
                .MaximumLength(FieldLengthLimits.USERNAME_LEN_MAX)
                .WithErrorCode(ErrorMessages.USERNAME_OVER_LENGTH_CODE)
                .WithMessage(ErrorMessages.USERNAME_OVER_LENGTH_MESSAGE);

            RuleFor(s => s.Password)
                .NotEmpty()
                .WithErrorCode(ErrorMessages.PASSWORD_IS_REQUIRED_CODE)
                .WithMessage(ErrorMessages.PASSWORD_IS_REQUIRED_MESSAGE);
        }
    }
}

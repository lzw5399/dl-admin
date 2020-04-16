using COSXML.CosException;
using Doublelives.Core.Models;
using Doublelives.Infrastructure.Exceptions;
using Doublelives.Shared.Constants;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Doublelives.Core.Filters
{
    public class GlobalExceptionFilter : ActionFilterAttribute, IExceptionFilter
    {
        private readonly ILogger<GlobalExceptionFilter> _logger;

        public GlobalExceptionFilter(ILogger<GlobalExceptionFilter> logger)
        {
            _logger = logger;
            Order = 2;
        }

        public void OnException(ExceptionContext context)
        {
            if (context.Exception is CosClientException clientException)
            {
                _logger.LogError($"ErrorType: {nameof(CosClientException)}\r\n\r\nErrorMessage: {clientException.Message}\r\n\r\nStackTrace: {context.Exception.StackTrace}");

                context.Result = new ObjectResult(clientException.Message)
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    DeclaredType = typeof(CosClientException)
                };
            }
            else if (context.Exception is CosServerException serverException)
            {
                _logger.LogError($"ErrorType: {nameof(CosServerException)}\r\n\r\nErrorMessage: {serverException.GetInfo()}\r\n\r\nStackTrace: {context.Exception.StackTrace}");

                context.Result = new ObjectResult(serverException.GetInfo())
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    DeclaredType = typeof(CosServerException)
                };
            }
            else if(context.Exception is InvalidException invalidException)
            {
                _logger.LogWarning($"Error: {JsonConvert.SerializeObject(invalidException.Errors)}\r\n\r\nStackTrace: {invalidException.StackTrace}");

                context.Result = new ObjectResult(invalidException.Errors)
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    DeclaredType = typeof(IEnumerable<InvalidExceptionError>)
                };
            }
            else if (context.Exception is DuplicatedException duplicatedException)
            {
                _logger.LogWarning($"Error: {JsonConvert.SerializeObject(duplicatedException.ErrorMessage)}\r\n\r\nStackTrace: {duplicatedException.StackTrace}");

                context.Result = new ObjectResult(duplicatedException.ErrorMessage)
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    DeclaredType = typeof(DuplicatedException)
                };
            }
            else if (context.Exception is NotFoundException notFoundException)
            {
                _logger.LogWarning($"Error: {JsonConvert.SerializeObject(notFoundException.ErrorMessage)}\r\n\r\nStackTrace: {notFoundException.StackTrace}");

                context.Result = new ObjectResult(notFoundException.ErrorMessage)
                {
                    StatusCode = StatusCodes.Status404NotFound,
                    DeclaredType = typeof(NotFoundException)
                };
            }
            else if (context.Exception is InternalException internalException)
            {
                _logger.LogWarning($"Error: {JsonConvert.SerializeObject(internalException.ErrorMessage)}\r\n\r\nStackTrace: {internalException.StackTrace}");

                context.Result = new ObjectResult(internalException.ErrorMessage)
                {
                    StatusCode = StatusCodes.Status404NotFound,
                    DeclaredType = typeof(InternalException)
                };
            }
            else if (context.Exception is BadRequestException badRequestException)
            {
                _logger.LogWarning($"Error: {JsonConvert.SerializeObject(badRequestException.ErrorMessage)}\r\n\r\nStackTrace: {badRequestException.StackTrace}");

                context.Result = new ObjectResult(badRequestException.ErrorMessage)
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    DeclaredType = typeof(BadRequestException)
                };
            }
            else
            {
                _logger.LogError($"ErrorType: Unknown\r\n\r\nErrorMessage: {context.Exception.Message}\r\n\r\nStackTrace: {context.Exception.StackTrace}");

                context.Result = new ObjectResult(new ErrorMessage(ErrorMessages.UNKNOWN_EXCEPTION_CODE, ErrorMessages.UNKNOWN_EXCEPTION_MESSAGE))
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    DeclaredType = typeof(ErrorResponseModel)
                };
            }
        }
    }
}

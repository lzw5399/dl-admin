using System;
using Doublelives.Shared.Constants;
using Microsoft.AspNetCore.Mvc.Controllers;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;
using System.Linq;
using Microsoft.OpenApi.Models;

namespace Doublelives.Api.Swagger
{
    public class SwaggerAddHeaderParameter : IOperationFilter
    {
        private readonly (string, string)[] _allowAnonymousActions = new[]
        {
            ("album", "divideByZero"),
            ("user", "getToken")
        };

        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (operation.Parameters == null)
            {
                operation.Parameters = new List<OpenApiParameter>();
            }

            bool allowAnonymous = _allowAnonymousActions
                .Any(t =>
                {
                    (string controller, string action) = t;
                    var descriptor = context.ApiDescription.ActionDescriptor as ControllerActionDescriptor;

                    if (descriptor.ControllerName.Equals(controller, StringComparison.InvariantCultureIgnoreCase)
                    && (action == "*" || descriptor.ActionName.Equals(action, StringComparison.InvariantCultureIgnoreCase)))
                    {
                        return true;
                    }

                    return false;
                });

            if (!allowAnonymous)
            {
                operation.Parameters.Add(new OpenApiParameter()
                {
                    Description = "Example: \"{your token}\"",
                    Name = ApiHeaders.TOKEN,
                    In = ParameterLocation.Header,
                    Required = false,
                    Schema = new OpenApiSchema
                    {
                        Type = "apikey"
                    }
                });
            }
        }
    }
}
